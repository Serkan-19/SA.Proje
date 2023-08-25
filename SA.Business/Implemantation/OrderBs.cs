using AutoMapper;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using SA.Business.CustomExceptions;
using SA.Business.Interface;
using SA.DataAccess.Interfaces;
using SA.Model.Dtos.Order;
using SA.Model.Entities;

namespace SA.Business.Implemantation
{
    public class OrderBs : IOrderBs
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        public OrderBs(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var order = await _repo.GetByOrderIdAsync(id);

            _repo.DeleteAsync(order);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderGetDto>> GetByOrderIDAsync(int orderId, params string[] includeList)
        {
            var order = _repo.GetByOrderIdAsync(orderId, includeList);
            if (order != null)
            {
                var dto = _mapper.Map<OrderGetDto>(order);
                return ApiResponse<OrderGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            return ApiResponse<OrderGetDto>.Fail(StatusCodes.Status404NotFound, "Ürün Bulunamadı."); ;

        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrderByOrderDateAsync(DateTime startDate, DateTime endDate, params string[] includeList)
        {
            var orders = await _repo.GetOrderByOrderDateAsync(startDate, endDate, includeList);

            if (orders.Count > 0)
            {
                var orderList = _mapper.Map<List<OrderGetDto>>(orders);
                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, orderList);
            }
            return ApiResponse<List<OrderGetDto>>.Fail(StatusCodes.Status404NotFound, "Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList)
        {
            var orders = await _repo.GetAllAsync(includeList: includeList);
            if (orders.Count > 0)
            {
                var orderList = _mapper.Map<List<OrderGetDto>>(orders);

                return ApiResponse<List<OrderGetDto>>.Success(StatusCodes.Status200OK, orderList);
            }

            return ApiResponse<List<OrderGetDto>>.Fail(StatusCodes.Status404NotFound, "Ürün Bulunamadı.");



        }

        //public ApiResponse<OrderPostDto> Insert(OrderPostDto dto)
        //{
        //    var order = _mapper.Map<Order>(dto);
        //    var insertedOrder = _repo.Insert(order);

        //    var orderPostDto = _mapper.Map<OrderPostDto>(insertedOrder);

        //    return ApiResponse<OrderPostDto>.Success(StatusCodes.Status201Created, orderPostDto);


        //}

        //public ApiResponse<OrderPutDto> Update(int orderId, OrderPutDto dto)
        //{
        //    var orderSrc = _repo.GetByOrderId(orderId);
        //    if (orderSrc == null)
        //    {
        //        return ApiResponse<OrderPutDto>.Fail(StatusCodes.Status404NotFound, "Emir bulunamadı.");
        //    }

        //    _mapper.Map(dto, orderSrc);

        //    var updatedOrder = _repo.Update(orderSrc);
        //    var orderPutDto = _mapper.Map<OrderPutDto>(updatedOrder);
        //    return ApiResponse<OrderPutDto>.Success(StatusCodes.Status200OK, orderPutDto);


        //}
        public async Task<ApiResponse<Order>> InsertAsync(OrderPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.GemiCikisTarihi.Value.Year > 1996)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 1996'dan önce olmalıdır.");

            // validasyonlar....
            var order = _mapper.Map<Order>(dto);
            var insertedOrder = await _repo.InsertAsync(order);
            return ApiResponse<Order>.Success(StatusCodes.Status200OK, insertedOrder);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.GemiCikisTarihi.Value.Year > 1996)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 1996'dan önce olmalıdır.");
            //validasyonlar....
            var order = _mapper.Map<Order>(dto);
            await _repo.UpdateAsync(order);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}

using AutoMapper;
using CommonTypesLayer.DataAccess.Implemantations.EF;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using SA.Business.CustomExceptions;
using SA.Business.Interface;
using SA.DataAccess.EF.Context;
using SA.DataAccess.Interfaces;
using SA.Model.Dtos.Customer;
using SA.Model.Dtos.Employee;
using SA.Model.Entities;

namespace SA.Business.Implemantation
{
    public class CustomerBs : ICustomerBs

    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        public CustomerBs(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<CustomerGetDto>> GetByCustomerIdAsync(String customerId, params string[] includeList)
        {
            var employee = await _repo.GetCustomerByCustomerIdAsync(customerId, includeList);
            if (employee != null)
            {
                var dto = _mapper.Map<CustomerGetDto>(employee);
                return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }



        public async Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            var insertedOrder = await _repo.InsertAsync(customer);
            return ApiResponse<Customer>.Success(StatusCodes.Status200OK, insertedOrder);
        }
        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.SirketAdi == null)
                throw new BadRequestException("Sirket adını yazınız.");

            //validasyonlar....
            var customer = _mapper.Map<Customer>(dto);
            await _repo.UpdateAsync(customer);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
        public async Task<ApiResponse<NoData>> DeleteAsync(string id)
        {
            var customer = await _repo.GetCustomerByCustomerIdAsync(id);
            await _repo.DeleteAsync(customer);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}

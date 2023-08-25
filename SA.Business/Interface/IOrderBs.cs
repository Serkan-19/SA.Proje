using CommonTypesLayer.Utilities;
using SA.Model.Dtos.Order;
using SA.Model.Entities;

namespace SA.Business.Interface
{
    public interface IOrderBs
    {

        Task<ApiResponse<List<OrderGetDto>>> GetOrderByOrderDateAsync(DateTime startDate, DateTime endDate, params string[] includeList);
        Task<ApiResponse<OrderGetDto>> GetByOrderIDAsync(int orderId, params string[] includeList);
        Task<ApiResponse<List<OrderGetDto>>> GetOrdersAsync(params string[] includeList);
        //ApiResponse<OrderPostDto> Insert(OrderPostDto entity);
        //ApiResponse<OrderPutDto> Update(int orderId, OrderPutDto entity);
        Task<ApiResponse<Order>> InsertAsync(OrderPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(OrderPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }

}


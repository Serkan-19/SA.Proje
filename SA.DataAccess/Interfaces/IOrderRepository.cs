using CommonTypesLayer.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
     Task<List<Order>> GetOrderByOrderDateAsync(DateTime startDate, DateTime endDate, params string[] includeList);
     Task<Order>  GetByOrderIdAsync(int orderId, params string[] includeList);

    }

}

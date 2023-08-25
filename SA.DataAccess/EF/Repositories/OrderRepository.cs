using CommonTypesLayer.DataAccess.Implemantations.EF;
using SA.DataAccess.EF.Context;
using SA.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order, NorthwindContext>, IOrderRepository
    {
        public async Task<Order> GetByOrderIdAsync(int orderId, params string[] includeList)
        {
            var result = await GetAsync(ord => ord.OrderID == orderId, includeList);

            return result;
        }

        public async Task<List<Order>> GetOrderByOrderDateAsync(DateTime startDate, DateTime endDate, params string[] includeList)
        {
            var result = await GetAllAsync(ord => ord.OrderDate >= startDate && ord.OrderDate <= endDate, includeList);
            return result;
        }

    }
}

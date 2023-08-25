using CommonTypesLayer.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerByCustomerIdAsync(string customerId, params string[] includeList);
      
    }
}

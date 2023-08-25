using CommonTypesLayer.DataAccess.Implemantations.EF;
using SA.DataAccess.EF.Context;
using SA.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, NorthwindContext>, ICustomerRepository
    {
        public async Task<Customer> GetCustomerByCustomerIdAsync(string customerId, params string[] includeList)
        {
            var result = await GetAsync(prd => prd.CustomerID == customerId,includeList);
           
            return result;
        }
    }
}

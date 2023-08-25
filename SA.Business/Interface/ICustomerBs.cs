using CommonTypesLayer.Utilities;
using SA.Model.Dtos.Customer;
using SA.Model.Dtos.Employee;
using SA.Model.Entities;

namespace SA.Business.Interface
{
    public interface ICustomerBs
    {
        Task <ApiResponse<CustomerGetDto>> GetByCustomerIdAsync(string customerId,params string[] includeList);
        Task <ApiResponse <Customer>>InsertAsync(CustomerPostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(string id);
    }
}

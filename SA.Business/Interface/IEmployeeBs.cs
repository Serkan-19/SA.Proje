using CommonTypesLayer.Utilities;
using SA.Model.Dtos.Employee;
using SA.Model.Dtos.Order;
using SA.Model.Entities;

namespace SA.Business.Interface
{
    public interface IEmployeeBs
    {
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList);
        Task<ApiResponse<EmployeeGetDto>> GetEmployeeByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeeByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetBirthdateAsync(DateTime min, DateTime max, params string[] includeList);
        Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto entity);
        Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
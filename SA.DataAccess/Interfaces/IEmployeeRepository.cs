using CommonTypesLayer.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> GetEmployeeByCityAsync(string city, params string[] includeList);
        Task<Employee> GetEmployeeByIdAsync(int id, params string[] includeList);
        Task<List<Employee>> GetEmployeeByBirthDateAsync(DateTime min, DateTime max, params string[] includeList);

    }
}

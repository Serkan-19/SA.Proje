using CommonTypesLayer.DataAccess.Implemantations.EF;
using SA.DataAccess.EF.Context;
using SA.DataAccess.Interfaces;
using SA.Model.Entities;

namespace SA.DataAccess.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, NorthwindContext>, IEmployeeRepository
    {
        public async Task<List<Employee>> GetEmployeeByBirthDateAsync(DateTime min, DateTime max, params string[] includeList)
        {
            var result = await GetAllAsync(prd => prd.BirthDate < max && prd.BirthDate > min,includeList);
            return result;
        }

        public async Task<List<Employee>> GetEmployeeByCityAsync(string city, params string[] includeList)
        {
            var result = await GetAllAsync(prd => prd.City== city,includeList);
            return result;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id, params string[] includeList)
        {
            var result = await GetAsync(emp => emp.EmployeeID == id, includeList);

            return result;
        }
    }
       
}
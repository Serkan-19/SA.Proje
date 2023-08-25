using AutoMapper;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using SA.Business.CustomExceptions;
using SA.Business.Interface;
using SA.DataAccess.Interfaces;
using SA.Model.Dtos.Employee;
using SA.Model.Entities;

namespace SA.Business.Implemantation
{
    public class EmployeeBs : IEmployeeBs
    {

        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeBs(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeesAsync(params string[] includeList)
        {
            var employees = await _repo.GetAllAsync(includeList: includeList);
            if (employees.Count > 0)
            {
                var empList = _mapper.Map<List<EmployeeGetDto>>(employees);
                var response = ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, empList);

                return response;
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeeByCityAsync(string city, params string[] includeList)
        {
            var employees = await _repo.GetEmployeeByCityAsync(city, includeList);

            if (employees != null || employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);
                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new BadRequestException("Ürün Yok");


        }

        public async Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            var insertedOrder = await _repo.InsertAsync(employee);
            return ApiResponse<Employee>.Success(StatusCodes.Status200OK, insertedOrder);
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetBirthdateAsync(DateTime min, DateTime max, params string[] includeList)
        {
            var employee = await _repo.GetEmployeeByBirthDateAsync(min, max, includeList);

            if (employee != null)
            {
                var employeeList = _mapper.Map<List<EmployeeGetDto>>(employee);
                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, employeeList);
            }
            throw new NotFoundException("Ürün Yok");



        }
        public async Task<ApiResponse<EmployeeGetDto>> GetEmployeeByIdAsync(int id, params string[] includeList)
        {
            var employee = await _repo.GetEmployeeByIdAsync(id, includeList);
            if (employee != null)
            {
                var dto = _mapper.Map<EmployeeGetDto>(employee);
                return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");
        }
        public async Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.IscininSehiri == null)
                throw new BadRequestException("Sirket adını yazınız.");

            //validasyonlar....
            var employee = _mapper.Map<Employee>(dto);
            await _repo.UpdateAsync(employee);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var employee = await _repo.GetEmployeeByIdAsync(id);
            await _repo.DeleteAsync(employee);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}





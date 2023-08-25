using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Implemantation;
using SA.Business.Interface;
using SA.Model.Dtos.Employee;
using SA.Model.Dtos.Order;
using SA.Model.Entities;

namespace SA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeBs _employeeBs;
        public EmployeesController(IEmployeeBs employeeBs)
        {
            _employeeBs = employeeBs;

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdIDAsync([FromRoute] int id)
        {
            var response = await _employeeBs.GetEmployeeByIdAsync(id);

            return SendResponse(response);
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAync()
        {
            var empList = await _employeeBs.GetEmployeesAsync();

            return SendResponse(empList);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [HttpGet("{city}")]
        public async Task<IActionResult> GetAllCityAsync([FromQuery] string city)
        {
            var cities = await _employeeBs.GetEmployeeByCityAsync(city);
            return SendResponse(cities);


        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<EmployeeGetDto>))]
        [HttpGet("getbirthdate")]
        public async Task<IActionResult> GetByBirthdateAsync([FromQuery] DateTime min, [FromQuery] DateTime max)
        {
            var employeebirthdate = await _employeeBs.GetBirthdateAsync(min, max);
            return SendResponse(employeebirthdate);


        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<EmployeePostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<EmployeePostDto>))]
        [HttpPost]
        public async Task<IActionResult> SaveNewEmployeeAsync([FromBody] EmployeePostDto dto)
        {


            var insertedEmployee = await _employeeBs.InsertAsync(dto);


            return CreatedAtAction(nameof(GetEmployeeByIdIDAsync), new { id = insertedEmployee.Data.EmployeeID }, insertedEmployee.Data);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<EmployeePutDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<EmployeePutDto>))]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] EmployeePutDto dto)
        {
            var updatedEmp = await _employeeBs.UpdateAsync(dto);

            return SendResponse(updatedEmp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync([FromQuery] int id)
        {
            var response = await _employeeBs.DeleteAsync(id);

            return SendResponse(response);

        }
    }
}

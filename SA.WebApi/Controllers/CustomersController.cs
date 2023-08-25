using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interface;
using SA.Model.Dtos.Customer;

namespace SA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {

        private readonly ICustomerBs _customerBs;
        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CustomerGetDto>))]
        [HttpGet("{id}")]
        public  async Task<IActionResult>GetCustomerByCustomerIDAsync([FromRoute] string id)
        {
            var customer = await _customerBs.GetByCustomerIdAsync(id,"Orders");

            return SendResponse(customer);
              
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<CustomerPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerPostDto>))]
        [HttpPost]
        public async Task<IActionResult> SaveNewCustomerAsync([FromBody] CustomerPostDto dto)
        {


            var insertedCustomer = await _customerBs.InsertAsync(dto);


            return CreatedAtAction(nameof(GetCustomerByCustomerIDAsync), new { id = insertedCustomer.Data.CustomerID }, insertedCustomer.Data);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerPutDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CustomerPutDto>))]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerPutDto dto)
        {
            var updatedCustomer = await _customerBs.UpdateAsync(dto);

            return SendResponse(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromQuery] string id)
        {
            var response = await _customerBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}

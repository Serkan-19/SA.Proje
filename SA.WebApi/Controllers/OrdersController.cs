using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interface;
using SA.Model.Dtos.Order;



namespace SA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IOrderBs _orderBs;

        public OrdersController(IOrderBs orderBs)
        {
            _orderBs = orderBs;

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [HttpGet]
        public async Task<IActionResult> GetByOrders()
        {
            var orderList = await _orderBs.GetOrdersAsync("Employee","Customer");

            return SendResponse(orderList);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<OrderGetDto>))]
        [HttpGet("{id}")]
        public async Task <IActionResult> GetByOrderIDAsync([FromRoute] int id)
        {
            var response = await _orderBs.GetByOrderIDAsync( id,"Customer", "Employee");

            return SendResponse(response);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderGetDto>>))]
        [HttpGet("getbydate")]
        public async Task<IActionResult> GetOrderByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var orders = await _orderBs.GetOrderByOrderDateAsync(startDate, endDate,"Customer","Employee");

            return SendResponse(orders);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<OrderPostDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderPostDto>))]
        [HttpPost]
        public async Task<IActionResult> SaveNewOrderAsync([FromBody] OrderPostDto dto)
        {
            

            var insertedOrder = await _orderBs.InsertAsync(dto);
           

            return CreatedAtAction(nameof(GetByOrderIDAsync), new { id = insertedOrder.Data.OrderID }, insertedOrder.Data);
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderPutDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<OrderPutDto>))]
        [HttpPut]
        public async Task <IActionResult> UpdateOrderAsync([FromBody] OrderPutDto dto)
        {
           var updatedOrder = await _orderBs.UpdateAsync(dto);

            return SendResponse(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteOrderAsync([FromQuery] int id)
        {
          var response =  await _orderBs.DeleteAsync(id);

            return SendResponse(response);
        }

    }
}
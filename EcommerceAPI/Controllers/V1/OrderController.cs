using EcommerceAPI.CQRS.Commands.OrderCommands;
using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Data.DTO.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/orders")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var result = await _mediator.Send(new GetOrdersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{OrderId:Guid}")]
        public async Task<ActionResult> GetOrder(Guid OrderId)
        {
            try
            {
                var result = await _mediator.Send(new GetOrderByIDQuery(OrderId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{OrderId:Guid}")]
        public async Task<IActionResult> Put(Guid OrderId, UpdateOrderDTO order)
        {
            try
            {
                await _mediator.Send(new PutOrderCommand(OrderId, order));
                return Ok("Order Successfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{OrderId:Guid}")]
        public async Task<IActionResult> Delete(Guid OrderId)
        {
            try
            {
                await _mediator.Send(new DeleteOrderCommand(OrderId));
                return Ok("Delete Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

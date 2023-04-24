using EcommerceAPI.Data.Commands;
using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Data.Queries;
using EcommerceAPI.DTO.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;
        public OrderController(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                //var result = await _orderRepository.GetOrders();       
                var result = await _mediator.Send(new GetOrdersQuery());
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{OrderId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetOrder(Guid OrderId)
        {
            try
            {
                //var result = await _orderRepository.GetOrder(OrderId);
                var result = await _mediator.Send(new GetOrderByIDQuery(OrderId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{OrderId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid OrderId, UpdateOrderDTO order)
        {
            try
            {
                await _mediator.Send(new PutOrderCommand(OrderId, order));
                return NoContent();
                //var result = _orderRepository.Put(OrderId, order);
                //if (result)
                //return Ok(result);
                //else
                //return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{OrderId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid OrderId)
        {
            try
            {
                //_orderRepository.Delete(OrderId);
                await _mediator.Send(new DeleteOrderCommand(OrderId));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

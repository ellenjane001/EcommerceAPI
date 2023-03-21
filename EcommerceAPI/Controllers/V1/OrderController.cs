using EcommerceAPI.CQRS.Commands.OrderCommands;
using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Data.DTO.Order;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<UpdateOrderDTO> _validator;
        public OrderController(IMediator mediator, IValidator<UpdateOrderDTO> validator)
        {
            _mediator = mediator;
            _validator = validator;
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
                ValidationResult result = await _validator.ValidateAsync(order);
                if (!result.IsValid)
                {
                    result.AddToModelState(this.ModelState);
                }
                await _mediator.Send(new PutOrderCommand(OrderId, order));
                return NoContent();
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

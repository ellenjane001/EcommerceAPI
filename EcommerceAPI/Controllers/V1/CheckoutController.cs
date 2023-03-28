using EcommerceAPI.CQRS.Commands;
using EcommerceAPI.Data.DTO.Checkout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/checkout")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDTO order)
        {
            try
            {
                await _mediator.Send(new CheckoutOrderCommand(order));
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

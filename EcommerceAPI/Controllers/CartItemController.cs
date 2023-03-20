using EcommerceAPI.Data.Commands;
using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Data.Queries;
using EcommerceAPI.DTO.CartItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMediator _mediator;
        public CartItemController(ICartItemRepository cartItemRepository, IMediator mediator)
        {
            _cartItemRepository = cartItemRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                //var results = await _cartItemRepository.GetCartItems();
                var results = await _mediator.Send(new GetCartItemsQuery());
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddCartItemDTO addCartItem)
        {
            try
            {
                //var res = await _cartItemRepository.Post(addCartItem);
                await _mediator.Send(new AddCartItemCommand(addCartItem));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(Guid CartItemId, [FromBody] UpdateCartItemDTO updateCartItem)
        {
            try
            {
                var res = _cartItemRepository.Put(CartItemId, updateCartItem);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid CartItemId)
        {
            try
            {
                _cartItemRepository.Delete(CartItemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

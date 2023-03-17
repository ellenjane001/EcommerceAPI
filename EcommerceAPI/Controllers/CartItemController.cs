using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.DTO.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemController(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _cartItemRepository.GetCartItems();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Unauthorized();
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCartItemDTO addCartItem)
        {
            try
            {
                var res = await _cartItemRepository.Post(addCartItem);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{CartItemId:Guid}")]
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

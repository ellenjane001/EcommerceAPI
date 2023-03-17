using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var result = await _orderRepository.GetOrders();
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
                var result = await _orderRepository.GetOrder(OrderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{OrderId:Guid}")]
        public IActionResult Put(Guid OrderId, UpdateOrderDTO order)
        {
            try
            {
                var result = _orderRepository.Put(OrderId, order);
                if (result)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{OrderId:Guid}")]
        public IActionResult Delete(Guid OrderId)
        {
            try
            {
                _orderRepository.Delete(OrderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

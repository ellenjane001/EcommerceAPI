﻿using EcommerceAPI.CQRS.Commands.CartItemCommands;
using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Data.DTO.CartItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
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
                await _mediator.Send(new AddCartItemCommand(addCartItem));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid CartItemId, [FromBody] UpdateCartItemDTO updateCartItem)
        {
            try
            {
                await _mediator.Send(new PutCartItemCommand(CartItemId, updateCartItem));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{CartItemId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid CartItemId)
        {
            try
            {
                await _mediator.Send(new DeleteCartItemCommand(CartItemId));
                return Ok("Delete Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

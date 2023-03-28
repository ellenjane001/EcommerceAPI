using EcommerceAPI.CQRS.Commands.UserCommands;
using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Data.DTO.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.V1
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{UserId:Guid}")]
        public async Task<IActionResult> GetUser(Guid UserId)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByIdQuery(UserId));
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO createUser)
        {
            try
            {
                var res = await _mediator.Send(new AddUserCommand(createUser));
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}

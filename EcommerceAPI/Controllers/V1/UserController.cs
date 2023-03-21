using EcommerceAPI.CQRS.Commands.UserCommands;
using EcommerceAPI.CQRS.Queries;
using EcommerceAPI.Data.DTO.User;
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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUserDTO> _validator;
        public UserController(IMediator mediator, IValidator<CreateUserDTO> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetUsersQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{UserId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO createUser)
        {
            try
            {
                ValidationResult result = await _validator.ValidateAsync(createUser);
                if (!result.IsValid)
                {
                    result.AddToModelState(this.ModelState);
                }
                await _mediator.Send(new AddUserCommand(createUser));
                return Ok("Successfully added user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}

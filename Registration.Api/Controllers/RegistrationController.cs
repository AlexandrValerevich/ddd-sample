using MediatR;
using Microsoft.AspNetCore.Mvc;
using Registration.Api.Commands.Requests;
using Registration.Api.Contracts.V1;
using Registration.Api.Contracts.V1.Request;
using Registration.Api.Contracts.V1.Responce;

namespace Registration.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegistrationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(ApiRoutes.Registration.Register)]
    public async Task<IActionResult> Registration([FromForm] RegistrationRequest request)
    {
        if (ModelState.IsValid)
        {
            var registerUser = new RegisterUser
            {
                Email = request.Email,
                Password = request.Password,
                CompanyName = request.CompanyName
            };

            await _mediator.Send(registerUser);
            return Ok(new RegistrationResponce()
            {
                IsSuccsess = true
            });
        }

        return BadRequest(new RegistrationResponce()
        {
            IsSuccsess = false,
            Errors = new List<string>() { "Invalid input!" }
        });
    }
}

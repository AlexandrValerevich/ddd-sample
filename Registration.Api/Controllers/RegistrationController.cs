using Microsoft.AspNetCore.Mvc;

namespace Registration.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly ILogger<RegistrationController> _logger;

    public RegistrationController(ILogger<RegistrationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "home")]
    public IActionResult Get()
    {
        return Ok();
    }
}

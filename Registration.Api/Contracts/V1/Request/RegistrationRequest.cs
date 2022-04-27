using System.ComponentModel.DataAnnotations;

namespace Registration.Api.Contracts.V1.Request;

public class RegistrationRequest
{
    [EmailAddress, Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string CompanyName { get; set; }
}

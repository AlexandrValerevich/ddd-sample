using MediatR;
using Registration.Domain.UserRegistration;

namespace Registration.Api.Commands.Requests;

public class RegisterUser : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string CompanyName { get; set; }

    public void Deconstruct(out string email, out string password, out string companyName)
    {
        email = Email;
        password = Password;
        companyName = CompanyName;
    }

}

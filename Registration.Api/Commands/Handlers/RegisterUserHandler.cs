using MediatR;
using Registration.Api.Commands.Requests;
using Registration.Domain.UserRegistration;
using Registration.Domain.UserRegistration.Interfaces;

namespace Registration.Api.Commands.Handlers;

public class RegisterUserHandler : AsyncRequestHandler<RegisterUser>
{
    private readonly IRegistrationRepository _repository;

    public RegisterUserHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }
    protected async override Task Handle(RegisterUser request, CancellationToken cancellationToken)
    {
        var emails = await _repository.ReadExistentEmailsAsync();
        var (email, password, companyName) = request;

        var newEmail = new Email(email, emails);
        var newPassword = new Password(password);
        var newCompany = new Company(companyName);

        var newUser = new User(newEmail, newPassword, newCompany);

        await _repository.AddUserAsync(newUser);
    }
}

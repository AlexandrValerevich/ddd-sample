using MediatR;
using Registration.Api.Queries.Requests;
using Registration.Domain.UserRegistration;
using Registration.Domain.UserRegistration.Interfaces;

namespace Registration.Api.Queries.Hendlers;

public class GetExistanceEmailsHandler : IRequestHandler<GetExistenceEmails, IEnumerable<Email>>
{
    private readonly IRegistrationRepository _repository;

    public GetExistanceEmailsHandler(IRegistrationRepository repository)
    {
        _repository = repository;
    }

    Task<IEnumerable<Email>> IRequestHandler<GetExistenceEmails, IEnumerable<Email>>.Handle(GetExistenceEmails request, CancellationToken cancellationToken)
    {
        return _repository.ReadExistentEmailsAsync();
    }
}

using MediatR;
using Registration.Domain.UserRegistration;

namespace Registration.Api.Queries.Requests;

public class GetExistenceEmails : IRequest<IEnumerable<Email>> { }

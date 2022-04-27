using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Domain.UserRegistration.Interfaces;

public interface IRegistrationRepository
{
    Task<IEnumerable<Email>> ReadExistentEmailsAsync();
    Task<User> AddUserAsync(User newUser);
}

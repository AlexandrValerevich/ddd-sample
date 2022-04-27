using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Domain.UserRegistration.Interfaces;

public interface IRegistrationRepository
{
    Task<IEnumerable<Email>> ReadExistentEmails();
    Task<IEnumerable<Company>> ReadAllCompanies();
}

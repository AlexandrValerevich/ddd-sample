using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Domain.UserRegistration.Interfaces;

public interface IRepository
{
    Task<IEnumerable<Email>> GetExistentEmail();
}

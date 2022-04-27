using Microsoft.EntityFrameworkCore;
using Registration.Domain.UserRegistration;
using Registration.Domain.UserRegistration.Interfaces;

namespace Registration.Infrastructure.DataBaseAccess.Repositories;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly RegistrationDbContext _context;

    private DbSet<User> Users => _context.Users;

    public RegistrationRepository(RegistrationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Email>> ReadExistentEmailsAsync()
    {
        return await Users.Select(u => u.Email)
                          .AsNoTracking()
                          .ToListAsync();
    }

    public async Task<User> AddUserAsync(User newUser)
    {
        var createdEntity = await Users.AddAsync(newUser);
        await Save();

        return createdEntity.Entity;
    } 

    private  Task Save() => _context.SaveChangesAsync();
}

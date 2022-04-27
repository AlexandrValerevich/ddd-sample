using Microsoft.EntityFrameworkCore;
using Registration.Domain.UserRegistration;
using Registration.Infrastructure.DataBaseAccess.Configurations;

namespace Registration.Infrastructure.DataBaseAccess;

public class RegistrationDbContext : DbContext
{
    public RegistrationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new CompanyConfiguration());
    }

}
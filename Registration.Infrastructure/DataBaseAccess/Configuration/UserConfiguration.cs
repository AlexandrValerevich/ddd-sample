using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.UserRegistration;

namespace Registration.Infrastructure.DataBaseAccess.Configurations;

class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(u => u.Company)
               .WithMany(c => c.Users);

        builder.OwnsOne(u => u.Email, email => 
        {
            email.Property(e => e.Value)
                 .HasField("_email")
                 .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
                 
            email.ToTable("Eamil"); 
        });
        builder.OwnsOne(u => u.Password, password => { password.ToTable("Password"); });
    }
}
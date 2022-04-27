using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Registration.Domain.UserRegistration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Registration.Infrastructure.DataBaseAccess.Configurations;

class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);
        
        IMutableNavigation userNavigation = builder.Metadata.FindNavigation(nameof(Company.Users));
        userNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
using System;

namespace Registration.Domain.UserRegistration;

public sealed class User
{
    public Guid Id { get; }
    public Password Password { get; }
    public Email Email { get; }
    public Company Company { get; }
    public string CompanyName => Company.Name;

    protected User() { }

    public User(Email email, Password password!!, Company company!!)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Company = company;
    }
}

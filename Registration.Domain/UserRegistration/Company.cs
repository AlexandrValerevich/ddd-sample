using System;
using System.Collections.Generic;

namespace Registration.Domain.UserRegistration;

#pragma warning disable CS0628

public sealed class Company
{
    private readonly List<User> _users;

    public Guid Id { get; }
    public string Name { get; private set; }
    public IReadOnlyCollection<User> Users => _users;

    protected Company()
    {
        Id = Guid.NewGuid();
        _users = new List<User>();
        Name = string.Empty;
    }

    public Company(string name!!)
    {
        Id = Guid.NewGuid();
        _users = new List<User>();
        Name = name;
    }

}

using System.Collections.Generic;

namespace Registration.Domain.UserRegistration;

public class Company
{
    private readonly Id _id;
    private readonly List<User> _users;

    public string Id => _id.Value.ToString();
    public string Name { get; private set; }
    public IReadOnlyCollection<User> Users => _users;

    public Company(string name!!)
    {
        _id = new Id();
        _users = new List<User>();
        Name = name;
    }

}

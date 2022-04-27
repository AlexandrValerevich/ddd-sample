namespace Registration.Domain.UserRegistration;

public class User
{
    private readonly Id _id;

    public string Id => _id.Value.ToString();
    public Password Password { get; }
    public Email Email { get; }
    public Company Company { get; }
    public string CompanyName => Company.Name;

    public User(Email email!!, Password password!!, Company company!!)
    {
        _id = new Id();
        Email = email;
        Password = password;
        Company = company;
    }
}

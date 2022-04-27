using System;

namespace Registration.Domain.UserRegistration;

public class Id
{
    public Guid Value { get; } = Guid.NewGuid();
}

using System;

namespace Registration.Domain.UserRegistration;

public sealed class Id
{
    public Guid Value { get; } = Guid.NewGuid();

    public Id() { }
}

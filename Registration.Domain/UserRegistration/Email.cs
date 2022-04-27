using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Domain.UserRegistration;

public class Email
{
    private readonly string _email;
    public string Value => _email;

    public Email(string email!!, IReadOnlyCollection<Email> existentEmails!!)
    {
        Validate(email, existentEmails);
        _email = email;
    }

    private static void Validate(string email, IReadOnlyCollection<Email> existentEmails)
    {
        CheckEmailFormat(email);
        CheckExistingEmail(email, existentEmails);
    }

    private static void CheckExistingEmail(string email, IReadOnlyCollection<Email> existentEmails)
    {
        bool isExist = existentEmails.Any(e => e._email.Equals(email));
        if (isExist)
        {
            throw new Exception($"Email:{email} alredy exist");
        }
    }

    private static void CheckEmailFormat(string email)
    {
        try
        {
            var mail = new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new Exception($"Email:{email} has wrong format");
        }
    }
}
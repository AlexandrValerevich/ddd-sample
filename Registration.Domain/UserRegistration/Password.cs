using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System;
using System.Text;

namespace Registration.Domain.UserRegistration;

public class Password
{
    public string PasswordHash { get; }

    public Password(string password!!)
    {
        Validate(password);
        PasswordHash = HashPassword(password);
    }

    private static void Validate(string password)
    {
        CheckPasswordFormat(password);
    }

    private static void CheckPasswordFormat(string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");

        bool isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
        if (!isValidated)
        {
            throw new Exception("Password is not valid!");
        }
    }

    private static string HashPassword(string password)
    {
        byte[] salt = GetSalt();
        byte[] passwordByte = Encoding.ASCII.GetBytes(password);
        byte[] passwordByteHash = GenerateSaltedHash(passwordByte, salt);

        string passwordHash = BitConverter.ToString(passwordByteHash).Replace("-", "").ToLower();
        return passwordHash;
    }

    private static byte[] GetSalt()
    {
        byte[] salt = new byte[128 / 8];
        using var saltGenerator = RandomNumberGenerator.Create();
        saltGenerator.GetBytes(salt);

        return salt;
    }

    static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
    {
        using HashAlgorithm shaM = SHA384.Create();
        byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

        for (int i = 0; i < plainText.Length; i++)
        {
            plainTextWithSaltBytes[i] = plainText[i];
        }
        for (int i = 0; i < salt.Length; i++)
        {
            plainTextWithSaltBytes[plainText.Length + i] = salt[i];
        }
        return shaM.ComputeHash(plainTextWithSaltBytes);
    }
}

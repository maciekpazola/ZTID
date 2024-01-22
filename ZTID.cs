using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Przykład zaszyfrowania
        string originalText = "StrongPassword";
        string encryptedText = EncryptToBase64(originalText);
        Console.WriteLine("Encrypted: " + encryptedText);

        // Przykład odszyfrowania
        string decryptedText = DecryptFromBase64(encryptedText);
        Console.WriteLine("Decrypted: " + decryptedText);

        // Tworzenia hasła
        string securePassword = CreatePassword();
        Console.WriteLine("Secure Password: " + securePassword);
    }

    static string EncryptToBase64(string text)
    {
        byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(text);
        string base64 = Convert.ToBase64String(bytesToEncrypt);
        return base64;
    }

    static string DecryptFromBase64(string base64)
    {
        byte[] encryptedBytes = Convert.FromBase64String(base64);
        string decryptedText = Encoding.UTF8.GetString(encryptedBytes);
        return decryptedText;
    }

    static string CreatePassword()
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-=_+[]{}|;:'\",.<>/?";
        StringBuilder passwordBuilder = new StringBuilder();
        Random random = new Random();

        while (passwordBuilder.Length < 8)
        {
            char randomChar = validChars[random.Next(validChars.Length)];
            passwordBuilder.Append(randomChar);
        }
        return passwordBuilder.ToString();
    }
}

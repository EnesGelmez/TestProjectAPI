using System.Security.Cryptography;
using System.Text;

public static class EncryptPassword
{
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
    public static bool CheckPassword(string enteredPassword, string storedPasswordHash)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
            var enteredPasswordHash = Convert.ToBase64String(hashedBytes);
            return enteredPasswordHash == storedPasswordHash;
        }
    }
}

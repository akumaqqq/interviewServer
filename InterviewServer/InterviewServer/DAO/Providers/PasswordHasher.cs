using InterviewServer.DAO.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace InterviewServer.DAO.Providers
{
    /// <summary>
    /// Hashes passwords
    /// </summary>
    internal class PasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User user, string password)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password + user.Login + "ggjireogf4jrdoqwej29rfvcdsk2");
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword != HashPassword(user, providedPassword))
                return PasswordVerificationResult.Failed;

            return PasswordVerificationResult.Success;
        }
    }
}

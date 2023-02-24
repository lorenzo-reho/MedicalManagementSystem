using System;
using System.Security.Cryptography;
using System.Text;

namespace MedicalManagementSystem.Repository
{
    internal class CryptoRepository
    {

        public static Byte[] Hash(String source)
        {
            using (SHA1 sha = SHA1.Create())
            {
                Byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                Byte[] hashBytes = sha.ComputeHash(sourceBytes);

                return hashBytes;
            }
        }

    }
}

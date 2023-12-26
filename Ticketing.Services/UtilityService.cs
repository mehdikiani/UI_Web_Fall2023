using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core;

namespace Ticketing.Services
{
    public class UtilityService:IUtilityService
    {
        public string HashPassword(string password, string salt)
        {
            string complex = $"{password}{salt.ToLower()}";
            string hash = Sha256(complex);
            PasswordData passData = new PasswordData(hash, salt);
            return passData.ToBase64String();
        }

        public string Sha256(string clear)
        {
            UTF8Encoding ue = new UTF8Encoding();
            byte[] bytes = ue.GetBytes(clear);

            //System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            SHA256 SHA = new SHA256Managed();
            byte[] hashBytes = SHA.ComputeHash(bytes);

            // Convert the encrypted bytes back to a string (base 16)
            string hashString = "";

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i]);
            }

            return hashString;
        }
    }
}

using System.Text;

namespace Ticketing.Core
{
    public class PasswordData
    {
        public PasswordData(string hashPassword, string salt)
        {
            HashPassword = hashPassword;
            Salt = salt;
        }
        public string HashPassword { get; }
        public string Salt { get; }




        public override string ToString()
        {
            return $"{HashPassword}:{Salt}";
        }
        public string ToBase64String()
        {
            if (string.IsNullOrWhiteSpace(HashPassword) || string.IsNullOrWhiteSpace(Salt))
                throw new ArgumentException("HashPassord or salt value is null");
            try
            {

                return Convert.ToBase64String(Encoding.UTF8.GetBytes(ToString()));

            }
            catch
            {

                return null;
            }
        }

        public static PasswordData FromBase64String(string input)
        {
            try
            {
                var pass = Encoding.UTF8.GetString(Convert.FromBase64String(input));
                string[] passParts = pass.Split(':');
                if (passParts == null || passParts.Length != 2)
                    return null;
                return new PasswordData(passParts[0], passParts[1]);

            }
            catch
            {
                return null;
            }
        }

    }
}

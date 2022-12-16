using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPassword
{

    public class Passhash
    {
        public string HashPassword (string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] sourceBytePassw = Encoding.UTF8.GetBytes (password);
                byte[] hashSourceBytePassw = sha256.ComputeHash (sourceBytePassw);
                string hashPassw = BitConverter.ToString (hashSourceBytePassw).Replace("-", String.Empty);
                return hashPassw;
            }
        }
    }
}

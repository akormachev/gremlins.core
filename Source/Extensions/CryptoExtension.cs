using System.Security.Cryptography;
using System.Text;

namespace Gremlins.Security.Cryptography
{
    public static class CryptoHelper
    {

        #region Public methods

        /// <summary>
        /// Get MD5 value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5(string input)
        {            
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.GetEncoding(1251).GetBytes(input));
            return HexFormat(data);
        }

        /// <summary>
        /// Get PBKDF2 value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetPBKDF2(string input, byte[] salt)
        {          
            Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(input, salt, 1000);
            byte[] data = pwdGen.GetBytes(50);            
            return HexFormat(data);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Format binary array as hex value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string HexFormat(byte[] data)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));
            return builder.ToString();
        }

        #endregion
    }
}

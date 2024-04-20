using EntityFrameworkCore.EncryptColumn.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MediConnectSuiteAPI
{
    // Define the encryption provider interface
    public interface IEncryptionProvider2
    {
        string Encrypt(string data);
        string Decrypt(string encryptedData);
    }

    // Implement the encryption provider
    public class EncryptionProvider : IEncryptionProvider2
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptionProvider(string key, string iv)
        {
            _key = Encoding.UTF8.GetBytes(key);
            _iv = Encoding.UTF8.GetBytes(iv);
        }

        public string Encrypt(string data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string encryptedData)
        {
            byte[] cipherText = Convert.FromBase64String(encryptedData);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}
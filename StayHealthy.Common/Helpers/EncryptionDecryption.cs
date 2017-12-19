﻿namespace StayHealthy.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Manage Encryption Decryption
    /// <CreatedBy> Sanjay Suthar </CreatedBy>
    /// <CreatedDate> 17-Nov-2015 </CreatedDate>
    /// </summary>
    public class EncryptionDecryption
    {
        #region Variable Declaration

        /// <summary>
        /// key String
        /// </summary>
        private static string keyString = "27SEP83M-02FE-B201-2BOB-26NOV1983BYE";

        #endregion

        #region Methods/Functions

        /// <summary>
        /// Get Encrypted Value of Passed value
        /// </summary>
        /// <param name="value">value to Encrypted</param>
        /// <returns>encrypted string</returns>
        public static string GetEncrypt(string value)
        {
            return Encrypt(keyString, value);
        }

        /// <summary>
        /// Get Decrypted value of passed encrypted string
        /// </summary>
        /// <param name="value">value to Decrypted</param>
        /// <returns>Decrypted string</returns>
        public static string GetDecrypt(string value)
        {
            return Decrypt(keyString, value);
        }

        /// <summary>
        /// Method to encrypt the string to Encryption
        /// </summary>
        /// <param name="text">string to encrypt</param>
        /// <returns>encrypted string</returns>
        public static string Md5Encryption(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            // compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            // get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                // change it into 2 hexadecimal digits
                // for each byte
                strBuilder.Append(result[i].ToString("x2", CultureInfo.CurrentCulture));
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Encrypt value
        /// </summary>
        /// <param name="strKey">Passphrase for Encrypt</param>
        /// <param name="strData">Message to Encrypt</param>
        /// <returns>encrypted string</returns>
        private static string Encrypt(string strKey, string strData)
        {
            byte[] results;
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(strKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] dataToEncrypt = utf8.GetBytes(strData);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(results);
        }

        /// <summary>
        /// decrypt value
        /// </summary>
        /// <param name="strKey">Passphrase for Decrypt</param>
        /// <param name="strData">Message to Decrypt</param>
        /// <returns>Decrypted string</returns>
        private static string Decrypt(string strKey, string strData)
        {
            byte[] results;
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(strKey));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            strData = strData.Replace(" ", "+"); // Replace space with plus sign in encrypted value if any.- kalpesh joshi [09/05/2013]

            // Step 4. Convert the input string to a byte[]
            byte[] dataToDecrypt = Convert.FromBase64String(strData);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return utf8.GetString(results);
        }

        #endregion
    }
}
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

public class MD5Encryption
{
    public static string Hash(string toHash)
    {
        MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
        byte[] bytes = Encoding.UTF7.GetBytes(toHash);
        bytes = crypto.ComputeHash(bytes);
        StringBuilder sb = new StringBuilder();
        foreach (byte num in bytes)
        {
            sb.AppendFormat("{0:x2}", num);
           
        }

        return sb.ToString(); //32位
        //return sb.ToString().Substring(8, 16); //16位
    }
    
}

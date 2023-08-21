using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

class Decrypter
{
    static void Main()
    {
        string[] listOfBase64Text = {
            "wENDQtzYcL3CKv0lnnJ4hk0JYvJVBMwTj7a4Plq8h68=",
            "M35jHmvkY9WGlWdXo0ByOJrYhHmtC8O0rZ28CviPexkfHCFTfKUQVw==",
            "hufGZi+isAzspq9AOs+sIwqijQL53yIJa5EVcXF3QLLwXPS1AejOWfPzJZ/wHQbBAIOxsJJIcFq0+83hkFcz+Jz9HAGl8oDianTHILnUlzl1oEc30scurf41lEg+KSu/6orcZQl3Bws=",
            "6ySb2CBt+Z1SZ4GlB7/yL4cOS/j1whoSEqkyri0dj0juRpFBc4kqLw==",
            "U2ltlIYcyGYnuh0P+ahTMe3t9e+TYxKwU+PGm/UsltpkanmBmWym5mDDqqQ14J/VSSgCRKXn/E+DKaxmNc9PpPOG1vZndmflMUnuTUzbiIdHBUAEOWMO8wVCufhanIdN56BhtczjrJS5HRvl9NwE/FNkLGZt6HQNSgDRzrpY0mseJHjTbkal6nh226f43X3ZihIF4sdLn7l766ZksE9JDASBi7qEotE7f0yxEbStNOZ1QPDchKVFkw==",
            "wENDQtzYcL3CKv0lnnJ4hk0JYvJVBMwTj7a4Plq8h68=",
            "M35jHmvkY9WGlWdXo0ByOJrYhHmtC8O0eu8xtbA16kKagSu6MIFSWQ==",
            "hufGZi+isAzspq9AOs+sI0VYrJ6o8j3e9a1tNb9m1bVwJZpRxCOxg3Vs0NdU9xNxPku+sBziVYsVaOtgWkbH9691++BUkD1BNVRMc0e69lVs2cJmQIAbnagMaJ6OQEZAAvZ/G6y57CQ=",
            "6ySb2CBt+Z1SZ4GlB7/yL8asWs1F/wTUTOLEHO92yuzuTzdsiM5t5w==",
            "U2ltlIYcyGYnuh0P+ahTMe3t9e+TYxKwU+PGm/UsltpkanmBmWym5mDDqqQ14J/VSSgCRKXn/E+DKaxmNc9PpPOG1vZndmflMUnuTUzbiIdHBUAEOWMO8wVCufhanIdN56BhtczjrJS5HRvl9NwE/FNkLGZt6HQNSgDRzrpY0mseJHjTbkal6nh226f43X3ZihIF4sdLn7l766ZksE9JDASBi7qEotE7f0yxEbStNOZ1QPDchKVFkw==",
            "wENDQtzYcL3CKv0lnnJ4hk0JYvJVBMwTj7a4Plq8h68=",
            "M35jHmvkY9WGlWdXo0ByOJrYhHmtC8O0hn+gLHaClb4QbACeOoSiYA==",
            "hufGZi+isAzspq9AOs+sI/u+AS/aWPrAYd+mctDo7qEt+SpW2sELvSaxx6RRdK3vDavTsziAtb4/iCZ72v3QGh78yhY2KXZFu8qAcYdN7ltOOlg1LSrdkhjgr+CWTlvWh7A8IS7NwwI=",
            "6ySb2CBt+Z1SZ4GlB7/yL4rJGeZ0WVaYW7N15aUsDAqzIYJWL/f0yw==",
            "U2ltlIYcyGaSmL5xmAkEop+/f5MGUEWeWjpCTe5eStd/cg9FKp89l/EksGB90Z/hLbT44/Ur/6XL9aI27v0+SzaMFsgAeamjyYTRfLQk2fQlsRPCY/vMDj0FWRCGIZyHXCVoo4AePQB93SgQtOEkTQ2oBOeVU4X5sNQo23OcM1wrFrg8x90UOk2EzOm/IbS5BR+Wms1M2dCvLytaGCTmsUmBsATEF/zkfM2aGLytnu5+72bD99j7AiSvFDCpd1aFsogNiYYSai52YKIttjvao22+uqWMM/7Dx/meQWRCCkKm6s9ag1BFUQ==",
            "+iTzBxkIgVWgWm/oyP/Uf6+qW+A+kMTQkouTEammirkz2efek8yfrP5l+mtFS+bWA7TCjJDK2nLAdTKssL7CrHnVW8fMvc6mJR4Ismbs/d/fMDXQeiGXCA==",
        };

        foreach (var encodedString in listOfBase64Text)
        {
            Console.WriteLine(Decrypt(encodedString));
        }
    }

    public static string Decrypt(string base64String)
    {
        string key = "AKaPdSgV";
        string iv = "QeThWmYq";
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
        //byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(pt);

        byte[] unEncodedString = Convert.FromBase64String(base64String);

        using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
        {
            var mstr = new MemoryStream();
            var dcrystr = new CryptoStream(mstr, dsp.CreateDecryptor(keyBytes, ivBytes), CryptoStreamMode.Write);
            dcrystr.Write(unEncodedString, 0, unEncodedString.Length);
            dcrystr.FlushFinalBlock();
            return Encoding.UTF8.GetString(mstr.ToArray());
        }

    }
}

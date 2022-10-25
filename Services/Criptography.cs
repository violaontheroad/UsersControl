using System.Security.Cryptography;
using System.Text;

namespace UsersControl.Services;

public static class Criptography
{
    public static string GenerateHash(this string value)
    {
        var hash = SHA256.Create();
        var enconding = new ASCIIEncoding();
        var array = enconding.GetBytes(value);

        array = hash.ComputeHash(array);

        var strHexa = new StringBuilder();

        foreach (var item in array)
        {
         strHexa.Append(item.ToString("x2"));   
        }

        return strHexa.ToString();
    }
    

}
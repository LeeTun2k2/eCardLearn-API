using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Generate password supporter
/// </summary>
public static class PasswordGenerators
{
    private readonly static Random _rand = new Random();

    /// <summary>
    /// Generate new password
    /// </summary>
    /// <returns></returns>
    public static string Generate()
    {
        int length = _rand.Next(16, 32);
        const string lower = "abcdefghijklmnopqrstuvwxyz";
        const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string number = "1234567890";
        const string special = "-_@+";

        // Get cryptographically random sequence of bytes
        var bytes = new byte[length];

#pragma warning disable SYSLIB0023 // Type or member is obsolete
        new RNGCryptoServiceProvider().GetBytes(bytes);
#pragma warning restore SYSLIB0023 // Type or member is obsolete

        // Build up a string using random bytes and character classes
        var res = new StringBuilder();
        foreach (byte b in bytes)
        {
            // Randomly select a character class for each byte
            switch (_rand.Next(4))
            {
                // In each case use mod to project byte b to the correct range
                case 0:
                    res.Append(lower[b % lower.Count()]);
                    break;
                case 1:
                    res.Append(upper[b % upper.Count()]);
                    break;
                case 2:
                    res.Append(number[b % number.Count()]);
                    break;
                case 3:
                    res.Append(special[b % special.Count()]);
                    break;
            }
        }
        return res.ToString();
    }
}
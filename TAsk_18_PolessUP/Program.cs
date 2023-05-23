using System;

public class Solution
{
    public string ValidIPAddress(string IP)
    {
        if (IsIPv4(IP))
            return "IPv4";
        else if (IsIPv6(IP))
            return "IPv6";
        else
            return "Neither";
    }

    private bool IsIPv4(string IP)
    {
        string[] parts = IP.Split('.');
        if (parts.Length != 4)
            return false;

        foreach (string part in parts)
        {
            if (!int.TryParse(part, out int num) || num < 0 || num > 255 || (part.StartsWith("0") && part.Length > 1))
                return false;
        }

        return true;
    }

    private bool IsIPv6(string IP)
    {
        string[] parts = IP.Split(':');
        if (parts.Length != 8)
            return false;

        foreach (string part in parts)
        {
            if (part.Length < 1 || part.Length > 4)
                return false;

            foreach (char c in part)
            {
                if (!IsHexadecimalDigit(c))
                    return false;
            }
        }

        return true;
    }

    private bool IsHexadecimalDigit(char c)
    {
        return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string IP = "192.168.1.1";
        Solution solution = new Solution();
        string result = solution.ValidIPAddress(IP);
        Console.WriteLine(result);
    }
}

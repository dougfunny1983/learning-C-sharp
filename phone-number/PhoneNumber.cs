using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class PhoneNumber
{

    private static string RemoveTheNumber1(string digits) => digits[0] == '1' ? digits.Remove(0, 1) : digits;

    private static readonly string Pattern = @"^(1|)[2-9]\d{2}[2-9]\d{6}$";

    private static string Sanitizer(string phoneNumber)
    {
        var newWord = phoneNumber.Where(char.IsNumber);
        StringBuilder str = new StringBuilder();
        foreach (var x in newWord)
        {
            str.Append(x);
        }
        return str.ToString();
    }

    public static string Clean(string phoneNumber)
    {
        string answer = Sanitizer(phoneNumber);
        Regex phoneRegex = new Regex(Pattern);
        return !phoneRegex.IsMatch(answer)
            ? throw new ArgumentException($" The phone number {phoneNumber} is invalid!")
            : RemoveTheNumber1(answer);
    }


}
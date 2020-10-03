using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Acronym
{
    private const string Pattern = @"[^\\s0-9a-zA-Z\']+";
    public static string Abbreviate(string phrase)
    {
        var array = Regex.Split(phrase, Pattern);
        StringBuilder str = new StringBuilder();
        foreach (var x in array) 
        {
            str.Append(x[0]); 
        }
        return str.ToString().ToUpper();
    }
}
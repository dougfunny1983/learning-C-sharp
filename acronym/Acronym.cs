using System;
using System.Text.RegularExpressions;

public static class Acronym
{
    private const string Pattern = @"[^\\s0-9a-zA-Z\']+";
    public static string Abbreviate(string phrase)
    {
        var array = Regex.Split(phrase, Pattern);
        var str = "";
        foreach (var x in array) 
        {
            str += x[0];
        }

        return str.ToUpper();
    }
}
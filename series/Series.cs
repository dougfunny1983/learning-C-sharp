using System;
using System.Collections.Generic;

public static class Series
{

    public static string Slice(this string source, int start, int end)
    {
        try
        {
            return !(end < 0) ? source.Substring(start, end) : source.Substring(start, source.Length + end);

        }
        catch (ArgumentException)
        {
            return string.Empty;
        }
    }

    public static string[] Slices(string numbers, int sliceLength)
    {
        int length = numbers.Length;

        if (length == 0 || length < sliceLength || sliceLength < 1)
            throw new ArgumentException();

        List<string> answer = new List<string>();

        for (int i = 0; i < length; i++) 
        {
            string slice = numbers.Slice(i, sliceLength);

            if (!string.IsNullOrEmpty(slice)) 
            {
                answer.Add(slice);
            }
            
        }
        return answer.ToArray();
    }
}
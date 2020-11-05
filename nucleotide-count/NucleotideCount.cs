using System;
using System.Collections.Generic;

public static class NucleotideCount
{

    public static IDictionary<char, int> Count(string sequence)
    {
        IDictionary<char, int> answer = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 }
        };

        foreach (char ch in sequence) 
        {
            try
            {
                answer[ch] += 1;
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException();
            }
            
        }

        return answer;
    }
}
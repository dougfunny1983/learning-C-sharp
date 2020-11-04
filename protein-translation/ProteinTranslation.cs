using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
   
    private static readonly Dictionary<string, string[]> codons = new Dictionary<string, string[]>()
            {
                {"Methionine", new string[]{"AUG"} },
                {"Phenylalanine", new string[]{ "UUU", "UUC" } },
                {"Leucine", new string[]{ "UUA", "UUG" } },
                {"Serine", new string[]{ "UCU", "UCC", "UCA", "UCG" } },
                {"Tyrosine", new string[]{ "UAU", "UAC" } },
                {"Cysteine", new string[]{ "UGU", "UGC" } },
                {"Tryptophan", new string[]{ "UGG" } },
                {"STOP", new string[]{ "UAA", "UAG", "UGA" } },
            };

    private static List<string> StringSlicing(string Strings) 
    {
        List<string> answer = new List<string>();

        for (int i = 0; i < Strings.Length; i += 3)
        {
            answer.Add(Strings.Substring(i, 3));
        }
        return answer;
    }


    public static string[] Proteins(string strand)
    {

        List<string> value = new List<string>();

        foreach (string target in StringSlicing(strand))
        {
            foreach (KeyValuePair<string, string[]> item in codons)
            {

                if (item.Value.Contains(target))
                {
                    value.Add(item.Key);
                }

            }
        }

        string[] answer = value.Contains("STOP") ? value.GetRange(0, value.IndexOf("STOP")).ToArray() : value.ToArray();

        return answer;
    }
}
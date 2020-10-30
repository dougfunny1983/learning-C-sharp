using System;
using System.Collections.Generic;
using System.Text;

public static class Proverb
{

    private static string Text(string text1, string text2) => $"For want of a {text1} the {text2} was lost.";

    private static string Text(string text1) => $"And all for the want of a {text1}.";

    public static string[] Recite(string[] subjects)
    {
        List<string> answer = new List<string>();

        int len = subjects.Length;

        for (int i = 0; i < len; i++)
        {
            if (i + 1 != len)
            {
                answer.Add(Text(subjects[i], subjects[i + 1]));
            }
            else 
            {
                answer.Add(Text(subjects[0]));
            }
        }

        

        return answer.ToArray();
    }
}
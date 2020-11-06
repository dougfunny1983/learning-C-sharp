using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> answer = new Dictionary<string, int>();

        foreach (KeyValuePair<int, string[]> kvp in old)
        {
            foreach (var item in kvp.Value)
            {
                answer.Add(item.ToLower(), kvp.Key);
            }
        };

        return answer;
    }
}
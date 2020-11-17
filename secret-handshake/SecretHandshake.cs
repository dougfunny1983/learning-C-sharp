using System.Collections.Generic;

public static class SecretHandshake
{

    public static string[] Commands(int commandValue)
    {

        List<string> answer = new List<string>();

        if ((commandValue & 1) != 0)
            answer.Add("wink");
        if ((commandValue & 2) != 0)
            answer.Add("double blink");
        if ((commandValue & 4) != 0)
            answer.Add("close your eyes");
        if ((commandValue & 8) != 0)
            answer.Add("jump");

        if ((commandValue & 16) != 0)
            answer.Reverse();

        return answer.ToArray();

    }
}

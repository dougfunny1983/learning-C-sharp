using System.Collections.Generic;
using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        char[][] answer = input.Select(t => t.ToCharArray()).ToArray();
        int rows = answer.Length;
        int cols = (rows > 0) ? answer[0].Length : 0;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
            {
                if (answer[i][j] == '*')
                {
                    IEnumerable<(int row, int cols)> pumpPosition = PumpPosition(i, j)
                        .Where(t => t != (i, j))
                        .Where(t => t.row >= 0 && t.col >= 0)
                        .Where(t => t.row < rows && t.col < cols);

                    foreach ((int col, int line) in pumpPosition)
                    {
                        switch (answer[col][line])
                        {
                            case ' ':
                                answer[col][line] = '1';
                                break;
                            case char n when (n >= '1' && n < '8'):
                                answer[col][line]++;
                                break;
                        }
                    }
                }
            }

        return answer.Select(t => new string(t)).ToArray();
    }


    private static IEnumerable<(int row, int col)> PumpPosition(int row, int col)
    {
        for (int i = row - 1; i <= row + 1; i++)
            for (int j = col - 1; j <= col + 1; j++)
            {
                yield return (i, j);
            }
    }
}

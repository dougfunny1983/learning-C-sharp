using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {

        int[][] answer = new int[rows][];

        if (rows == 0) return answer;

        for (int row = 0; row < rows; row++)
        {
            answer[row] = new int[row + 1];
        }

        answer[0][0] = 1;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                answer[row + 1][col] += answer[row][col];
                answer[row + 1][col + 1] += answer[row][col];
            }
        }
  
        return answer;

    }

}
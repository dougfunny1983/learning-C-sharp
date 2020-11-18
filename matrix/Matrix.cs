using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private readonly int[][] input;

    public Matrix(string input)
    {
        string[] lines = input.Split('\n');

        List<int[]> column = new List<int[]>();

        foreach (string line in lines)
            column
                .Add(line.Split(' ')
                .Select(cell => Convert.ToInt32(cell))
                .ToArray());

        this.input = column.ToArray();

    }

    public int[] Row(int row) => input[row - 1];

    public int[] Column(int col) => input.Select(row => row[col - 1]).ToArray();

}

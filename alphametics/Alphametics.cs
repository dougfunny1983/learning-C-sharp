using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Sprache;

public static class Alphametics
{

    public static (char, long)[] LetterFactors(HashSet<char> _uniqueLetters, string[] _operands)
    {
        Dictionary<char, long> lettersAndFactors = _uniqueLetters.ToDictionary<char, char, long>(p => p, p => 0);
        foreach (string operand in _operands)
        {
            string reverseOperand = new string(operand.Reverse().ToArray());

            for (int i = 0; i < reverseOperand.Length; i++)
            {
                lettersAndFactors[reverseOperand[i]] += 1 * (long)Math.Pow(10, i);
            }
        }
        return lettersAndFactors.Select((kvp) => (kvp.Key, kvp.Value)).ToArray();
    }

    public static IDictionary<char, int> Solve(string equation)
    {

        string pattern = @"[\s+=]";

        string[] operands = Regex.Split(equation, pattern).Select(x => x).Where(x => x != "").ToArray();

        if (operands.Length == 2 && operands[0] != operands[1]) throw new ArgumentException();

        HashSet<char> uniqueLetters = equation.Where(x => char.IsLetter(x)).ToHashSet();

        HashSet<char> nonZeroLetters = new HashSet<char>();

        foreach (string operand in operands)
        {
            nonZeroLetters.Add(operand[0]);
        }

        string[] sumWord = new[] { operands.Last() };

        Array.Resize(ref operands, operands.Length - 1);

        foreach (string operand in operands)
        {
            if (operand.Length > sumWord[0].Length) throw new ArgumentException();
        }

        HashSet<char> LeftSideLetters = operands.SelectMany(x => x).ToHashSet();
        HashSet<char> RightSideLetters = sumWord[0].ToHashSet();

        (char letter, long factor)[] leftSideSimplified = LetterFactors(LeftSideLetters, operands);
        (char letter, long factor)[] rightSideSimplified = LetterFactors(RightSideLetters, sumWord);



        int[][] permutations = Enumerable.Range(0, 10)
        .ToArray()
        .Permutations(uniqueLetters.Count)
        .ToArray();

        Dictionary<char, int> letterDigits = new Dictionary<char, int>();
        long leftSideValue = 0;
        long rightSideValue = 1;
        bool leadingZero;
        int i = 0;
        do
        {
            leadingZero = false;


            letterDigits = uniqueLetters
                .Select<char, (char letter, int digit)>((l, j) => (l, permutations[i][j]))
                .ToDictionary(p => p.letter, p => p.digit);
            i++;

            foreach (char letter in nonZeroLetters)
            {
                if (letterDigits[letter] == 0) leadingZero = true;
            }
            if (leadingZero) continue;

            leftSideValue = leftSideSimplified.Sum(x => x.factor * letterDigits[x.letter]);
            rightSideValue = rightSideSimplified.Sum(x => x.factor * letterDigits[x.letter]);

        } while (leftSideValue != rightSideValue || leadingZero);

        return letterDigits;
    }
}

public static class EnumerableExtensions
{
    public static IEnumerable<T[]> Permutations<T>(this T[] source, int length) =>
        length == 1
            ? source.Select(t => new[] { t })
            : source.Permutations(length - 1)
            .SelectMany(t => source.Where(o => !t.Contains(o)),
                (t1, t2) => t1.Concat(new T[] { t2 }).ToArray());
}
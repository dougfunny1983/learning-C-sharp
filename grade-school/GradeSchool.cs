using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly SortedList<int, SortedSet<string>> _collection = new SortedList<int, SortedSet<string>>();
    public void Add(string student, int grade)
    {
        try
        {
            _collection.Add(grade, new SortedSet<string>() { student });
        }
        catch (ArgumentException)
        {
            _collection[grade].Add(student);
        }
    }

    public IEnumerable<string> Roster() => _collection.Values.SelectMany(x => x);

    public IEnumerable<string> Grade(int grade)
    {
        try
        {
            return _collection[grade];
        }
        catch (KeyNotFoundException)
        {
            return Array.Empty<string>();
        }

    }

}

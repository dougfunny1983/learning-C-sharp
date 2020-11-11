using System;
using System.Collections.Generic;
using System.Threading;

public class Robot
{
    public string Name;

    public Robot() => Name = RobotNameGenerator.Instance.Generate();
    public void Reset() => Name = RobotNameGenerator.Instance.Generate();
}

//Singleton simple thread-safety
internal class RobotNameGenerator
{
    private ConcurrentHashSet<string> HashRobotNames = new ConcurrentHashSet<string>();

    private static Random _random = new Random();

    private static RobotNameGenerator instance = null;

    private static readonly object padlock = new object();

    private RobotNameGenerator() { }

    public static RobotNameGenerator Instance
    {
        get
        {
            lock (padlock)
            {
                return instance ??= new RobotNameGenerator();
            }
        }
    }


    public string Generate()
    {

        string nameRobot = RandomNameRobot();

        if (instance.HashRobotNames.Contains(nameRobot)) return Generate();

        instance.HashRobotNames.Add(nameRobot);

        return nameRobot;
    }

    private static string RandomAlphaNumeric(int flag = 0)
    => flag switch
    {
        0 => new string(((char)('A' + _random.Next(26))).ToString()),
        1 => _random.Next(1000).ToString("000"),
        _ => throw new NotImplementedException(),
    };

    private static string RandomNameRobot() =>
        new string(RandomAlphaNumeric() + RandomAlphaNumeric() + RandomAlphaNumeric(1));

}


//stackoverflow - How to implement ConcurrentHashSet in .Net? author Ben Mosher
public class ConcurrentHashSet<T> : IDisposable
{
    private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
    private readonly HashSet<T> _hashSet = new HashSet<T>();

    #region Implementation of ICollection<T> ...ish
    public bool Add(T item)
    {
        try
        {
            _lock.EnterWriteLock();
            return _hashSet.Add(item);
        }
        finally
        {
            if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
        }
    }

    public void Clear()
    {
        try
        {
            _lock.EnterWriteLock();
            _hashSet.Clear();
        }
        finally
        {
            if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
        }
    }

    public bool Contains(T item)
    {
        try
        {
            _lock.EnterReadLock();
            return _hashSet.Contains(item);
        }
        finally
        {
            if (_lock.IsReadLockHeld) _lock.ExitReadLock();
        }
    }

    public bool Remove(T item)
    {
        try
        {
            _lock.EnterWriteLock();
            return _hashSet.Remove(item);
        }
        finally
        {
            if (_lock.IsWriteLockHeld) _lock.ExitWriteLock();
        }
    }

    public int Count
    {
        get
        {
            try
            {
                _lock.EnterReadLock();
                return _hashSet.Count;
            }
            finally
            {
                if (_lock.IsReadLockHeld) _lock.ExitReadLock();
            }
        }
    }
    #endregion

    #region Dispose
    public void Dispose()
    {
        if (_lock != null) _lock.Dispose();
    }
    #endregion
}

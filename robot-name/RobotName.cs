using System;
using System.Collections.Generic;

public class Robot
{
    public string Name;

    public Robot() => Name = RobotNameGenerator.Instance.Generate();
    public void Reset() => Name = RobotNameGenerator.Instance.Generate();
}

//Singleton simple thread-safety
internal class RobotNameGenerator
{
    public HashSet<string> HashRobotNames = new HashSet<string>();

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

        while (instance.HashRobotNames.Contains(nameRobot))
            nameRobot = RandomNameRobot();

        instance.HashRobotNames.Add(nameRobot);
        return nameRobot;
    }

    public static string RandomAlphaNumeric(int flag = 0)
    => flag switch
    {
        0 => new string(((char)('A' + new Random().Next(26))).ToString()),
        1 => new Random().Next(1000).ToString("000"),
        _ => throw new NotImplementedException(),
    };

    private static string RandomNameRobot() =>
        new string(RandomAlphaNumeric() + RandomAlphaNumeric() + RandomAlphaNumeric(1));

}

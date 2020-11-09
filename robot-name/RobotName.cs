using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    public string Name;

    public Robot() => Name = RobotNameGenerator.Instance.Generate();
    public void Reset() => Name = RobotNameGenerator.Instance.Generate();
}

//Singleton simple thread-safety
internal class RobotNameGenerator
{
    public HashSet<string> NomesUtilizados = new HashSet<string>();

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
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string number = "0123456789";
        string nameRobot = randomNameRobot(chars, number);

        while (instance.NomesUtilizados.Contains(nameRobot))
            nameRobot = randomNameRobot(chars, number);

        instance.NomesUtilizados.Add(nameRobot);
        return nameRobot;
    }


    private static string RandomAlphanumeric(string flag, int loops = 3) => new string(
            Enumerable.Repeat(flag, loops)
                      .Select(str => str[new Random().Next(str.Length)])
                      .ToArray());

    private static string randomNameRobot(string chars, string number) =>
        RandomAlphanumeric(chars, 2) + RandomAlphanumeric(number);

}

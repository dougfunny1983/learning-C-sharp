using System;
using System.Collections.Generic;

public class SpaceAge
{
    private readonly double _seconds;
    private static readonly double yearSecondsEarth = 86400.00;
    private static readonly double earthDays = 365.25;

    private static readonly Dictionary<string, double> orbital = new Dictionary<string, double>()
{
    { "Earth", 1.0 },
    { "Mercury", 0.2408467  },
    { "Venus", 0.61519726 },
    { "Mars", 1.8808158 },
    { "Jupiter", 11.862615 },
    { "Saturn", 29.447498  },
    { "Uranus", 84.016846 },
    { "Neptune", 164.79132 }
};

    public SpaceAge(int seconds) => _seconds = seconds;

    private static double calculate(double inputSeconds, double earthOrabitalPeriod) 
    {
        double secondsInYear = earthOrabitalPeriod * earthDays * yearSecondsEarth;
        double earthOldYear = inputSeconds / secondsInYear;
        return Math.Round(earthOldYear * 100, 2) / 100;
    }

    public double OnEarth() => calculate(_seconds, orbital["Earth"]);

    public double OnMercury() => calculate(_seconds, orbital["Mercury"]);

    public double OnVenus() => calculate(_seconds, orbital["Venus"]);

    public double OnMars() => calculate(_seconds, orbital["Mars"]);

    public double OnJupiter() => calculate(_seconds, orbital["Jupiter"]);

    public double OnSaturn() => calculate(_seconds, orbital["Saturn"]);

    public double OnUranus() => calculate(_seconds, orbital["Uranus"]);

    public double OnNeptune() => calculate(_seconds, orbital["Neptune"]);
}
using System;

namespace Manager.Scripts.Math;

public class NormalDistribution
{
    private readonly Random _random = new();

    public double GetNormal(double mean, double variance)
    {
        // Box-Muller transform to generate a standard normal distributed value
        double u1 = _random.NextDouble(); // Uniform(0,1) random double
        double u2 = _random.NextDouble();
        double stdNormal = System.Math.Sqrt(-2.0 * System.Math.Log(u1)) * System.Math.Cos(2.0 * System.Math.PI * u2);
        
        // Scale and translate to match the desired mean and variance
        return mean + stdNormal * System.Math.Sqrt(variance);
    }

    public int GetNormalInt(double mean, double variance)
    {
        return (int) System.Math.Round(
            GetNormal(mean, variance));
    }
}
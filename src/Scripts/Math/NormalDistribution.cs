using System;

namespace DefaultNamespace.MathLib;

public class NormalDistribution
{
    private Random _random;

    public NormalDistribution()
    {
        _random = new Random();
    }

    public double GetNormal(double mean, double variance)
    {
        // Box-Muller transform to generate a standard normal distributed value
        double u1 = _random.NextDouble(); // Uniform(0,1) random double
        double u2 = _random.NextDouble();
        double stdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
        
        // Scale and translate to match the desired mean and variance
        return mean + stdNormal * Math.Sqrt(variance);
    }
}
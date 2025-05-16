using System;

namespace DefaultNamespace;

public class Runner
{
    public string name;
    public double fitness;
    public double trainingFatigue;
    public double fatigueResistance;
    public double hillSkill;
    public double injuryProbability;
    public int money;

    public Runner(string name)
    {
        this.name = name;
        Random random = new Random();
        fitness = random.NextDouble() * 50;
        trainingFatigue = 0;
        fatigueResistance = 0;
        hillSkill = 0;
        injuryProbability = 0.5;
        money = (int)(random.NextDouble() * 1000);
    }

    public double Run(double distance, double elevation)
    {
        return distance *
               7 / fitness * // average pace
               Math.Pow(1.1 - fatigueResistance / 10, distance) * // distance penalty
               Math.Pow(1.1 - hillSkill / 10, elevation / 100); // elevation penalty
    }

}
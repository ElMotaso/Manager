using System;

namespace DefaultNamespace;

public class Runner
{
    public string name;
    public double fitness;
    public double fatigue;
    public double fatigue_resistance;
    public double hill_skill;
    public double injury_probability;
    public int money;

    public Runner(string name)
    {
        this.name = name;
        Random random = new Random();
        fitness = random.NextDouble() * 50;
        fatigue = 0;
        fatigue_resistance = 0;
        hill_skill = 0;
        injury_probability = 0.5;
        money = (int)(random.NextDouble() * 1000);
    }

    public double run(double distance, double elevation)
    {
        return distance *
               7 / fitness * // average pace
               Math.Pow(1.1 - fatigue_resistance / 10, distance) * // distance penalty
               Math.Pow(1.1 - hill_skill / 10, elevation / 100); // elevation penalty
    }

}
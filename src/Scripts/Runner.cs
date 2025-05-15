namespace DefaultNamespace;

public class Runner
{
    public string name;
    private float fitness;
    private float fatigue;
    public float fatigue_resistance;
    public float hill_skill;
    private float injury_probability;
    private int money;

    public Runner(sring name)
    {
        this.name = name;
        Random random = new Random();
        fitness = random.NextDouble() * 50;
        fatigue = 0;
        fatigue_resistance = 0;
        hill_skill = 0;
        injury_probability = 0.5;
        money = random.NextDouble() * 1000;
    }

    public float run(distance: float, elevation: float)
    {
        return distance *
               7 / fitness * // average pace
               Math.Pow(1.1 - fatigue_resistance / 10, distance) * // distance penalty
               Math.Pow(1.1 - hill_skill / 10, elevation / 100); // elevation penalty
    }

}
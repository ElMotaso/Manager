using System;
using DefaultNamespace.MathLib;

namespace Manager.Scripts;

public partial class Runner // Ideen und bisschen ausgebaute Teile der Klasse in RunnerDeprecated
{
    public string Name { get; set; }
    public int Money { get; set; }

    private double _fitness;
    private double _fatigue;


    public Runner(string name)
    {
        this.Name = name;
        NormalDistribution normalDistribution = new NormalDistribution();
        _fitness = normalDistribution.GetNormal(100, 100);
        _fatigue = 0;
        Money = (int)normalDistribution.GetNormal(5000, 3000);
    }
    
    public Runner(string name, double fitness, double fatigue, int money)
    {
        this.Name = name;
        this._fitness = fitness;
        this._fatigue = fatigue;
        this.Money = money;
    }

    private double GetAveragePace() // in minutes per km
    {
        return 7 / _fitness;
    }
    
    
    private double GetFinishTime(Segment segment)
    {
        return segment.Distance *
               GetAveragePace();
    }

    private double CalculateFatigue(Segment segment)
    {
        double addedFatigue = segment.CalculateDifficultyScore();
        return _fatigue + addedFatigue;
    }

    public void UpdateRunnerStats(Segment segment)
    {
        _fatigue = CalculateFatigue(segment);
    }
    
    public double Run(Segment segment)
    {
        UpdateRunnerStats(segment);
        return GetFinishTime(segment);
    }

}
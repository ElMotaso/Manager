using System;
using DefaultNamespace.MathLib;
using Manager.Scripts.Runs;

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
    
    
    private double GetFinishTime(IRun run)
    {
        return run.getDistance() *
               GetAveragePace();
    }

    private double CalculateFatigue(IRun run)
    {
        double addedFatigue = run.CalculateDifficultyScore();
        return _fatigue + addedFatigue;
    }

    public void UpdateRunnerStats(IRun run)
    {
        _fatigue = CalculateFatigue(run);
    }
    
    public double Run(IRun run)
    {
        UpdateRunnerStats(run);
        return GetFinishTime(run);
    }

}
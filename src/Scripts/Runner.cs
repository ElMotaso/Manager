using System;
using DefaultNamespace.MathLib;

namespace Manager.Scripts;

public class Runner
{
    public string Name { get; set; }

    private double _fitness;
    private double _fatigue;
    private double _fatigueResistance;
    private double _hillSkill;
    private double _injuryProbability;
    private double _fatigueInterest = 1.05;

    public int Money { get; set; }

    public Runner(string name)
    {
        this.Name = name;
        NormalDistribution normalDistribution = new NormalDistribution();
        _fitness = normalDistribution.GetNormal(100, 100);
        _fatigue = 0;
        _fatigueResistance = 1;
        _hillSkill = 0;
        _injuryProbability = 0.5;
        Money = (int)normalDistribution.GetNormal(5000, 3000);
    }
    
    public Runner(string name, double fitness, double fatigue, double fatigueResistance, double hillSkill,
        double injuryProbability, int money)
    {
        this.Name = name;
        this._fitness = fitness;
        this._fatigue = fatigue;
        this._fatigueResistance = fatigueResistance;
        this._hillSkill = hillSkill;
        this._injuryProbability = injuryProbability;
        this.Money = money;
    }

    private double GetAveragePace() // in minutes per km
    {
        return 7 / _fitness;
    }

    private double GetDistancePenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _fatigueResistance / 10, run.DistanceDifficultyScore);
    }

    private double GetElevationPenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _hillSkill / 10, run.HillDifficultyScore / 100);
    }

    private double GetRoutePenaltyFactor(Run run)
    {
        return GetDistancePenaltyFactor(run) * GetElevationPenaltyFactor(run);
    }

    private double GetRunnerReadienessFactor()
    {
        return 1 / _fatigue;
    }

    private double GetFinishTime(Run run)
    {
        return run.Distance *
               GetAveragePace() *
               GetRoutePenaltyFactor(run) *
               GetRunnerReadienessFactor();
    }

    private double CalculateFatigue(Run run)
    {
        double addedFatigue = _fatigue * _fatigueInterest
                              + run.DistanceDifficultyScore 
                              + run.HillDifficultyScore / 10 / _hillSkill;
        return _fatigue + addedFatigue * _fatigueResistance;
    }

    private bool GetsInjured(Run run)
    {
        return false;
    }
    
    public double Run(Run run)
    {
        _fatigue = CalculateFatigue(run);
        return GetFinishTime(run);
    }

}
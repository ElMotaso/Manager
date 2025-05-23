using System;
using DefaultNamespace.MathLib;

namespace Manager.Scripts;

public class Runner
{
    public string Name { get; set; }
    public int Money { get; set; }

    private double _fitness;
    private double _fatigue;
    //private double _fatigueResistance;
    //private double _hillSkill;
    //private double _injuryProbability;
    //private double _fatigueInterest = 1.05;


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
               GetAveragePace(); // * GetRoutePenaltyFactor(run) * GetRunnerReadienessFactor();
    }

    private double CalculateFatigue(Segment segment)
    {
        double addedFatigue = segment.CalculateDifficultyScore();
                              /* + _fatigue * _fatigueInterest
                                + run.DistanceDifficultyScore
                                + run.HillDifficultyScore / 10 / _hillSkill; */
        return _fatigue + addedFatigue; // * _fatigueResistance;
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

    /*
     private double GetDistancePenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _fatigueResistance / 10, run.DistanceDifficultyScore);
    }
    */

    /*
     private double GetElevationPenaltyFactor(Run run)
    {
        return Math.Pow(1.1 - _hillSkill / 10, run.HillDifficultyScore / 100);
    }
    */

    /*
    private double GetRoutePenaltyFactor(Run run)
    {
        return GetDistancePenaltyFactor(run) * GetElevationPenaltyFactor(run);
    }
    */

    /*
    private double GetRunnerReadienessFactor()
    {
        return 1 / _fatigue;
    }
    */
}
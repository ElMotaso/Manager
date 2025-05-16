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

    private double GetDistancePenaltyFactor(double distance)
    {
        return Math.Pow(1.1 - _fatigueResistance / 10, distance);
    }

    private double GetElevationPenaltyFactor(double elevation)
    {
        return Math.Pow(1.1 - _hillSkill / 10, elevation / 100);
    }

    private double GetRoutePenaltyFactor(double distance, double elevation)
    {
        return GetDistancePenaltyFactor(distance) * GetElevationPenaltyFactor(elevation);
    }

    private double GetRunnerReadienessFactor()
    {
        return 1 / _fatigue;
    }

    private double GetFinishTime(double distance, double elevation)
    {
        return distance *
               GetAveragePace() *
               GetRoutePenaltyFactor(distance, elevation) *
               GetRunnerReadienessFactor();
    }

    private double CalculateFatigue(double distance, double elevation)
    {
        double addedFatigue = _fatigue * _fatigueInterest
                              + distance 
                              + elevation / 10 / _hillSkill;
        return _fatigue + addedFatigue * _fatigueResistance;
    }

    private bool GetsInjured(double distance, double elevation)
    {
        return true;
    }
    
    public double Run(double distance, double elevation)
    {
        _fatigue = CalculateFatigue(distance, elevation);
        return GetFinishTime(distance, elevation);
    }

}
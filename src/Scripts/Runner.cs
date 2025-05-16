using System;
using DefaultNamespace.MathLib;

namespace DefaultNamespace;

public class Runner
{
    private string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    private double _fitness;
    private double _trainingFatigue;
    private double _fatigueResistance;
    private double _hillSkill;
    private double _injuryProbability;
    private int _money;

    public int Money
    {
        get => _money;
        set => _money = value;
    }

    public Runner(string name)
    {
        this._name = name;
        NormalDistribution normalDistribution = new NormalDistribution();
        _fitness = normalDistribution.GetNormal(100, 100);
        _trainingFatigue = 0;
        _fatigueResistance = 0;
        _hillSkill = 0;
        _injuryProbability = 0.5;
        _money = (int)normalDistribution.GetNormal(5000, 3000);
    }
    
    public Runner(string name, double fitness, double trainingFatigue, double fatigueResistance, double hillSkill,
        double injuryProbability, int money)
    {
        this._name = name;
        this._fitness = fitness;
        this._trainingFatigue = trainingFatigue;
        this._fatigueResistance = fatigueResistance;
        this._hillSkill = hillSkill;
        this._injuryProbability = injuryProbability;
        this._money = money;
    }

    public double getAveragePace() // in minutes per km
    {
        return 7 / _fitness;
    }

    public double getDistancePenaltyFactor(double distance)
    {
        return Math.Pow(1.1 - _fatigueResistance / 10, distance);
    }

    public double getElevationPenaltyFactor(double elevation)
    {
        return Math.Pow(1.1 - _hillSkill / 10, elevation / 100);
    }

    public double getRoutePenaltyFactor(double distance, double elevation)
    {
        return getDistancePenaltyFactor(distance) * getElevationPenaltyFactor(elevation);
    }

    public double getRunnerReadienessFactor()
    {
        return 1;
    }

    public double getFinishTime(double distance, double elevation)
    {
        return distance *
               getAveragePace() *
               getRoutePenaltyFactor(distance, elevation) *
               getRunnerReadienessFactor();
    }
    
    public double Run(double distance, double elevation)
    {
        return getFinishTime(distance, elevation);
    }

}
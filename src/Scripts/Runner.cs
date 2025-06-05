using System;
using Godot;
using Manager.Scripts.Math;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Runner : Node // Ideen und bisschen ausgebaute Teile der Klasse in RunnerDeprecated
{

    private string _name;
    private double _fatigue;
    private int _money;
    private double _fitness;

    public new string Name
    {
        get => _name;
        set => _name = value;
    }
    public double Fitness
    {
        get => _fitness;
        set => _fitness = value;
    }
    public int Money
    {
        get => _money;
        set => _money = value;
    }
    public double Fatigue
    {
        get => _fatigue;
        set => _fatigue = value;
    }

    


    public Runner()
    {
        _name = "Thomas";
        NormalDistribution normalDistribution = new NormalDistribution();
        _fitness = normalDistribution.GetNormal(100, 5);
        _fatigue = 0;
        _money = (int)normalDistribution.GetNormal(5000, 3000);
    }
    
    public Runner(string name) : this()
    {
        _name = name;
    }
    
    public Runner(string name, double fitness, double fatigue, int money)
    {
        _name = name;
        _fitness = fitness;
        _fatigue = fatigue;
        _money = money;
    }
    
    private double GetAveragePace() // in minutes per km
    {
        return 7 / (_fitness/100);
    }
    
    
    private double GetFinishTime(IRun run)
    {
        return run.Distance() *
               GetAveragePace();
    }

    private double CalculateFatigue(IRun run)
    {
        double addedFatigue = run.CalculateDifficultyScore() / _fitness;
        return _fatigue + addedFatigue;
    }

    private double CalculateNewFitness(IRun run)
    {
        return _fitness + run.CalculateDifficultyScore() / _fitness;
    }

    protected virtual void UpdateUi()
    {
        
    }

    private void UpdateRunnerStats(IRun run)
    {
        _fatigue = CalculateFatigue(run);
        _fitness = CalculateNewFitness(run);
        UpdateUi();
    }
    
    public double Run(IRun run, bool isSprint = false)
    {
        if (run.Distance() == 0)
        {
            Console.WriteLine("Restday");
            UpdateRunnerStats(run);
            return 0;
        }
        Console.WriteLine(_name + " " + (isSprint ? "sprinted" : "jogged") + " " + run.Distance() + " km and " + run.Elevation() + " m with a difficulty of " + run.GroundDifficulty() + "!");
        Console.WriteLine("In " + GetFinishTime(run) + " minutes.");
        UpdateRunnerStats(run);
        return GetFinishTime(run);
    }

    public void Recover()
    {
        if (_fatigue > 100)
        {
            _fatigue -= 1;
        }
        else if (_fatigue > 75)
        {
            _fatigue *= 0.99;
        }
        else if (_fatigue > 50)
        {
            _fatigue *= 0.95;
        }
        else
        {
            _fatigue *= 0.9;
        }

        UpdateUi();
    }

}
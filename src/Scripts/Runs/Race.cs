using Godot;
using Manager.Scripts.Math;

namespace Manager.Scripts.Runs;

public partial class Race : Route
{
    private readonly double _entryFee;
    private readonly Runner[] _runners;
    private int _daysLeft;

    public int DaysLeft
    {
        get => _daysLeft;
        set => _daysLeft = value;
    }

    public Race(int daysLeft, double entryFee, Runner[] runners, double distance, double elevation, double groundDifficulty = 1)
    : base(distance, elevation, groundDifficulty)
    {
        _entryFee = entryFee;
        _runners = runners;
        _daysLeft = daysLeft;
    }

    public Race(Runner[] runners = null)
    {
        NormalDistribution normalDistribution = new NormalDistribution();
        _daysLeft = normalDistribution.GetNormalInt(14, 4);
        _entryFee = normalDistribution.GetNormal(150, 30);
        if (runners == null)
        {
            _runners = [new Runner("Leo"), new Runner("Marcel")];
        }
        else
        {
            _runners = runners;
        }
    }
    
    public void NextDay()
    {
        _daysLeft--;
    }

    public bool IsOver()
    {
        return _daysLeft < 0;
    }

    public bool IsToday()
    {
        return _daysLeft == 0;
    }


    public string Start()
    {
        if (_daysLeft > 0)
        {
            return "Not today";
        }
        else if (_daysLeft < 0)
        {
            return "You missed the invasion Aang";
        }
        
        double bestTime = float.MaxValue;
        Runner winner = null;
        string raceResults = "";
        
        foreach (Runner runner in _runners)
        {
            runner.Money -= (int)(_entryFee);
            runner.Run(this);
            double finishTime = runner.GetFinishTime(this);
            raceResults += $"{runner.Name}: {finishTime}\n";
            if (finishTime < bestTime)
            {
                bestTime = finishTime;
                winner = runner;
            }
        }
        raceResults += (winner == null) ? "No winners in war" : $"Winner: {winner.Name}";
        return raceResults;
    }
    
    public string GetStatsText()
    {
        return "Race\nDistance: " + Distance() + "km\nElevation: " + Elevation() +
               "m\nGround Difficulty: " + GroundDifficulty() + "\nDays till race: " + _daysLeft;
    }
}
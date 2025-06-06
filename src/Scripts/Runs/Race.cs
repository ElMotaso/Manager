using Godot;

namespace Manager.Scripts.Runs;

public partial class Race : Route
{
    private readonly double _entryFee;
    private readonly Runner[] _runners;

    public Race(double entryFee, Runner[] runners, double distance, double elevation, double groundDifficulty = 1)
    : base(distance, elevation, groundDifficulty)
    {
    _entryFee = entryFee;
    _runners = runners;
    }

    public Race()
    {
    }

    public string Start()
    {
        double bestTime = float.MaxValue;
        Runner winner = null;
        string raceResults = "";
        
        foreach (Runner runner in _runners)
        {
            runner.Money -= (int)(_entryFee);
            double finishTime = runner.Run(this);
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
}
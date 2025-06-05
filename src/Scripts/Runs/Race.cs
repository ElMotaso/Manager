using Godot;

namespace Manager.Scripts.Runs;

public class Race : IRun
{
    private readonly double _entryFee;
    private readonly Runner[] _runners;
    private readonly IRun _run;

    public Race(double entryFee, Runner[] runners, IRun run)
    {
        _entryFee = entryFee;
        _runners = runners;
        _run = run;
    }
    
    private string Start()
    {
        double bestTime = float.MaxValue;
        string winner = "";
        
        foreach (Runner runner in _runners)
        {
            runner.Money -= (int)(_entryFee);
            double finishTime = runner.Run(_run);
            GD.Print($"{runner.Name}: {finishTime}");
            if (finishTime < bestTime)
            {
                bestTime = finishTime;
                winner = runner.Name;
            }
        }
        return winner;
    }
    
    public void PrintRaceResults()
    {
        string winner = Start();
        GD.Print($"Race winner: {winner}");
    }
    
    public double CalculateDifficultyScore()
    {
        return _run.CalculateDifficultyScore();
    }

    public double Distance() => _run.Distance();
    public double Elevation() => _run.Elevation();
    public double GroundDifficulty() => _run.GroundDifficulty();
}
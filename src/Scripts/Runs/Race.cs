using Godot;

namespace Manager.Scripts.Runs;

public class Race : IRun
{
    private double _entryFee;
    private Runner[] _runners;
    private IRun run;

    public Race(double entryFee, Runner[] runners, IRun run)
    {
        this._entryFee = entryFee;
        this._runners = runners;
        this.run = run;
    }
    
    private string Start()
    {
        double bestTime = float.MaxValue;
        string winner = "";
        
        foreach (Runner runner in _runners)
        {
            runner.Money -= (int)(_entryFee);
            double finishTime = runner.Run(run);
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
        return run.CalculateDifficultyScore();
    }

    public double getDistance()
    {
        return run.getDistance();
    }
}
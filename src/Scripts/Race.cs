using Godot;

namespace Manager.Scripts;

public class Race : Segment
{
    private double _entryFee;
    private Runner[] _runners;

    public Race(double distance, double elevation, double entryFee, Runner[] runners, double groundDifficulty = 1) : base(distance, elevation, groundDifficulty)
    {
        this._entryFee = entryFee;
        this.Distance = distance;
        this.Elevation = elevation;
        this._runners = runners;
    }
    
    private string Start()
    {
        double bestTime = float.MaxValue;
        string winner = "";
        
        foreach (Runner runner in _runners)
        {
            runner.Money -= (int)(_entryFee);
            double finishTime = runner.Run(this);
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
}
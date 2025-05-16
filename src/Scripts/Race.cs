using Godot;

namespace DefaultNamespace;

public class Race
{
    private double entryFee;
    private double distance;
    private double elevation;
    private Runner[] runners;

    public Race(double entryFee, double distance, double elevation, Runner[] runners)
    {
        this.entryFee = entryFee;
        this.distance = distance;
        this.elevation = elevation;
        this.runners = runners;
    }
    
    private string startRace()
    {
        double bestTime = float.MaxValue;
        string winner = "";
        
        foreach (Runner runner in runners)
        {
            runner.money -= (int)(entryFee);
            double finishTime = runner.Run(distance, elevation);
            GD.Print($"{runner.name}: {finishTime}");
            if (finishTime < bestTime)
            {
                bestTime = finishTime;
                winner = runner.name;
            }
        }
        return winner;
    }
    
    public void PrintRaceResults()
    {
        string winner = startRace();
        GD.Print($"Race winner: {winner}");
    }
}
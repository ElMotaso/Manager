using System;
using DefaultNamespace;
using Godot;

public partial class Main : Node2D
{
    private Runner Leo = new Runner("Leo");
    private Runner Thomas = new Runner("Thomas");
    private Runner Marcel = new Runner("Marcel");
    
    public override void _Ready()
    {
        GD.Print("Main Script is Ready!");
        PrintRaceResults();
    }
    
    private string race(float entry_fee, float distance, float elevation, Runner[] runners)
    {
        double bestTime = float.MaxValue;
        string winner = "";
        
        foreach (Runner runner in runners)
        {
            runner.money -= (int)(entry_fee);
            double finishTime = runner.run(distance, elevation);
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
        Runner[] runners = new Runner[] { Leo, Thomas, Marcel };
        string winner = race(10.0f, 1000.0f, 100.0f, runners);
        Console.WriteLine($"Race winner: {winner}");
    }
}
using Godot;
using System;
using DefaultNamespace;

public partial class Button : Godot.Button
{
    private Runner Leo = new Runner("Leo");
    private Runner Thomas = new Runner("Thomas");
    private Runner Marcel = new Runner("Marcel");
    
    public void _on_button_down()
    {
        GD.Print("Main Script is Ready!");
        PrintRaceResults();
    }
    
    private string Race(float entryFee, float distance, float elevation, Runner[] runners)
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
        Runner[] runners = new Runner[] { Leo, Thomas, Marcel };
        string winner = Race(10.0f, 1000.0f, 100.0f, runners);
        GD.Print($"Race winner: {winner}");
    }
}

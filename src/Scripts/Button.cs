using Godot;
using System;
using DefaultNamespace;
using Manager.Scripts;
using Manager.Scripts.Runs;

public partial class Button : Godot.Button
{
    
    public void _on_button_down()
    {
        GD.Print("Main Script is Ready!");
        Race race = new Race(10, 
            getRunners(), 
            new Segment(10, 100, 1));
        race.PrintRaceResults();
    }

    public Runner[] getRunners()
    {
        Runner Leo = new Runner("Leo");
        Runner Thomas = new Runner("Thomas");
        Runner Marcel = new Runner("Marcel");
        Runner[] runners = new Runner[] { Leo, Thomas, Marcel };
        return runners;
    }
}

using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class RaceButton : Button
{
    
    private void _on_button_down()
    {
        GD.Print("Main Script is Ready!");
        Runs.Race race = new Runs.Race(10, 
            GetRunners(), 
            new Segment(10, 180, 1.7));
        race.PrintRaceResults();
    }

    private Runner[] GetRunners()
    {
        Runner leo = new Runner("Leo");
        Runner thomas = new Runner("Thomas");
        Runner marcel = new Runner("Marcel");
        Runner[] runners = [leo, thomas, marcel];
        return runners;
    }
}
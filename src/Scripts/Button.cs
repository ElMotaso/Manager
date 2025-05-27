using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Button : Godot.Button
{
    
    private void _on_button_down()
    {
        GD.Print("Main Script is Ready!");
        Race race = new Race(10, 
            GetRunners(), 
            new Segment(10, 100, 1));
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
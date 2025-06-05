using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class RaceButton : Button
{
    
    private void _on_button_down()
    {
        GD.Print("The Race begins!");
        Race race = new Race(10, 
            GetRunners(), 10, 180, 1.7);
        race.Start();
        race.PrintRaceResults();
    }

    private Runner[] GetRunners()
    {
        Runner leo = new Runner("Leo");
        Runner marcel = new Runner("Marcel");
        Runner[] runners = [leo, marcel, GetParent<Main>().GetPlayer()];
        return runners;
    }
}
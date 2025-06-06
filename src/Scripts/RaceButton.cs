using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class RaceButton : Button
{
    
    [Signal] delegate void ReturnRaceResultsEventHandler(string raceResults);
    
    private void _on_button_down()
    {
        string raceResults = "The Race begins!\n";
        Race race = new Race(10, 
            GetRunners(), 10, 180, 1.7);
        raceResults += race.Start();
        EmitSignalReturnRaceResults(raceResults);
    }

    private Runner[] GetRunners()
    {
        Runner leo = new Runner("Leo");
        Runner marcel = new Runner("Marcel");
        Runner[] runners = [leo, marcel, GetParent<Main>().GetPlayer()];
        return runners;
    }
}
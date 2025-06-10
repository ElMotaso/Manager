using System.Diagnostics;
using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Main : Node
{
    [Export] private NodePath _playerPath;
    private Player _player;
    [Export] private NodePath _runPath;
    private Run _run;
    [Export] private NodePath _racePath;
    private Button _raceButton;
    private Race _race;
    private Runner[] _runners;
    
    public override void _Ready()
    {
        _player = GetNode<Player>(_playerPath);
        _raceButton = GetNode<Button>(_racePath);
        _run = GetNode<Run>(_runPath);
        _runners = [new Runner("Leo"), new Runner("Marcel"), _player];
        CreateNewRace();
    }

    private void CreateNewRace()
    {
        _race = new Race(_runners);
        UpdateRaceStats();
    }

    public void GetPlayerToRun(Route route, bool isSprint)
    {
        StartNextDay();
        GetNode<TextEdit>("RaceResults").Text = _player.Run(route, isSprint);
    }
    
    private void StartNextDay()
    {
        _race.NextDay();
        _player.Recover();
        if (_race.IsOver())
        {
            CreateNewRace();
        }
        UpdateRaceStats();
    }

    private void UpdateRaceStats()
    {
        _raceButton.Text = _race.GetStatsText();
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public Race GetRace()
    {
        return _race;
    }

    private void _on_race_button_return_race_results(string raceResults)
    {
        if (!_race.IsToday())
        {
            return;
        }
        GetNode<TextEdit>("RaceResults").Text = raceResults;
        CreateNewRace();
    }
}
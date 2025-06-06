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
    [Export] private int _daysTillRace;
    [Export] private int _raceDistance;
    [Export] private int _raceElevation;
    [Export] private double _raceGroundDifficulty;
    
    private Button _raceButton;
    
    public override void _Ready()
    {

        _player = GetNode<Player>(_playerPath);
        _raceButton = GetNode<Button>(_racePath);
        _run = GetNode<Run>(_runPath);
        UpdateRaceStats();
    }

    public void GetPlayerToRun(Route route, bool isSprint)
    {
        StartNextDay();
        GetNode<TextEdit>("RaceResults").Text = _player.Run(route, isSprint);
    }
    
    private void StartNextDay()
    {
        _daysTillRace--;
        _player.Recover();
        UpdateRaceStats();
        if (_daysTillRace == 0)
        {
            _run.DisableRunButton();
        }
    }

    private void UpdateRaceStats()
    {
        _raceButton.Text = "Race\nDistance: " + _raceDistance + "km\nElevation: " + _raceElevation +
                           "m\nGround Difficulty: " + _raceGroundDifficulty + "\nDays till race: " + _daysTillRace;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    private void _on_race_button_return_race_results(string raceResults)
    {
        GetNode<TextEdit>("RaceResults").Text = raceResults;
    }
}
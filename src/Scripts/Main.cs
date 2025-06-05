using System.Diagnostics;
using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Main : Node
{
    [Export] private NodePath _playerPath;
    private Player _player;
    [Export] private NodePath _racePath;
    [Export] private int _daysTillRace;
    [Export] private int _raceDistance;
    [Export] private int _raceElevation;
    [Export] private int _raceGroundDifficulty;
    
    private Button _raceButton;
    
    public override void _Ready()
    {

        _player = GetNode<Player>(_playerPath);
        _raceButton = GetNode<Button>(_racePath);
        _raceButton.Text = "Race\nDistance: " + _raceDistance + "km\nElevation: " + _raceElevation +
                           "m\nGround Difficulty: " + _raceGroundDifficulty + "\nDays till race: " + _daysTillRace;
    }

    public void GetPlayerToRun(Route route, bool isSprint)
    {
        _player.Run(route, isSprint);
    }
}
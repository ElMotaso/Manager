using System;
using Godot;
using Manager.Scripts;

public partial class Main : Node
{
    private Runner _player;
    [Export] private NodePath _racePath;
    [Export] private int _daysTillRace;
    [Export] private int _raceDistance;
    [Export] private int _raceElevation;
    [Export] private int _raceGroundDifficulty;
    
    private Button _raceButton;
    
    public override void _Ready()
    {
        _raceButton = GetNode<Button>(_racePath);
        _raceButton.Text = "Race\nDistance: " + _raceDistance + "km\nElevation: " + _raceElevation +
                           "m\nGround Difficulty: " + _raceGroundDifficulty + "\nDays till race: " + _daysTillRace;
    }
}
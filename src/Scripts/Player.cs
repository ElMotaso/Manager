using System;
using Godot;
using Manager.Scripts.Math;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Player : Runner
{
    [Export] private NodePath _statsBoxPath;
    private TextEdit _statsBox;

    public override void _Ready()
    {
        _statsBox = GetNode<TextEdit>(_statsBoxPath);
        _statsBox.Text = CreateStatsBoxText();
    }

    private string CreateStatsBoxText()
    {
        return "Name: " + Name + 
               "\nFitness: " + Fitness + 
               "\nMoney: " + Money + 
               "\nFatigue: " + Fatigue;
    }

    protected override void UpdateUi()
    {
        _statsBox.Text = CreateStatsBoxText();
    }
}
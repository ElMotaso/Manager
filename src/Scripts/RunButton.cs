using Godot;
using Manager.Scripts.Runs;
using Manager.Scripts.Slider;

namespace Manager.Scripts;

public partial class RunButton : Button
{
    [Export] private NodePath _sliderOrganizerPath;
    private SliderOrganizer _sliderOrganizer;
    [Signal] delegate void StartRunEventHandler(Route route, bool isSprint);

    
    public override void _Ready()
    {
        _sliderOrganizer = GetNode<SliderOrganizer>(_sliderOrganizerPath);
    }
    
    private void _on_button_down()
    {
        (double distance, double elevation, double groundDifficulty, bool isSprint) = _sliderOrganizer.GetValues();
        
        Route route = new Route(distance, elevation, groundDifficulty);
        EmitSignalStartRun(route, isSprint);
    }
}
using System.Diagnostics;
using Godot;

namespace Manager.Scripts.Slider;

public partial class SliderOrganizer : Control
{
    
    [Export] private NodePath _distanceSliderPath;
    [Export] private NodePath _elevationSliderPath;
    [Export] private NodePath _groundDifficultySliderPath;
    [Export] private NodePath _isSprintCheckBoxPath;
    
    private HSlider _distanceSlider;
    private HSlider _elevationSlider;
    private HSlider _groundDifficultySlider;
    private CheckBox _isSprintCheckBox;
    
    public override void _Ready()
    {
        _distanceSlider = GetNode<HSlider>(_distanceSliderPath);
        _elevationSlider = GetNode<HSlider>(_elevationSliderPath);
        _groundDifficultySlider = GetNode<HSlider>(_groundDifficultySliderPath);
        _isSprintCheckBox = GetNode<CheckBox>(_isSprintCheckBoxPath);
    }
    
    public (double Distance, double Elevation, double GroundDifficulty, bool isSprint) GetValues()
    {
        return (_distanceSlider.Value, 
            _elevationSlider.Value, 
            _groundDifficultySlider.Value, 
            _isSprintCheckBox.ButtonPressed);
    }

}
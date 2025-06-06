using System;
using Godot;

namespace Manager.Scripts.Slider;

public partial class SliderBox : Node
{
    [Export] private NodePath _hSliderPath;
    [Export] private NodePath _textEditPath;
    [Export] private String _baseText;

    private TextEdit _textEdit;
    private HSlider _hSlider;

    public override void _Ready()
    {
        _hSlider = GetNode<HSlider>(_hSliderPath);
        _textEdit = GetNode<TextEdit>(_textEditPath);
        _update_text();
    }
      
    private void _on_h_slider_value_changed(bool valueChanged)
    {
        if (valueChanged)
        {
            _update_text();
        }
    }
    
    private void _update_text()
    {
        _textEdit.Text = _baseText + ": " + _hSlider.Value.ToString("F1");
    }
}
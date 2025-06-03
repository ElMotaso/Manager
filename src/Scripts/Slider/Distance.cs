using Godot;
using System;
using Manager.Scripts.Runs;

public partial class Distance : Node
{
    [Export] private NodePath _hSliderPath;
    [Export] private NodePath _textEditPath;
      
    private void _on_h_slider_drag_ended(bool valueChanged)
    {
        if (valueChanged)
        {
            Console.WriteLine("jo wir sind da");
            var hSlider = GetNode<HSlider>(_hSliderPath);
            var textEdit = GetNode<TextEdit>(_textEditPath);
            textEdit.Text = hSlider.Value.ToString();
        }
    }
}

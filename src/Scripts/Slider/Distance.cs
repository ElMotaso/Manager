using Godot;
using System;

   public partial class Distance : Node
   {
       [Export] private NodePath HSliderPath;
       [Export] private NodePath TextEditPath;
      
       public void _on_h_slider_drag_ended()
       {
           // Access the nodes via the exported paths
           var hSlider = GetNode<HSlider>(HSliderPath);
           var textEdit = GetNode<TextEdit>(TextEditPath);
           textEdit.Text = hSlider.Value.ToString();
       }
   }
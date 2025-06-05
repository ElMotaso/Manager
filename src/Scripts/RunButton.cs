using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class RunButton : Button
{
    private Route _route;
    private bool _isSprint;
    private void _on_button_down()
    {
        _route = new Route();
    }
}
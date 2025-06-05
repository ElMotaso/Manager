using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Run : Control
{
    private Main _main;
    
    public override void _Ready()
    {
        _main = GetParent<Main>();
    }

    private void _on_run_button_start_run(Route route, bool isSprint)
    {
        _main.GetPlayerToRun(route, isSprint);
    }

    public void DisableRunButton()
    {
        Button runButton = GetNode<Button>("RunButton");
        runButton.Disabled = true;
    }
}
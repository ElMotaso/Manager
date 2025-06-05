using Godot;
using Manager.Scripts.Runs;

namespace Manager.Scripts;

public partial class Run : Control
{
    [Export] private NodePath _playerPath;
    private Runner _player;
    
    public override void _Ready()
    {
        _player = GetNode<Runner>(_playerPath);
    }

    private void _on_run_button_start_run(Route route, bool isSprint)
    {
        _player.Run(route, isSprint);
    }
}
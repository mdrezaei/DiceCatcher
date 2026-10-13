using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    private Fox _fox;
    private int _points = 0;
    public override void _Ready()
    {
        _fox.PointScored += OnPointScored;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void OnPointScored()
    {
        _points += 1;
        GD.Print($"points: {_points}");
    }
}

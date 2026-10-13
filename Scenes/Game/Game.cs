using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    private Fox _fox;
    [Export]
    private Label _pointLabel;
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
        _pointLabel.Text = _points.ToString("D4");
        GD.Print($"points: {_points}");
    }
}

using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    private Fox _fox;
    [Export]
    private Label _pointLabel;
    [Export]
    private PackedScene _diceScene;
    [Export]
    private Timer _spawnTimer;
    private int _points = 0;
    private const float _margin = 100.0f;

    public override void _Ready()
    {
        _fox.PointScored += OnPointScored;
        _spawnTimer.Timeout += SpawnDice;
        SpawnDice();
    }

    private void SpawnDice()
    {
        Dice dice = _diceScene.Instantiate<Dice>();

        Rect2 vpr = GetViewportRect();
        float x = (float)GD.RandRange(vpr.Position.X + _margin, vpr.End.X - _margin);

        dice.Position = new Vector2(x, _margin);
        AddChild(dice);
    }

    private void OnPointScored()
    {
        _points += 1;
        _pointLabel.Text = _points.ToString("D4");
        GD.Print($"points: {_points}");
    }
}

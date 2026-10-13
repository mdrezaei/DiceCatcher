using Godot;
using System;

public partial class Fox : Area2D
{
    [Export]
    private Sprite2D _foxSprite;
    [Export]
    private float _speed = 200.0f;
    private float _move;

    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _move = Input.GetAxis("ui_left", "ui_right");
        if (!Mathf.IsZeroApprox(_move))
        {
            _foxSprite.FlipH = _move > 0.0f;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(_move * (float)delta * _speed, 0);
    }
}

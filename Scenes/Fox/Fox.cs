using Godot;
using System;

public partial class Fox : Area2D
{
    [Signal]
    public delegate void PointScoredEventHandler();

    [Export]
    private Sprite2D _foxSprite;
    [Export]
    private AudioStreamPlayer2D _eatSound;
    [Export]
    private float _speed = 200.0f;
    private float _move;

    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
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

    private void OnAreaEntered(Area2D area)
    {
        if (area is Dice)
        {
            _eatSound.Play();
            area.QueueFree();
            EmitSignal(SignalName.PointScored);
        }
    }
}

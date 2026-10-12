using Godot;
using System;

public partial class Dice : Area2D
{
    [Export]
    private Sprite2D _diceSprite;
    private const float _speed = 80.0f;
    private const float _rotationSpeed = 4.0f;
    private float _rotationDirection;
    public override void _Ready()
    {
        if (GD.Randf() < 0.5f)
        {
            _rotationDirection = -1.0f;
        }
        else
        {
            _rotationDirection = 1.0f;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += new Vector2(0, _speed * (float)delta);
        _diceSprite.Rotate(_rotationDirection * _rotationSpeed * (float)delta);
    }
}

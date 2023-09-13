using Godot;
using System;

public partial class AxeAbility : Node2D
{
	const float MAX_RADIUS = 100;

	public HitboxComponent hitboxComponent;
	private Vector2 baseRotation = Vector2.Right;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		baseRotation = Vector2.Right.Rotated((float)GD.RandRange(0, Mathf.Tau));

		var tween = CreateTween();
		tween.TweenMethod(Callable.From((float rotations) => TweenMethod(rotations)), 0.0F, 2.0F, 3.0F); // Magic Numbers
		tween.TweenCallback(Callable.From(() => QueueFree()));

		hitboxComponent = GetNode("%HitboxComponent") as HitboxComponent;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TweenMethod(float rotations)
	{
		var percent = rotations / 2;
		var currentRadius = percent * MAX_RADIUS;
		var currentDirection = baseRotation.Rotated(rotations * Mathf.Tau);

		var player = GetTree().GetFirstNodeInGroup("player") as Player;
		if (player == null)
		{
			return;
		}

		GlobalPosition = player.GlobalPosition + (currentDirection * currentRadius);
	}
}

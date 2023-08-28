using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float MAX_SPEED = 200.0F;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var movementVector = GetMovementVector();

		Velocity = movementVector * MAX_SPEED;

		MoveAndSlide();
	}

	public Vector2 GetMovementVector()
	{
		var movementVector = Vector2.Zero;

		movementVector.X = Input.GetAxis("move_left", "move_right");
		movementVector.Y = Input.GetAxis("move_up", "move_down");

		return movementVector.Normalized();
	}
}

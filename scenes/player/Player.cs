using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float maxSpeed = 125.0F;
	[Export]
	public float accelerationSmoothing = 25.0F;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var movementVector = GetMovementVector();

		var targetVelocity = movementVector * maxSpeed;

		Velocity = Velocity.Lerp(targetVelocity, 1.0F - (float)Math.Exp(-delta * accelerationSmoothing));

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

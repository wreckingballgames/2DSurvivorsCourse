using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	const float MAX_SPEED = 75.0F;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = GetDirectionToPlayer();
		Velocity = direction * MAX_SPEED;
		MoveAndSlide();
	}

	public Vector2 GetDirectionToPlayer()
	{
		var playerNode = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if (playerNode != null)
		{
			return GlobalPosition.DirectionTo(playerNode.GlobalPosition);
		}
		else
		{
			return Vector2.Zero;
		}
	}
}

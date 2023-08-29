using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	[Export]
	public float maxSpeed = 35.0F;
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var direction = GetDirectionToPlayer();
		Velocity = direction * maxSpeed;
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

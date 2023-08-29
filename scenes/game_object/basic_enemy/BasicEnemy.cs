using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	[Export]
	public float maxSpeed = 35.0F;
	Area2D area2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		area2D = GetNode<Area2D>("%Area2D");
		area2D.AreaEntered += (Area2D area) => OnArea2DAreaEntered(area);
	}

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

	public void OnArea2DAreaEntered(Area2D area)
	{
		QueueFree();
	}
}

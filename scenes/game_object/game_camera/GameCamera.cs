using Godot;
using System;

public partial class GameCamera : Camera2D
{
	private Vector2 targetPosition = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MakeCurrent();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		AcquireTarget();
		GlobalPosition = GlobalPosition.Lerp(targetPosition, 1.0F - (float)Math.Exp(-delta * 20.0));
	}

	public void AcquireTarget()
	{
		var playerNode = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if (playerNode != null)
		{
			var player = playerNode;
			targetPosition = player.GlobalPosition;
		}
	}
}

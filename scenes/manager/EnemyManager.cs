using Godot;
using System;

public partial class EnemyManager : Node
{
	const float SPAWN_RADIUS = 375.0F; // Half of viewport width + number of pixels to spawn off-screen
	[Export]
	public PackedScene BasicEnemyScene;
	private Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;

		timer.Timeout += () => OnTimerTimeout();
	}

	public void OnTimerTimeout()
	{
		var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if (player == null)
		{
			return;
		}

		// Use viewport width to spawn enemies in a random circle off-screen
		var randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau));
		var spawnPosition = player.GlobalPosition + (randomDirection * SPAWN_RADIUS);

		var enemy = BasicEnemyScene.Instantiate() as Node2D;
		GetParent().AddChild(enemy);
		enemy.GlobalPosition = spawnPosition;
	}
}

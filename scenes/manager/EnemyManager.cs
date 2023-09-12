using Godot;
using System;

public partial class EnemyManager : Node
{
	const float SPAWN_RADIUS = 375.0F; // Half of viewport width + number of pixels to spawn off-screen

	[Export]
	public PackedScene basicEnemyScene;
	[Export]
	public ArenaTimeManager arenaTimeManager;

	private Timer timer;
	private double baseSpawnTime = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;
		baseSpawnTime = timer.WaitTime;

		timer.Timeout += () => OnTimerTimeout();

		arenaTimeManager.ArenaDifficultyIncreased += (int arenaDifficulty) => OnArenaDifficultyIncreased(arenaDifficulty);
	}

	public void OnTimerTimeout()
	{
		timer.Start();

		var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if (player == null)
		{
			return;
		}

		// Use viewport width to spawn enemies in a random circle off-screen
		var randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau));
		var spawnPosition = player.GlobalPosition + (randomDirection * SPAWN_RADIUS);

		var enemy = basicEnemyScene.Instantiate() as Node2D;

		var entitiesLayer = GetTree().GetFirstNodeInGroup("entities_layer") as Node2D;
		entitiesLayer.CallDeferred("add_child", enemy);
		enemy.GlobalPosition = spawnPosition;
	}

	public void OnArenaDifficultyIncreased(int arenaDifficulty)
	{
		var timeOff = (.1 / 12) * arenaDifficulty;
		timeOff = Mathf.Min(timeOff, .7);
		timer.WaitTime = baseSpawnTime - timeOff;
	}
}

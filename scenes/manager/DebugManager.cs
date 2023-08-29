using Godot;
using System;

public partial class DebugManager : Node
{	
	Label fpsLabel;
	Label enemyCountLabel;

	public override void _Ready()
	{
		fpsLabel = GetNode("%FPSLabel") as Label;
		enemyCountLabel = GetNode("%EnemyCountLabel") as Label;
	}

	public override void _Process(double delta)
	{
		var fps = Engine.GetFramesPerSecond();
		var enemies = GetTree().GetNodesInGroup("enemy");
		int enemyCount = 0;
		if (enemies != null)
		{
			enemyCount = enemies.Count;
		}

		fpsLabel.Text = $"FPS: {fps}";
		enemyCountLabel.Text = $"Enemy Count: {enemyCount}";
	}
}

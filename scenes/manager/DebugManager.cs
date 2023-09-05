using Godot;
using System;

public partial class DebugManager : Node
{	
	private Label FPSLabel;
	private Label enemyCountLabel;

	public override void _Ready()
	{
		FPSLabel = GetNode("%FPSLabel") as Label;
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

		FPSLabel.Text = $"FPS: {fps}";
		enemyCountLabel.Text = $"Enemy Count: {enemyCount}";
	}
}

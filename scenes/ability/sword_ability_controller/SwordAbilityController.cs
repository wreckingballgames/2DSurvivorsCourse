using Godot;
using System;

public partial class SwordAbilityController : Node
{
	const float MAX_RANGE = 150.0F;
	[Export]
	PackedScene swordAbilityScene;
	Node2D swordAbilityInstance;
	Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;

		timer.Timeout += () => OnTimerTimeout();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTimerTimeout()
	{
		var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if (player == null)
		{
			return;
		}

		// This whole section was a nightmare for a C# neophyte. Check it thoroughly, see if there's a better way, and learn from this.
		var enemiesAsNode = GetTree().GetNodesInGroup("enemy"); // Get a Godot collection (expensive in C#)
		// var enemies = new Godot.Collections.Array<Node2D>(); // Original code; working with C# collections is far more performant
		var enemies = new System.Collections.Generic.List<Node2D>();
		var enemiesSwap = new System.Collections.Generic.List<Node2D>();

		foreach (Node enemy in enemiesAsNode)
		{
			var enemyAsNode2D = enemy as Node2D;
			enemies.Add(enemyAsNode2D);
		}

		enemiesSwap.AddRange(System.Linq.Enumerable.Where<Node2D>(enemies, (Node2D enemy) => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Math.Pow(MAX_RANGE, 2)));
		enemies.Clear();
		enemies.AddRange(enemiesSwap);
		enemiesSwap.Clear();

		if (enemies.Count == 0)
		{
			return;
		}

		enemiesSwap.AddRange(System.Linq.Enumerable.OrderBy<Node2D, float>(enemies, (Node2D enemy) => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition)));
		enemies.Clear();
		enemies.AddRange(enemiesSwap);

		swordAbilityInstance = swordAbilityScene.Instantiate() as Node2D;
		player.GetParent().AddChild(swordAbilityInstance);
		swordAbilityInstance.GlobalPosition = enemies[0].GlobalPosition;

		swordAbilityInstance.GlobalPosition += Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau)) * 4;
		var enemyDirection = enemies[0].GlobalPosition - swordAbilityInstance.GlobalPosition;
		swordAbilityInstance.Rotation = enemyDirection.Angle();
	}
}

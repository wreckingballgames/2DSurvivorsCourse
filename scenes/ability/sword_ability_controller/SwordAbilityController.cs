using Godot;
using System;

public partial class SwordAbilityController : Node
{
	[Export]
	PackedScene swordAbilityScene;
	Node2D swordAbility;
	Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;

		timer.Connect("timeout", Callable.From(() => OnTimerTimeout())); // Use of lambdas to make callables in C#; VERY IMPORTANT KNOWLEDGE
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTimerTimeout()
	{
		var player = GetTree().GetFirstNodeInGroup("player") as CharacterBody2D;
		if (player == null)
		{
			return;
		}

		swordAbility = swordAbilityScene.Instantiate() as Node2D;
		swordAbility.GlobalPosition = player.GlobalPosition;
		player.GetParent().AddChild(swordAbility);
	}
}

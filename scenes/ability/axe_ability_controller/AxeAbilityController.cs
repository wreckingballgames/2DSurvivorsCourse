using Godot;
using System;

public partial class AxeAbilityController : Node
{
	[Export]
	public PackedScene axeAbilityScene;
	[Export]
	public float damage = 10.0F;

	private Timer timer;

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
		var player = GetTree().GetFirstNodeInGroup("player") as Player;
		if (player == null)
		{
			return;
		}

		var foreground = GetTree().GetFirstNodeInGroup("foreground_layer") as Node2D;
		if (foreground == null)
		{
			return;
		}

		var axeInstance = axeAbilityScene.Instantiate() as AxeAbility;
		foreground.AddChild(axeInstance);
		axeInstance.hitboxComponent.Damage = damage;
		axeInstance.GlobalPosition = player.GlobalPosition;
	}
}

using Godot;
using System;

public partial class ExperienceVial : Node2D
{
	Area2D area_2d;
	GameEvents gameEvents;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameEvents = GetNode("/root/GameEvents") as GameEvents;

		area_2d = GetNode("%Area2D") as Area2D;
		area_2d.AreaEntered += (Area2D area) => OnArea2DAreaEntered(area);
	}

	public void OnArea2DAreaEntered(Area2D area)
	{
		gameEvents.EmitExperienceVialCollected(1);
		QueueFree();
	}
}

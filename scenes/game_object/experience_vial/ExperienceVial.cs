using Godot;
using System;

public partial class ExperienceVial : Node2D
{
	private Area2D area_2D;
	private GameEvents gameEvents;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		gameEvents = GetNode("/root/GameEvents") as GameEvents;

		area_2D = GetNode("%Area2D") as Area2D;
		area_2D.AreaEntered += (Area2D area) => OnArea2DAreaEntered(area);
	}

	public void OnArea2DAreaEntered(Area2D area)
	{
		gameEvents.EmitExperienceVialCollected(1);
		QueueFree();
	}
}

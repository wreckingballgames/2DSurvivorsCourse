using Godot;
using System;

public partial class ExperienceManager : Node
{
	float currentExperience = 0.0F;
	GameEvents gameEvents;

	public override void _Ready()
	{
		gameEvents = GetNode("/root/GameEvents") as GameEvents;
		gameEvents.ExperienceVialCollected += (float number) => OnExperienceVialCollected(number);
	}

	public void IncrementExperience(float number)
	{
		currentExperience += number;
		GD.Print(currentExperience);
	}

	public void OnExperienceVialCollected(float number)
	{
		IncrementExperience(number);
	}
}

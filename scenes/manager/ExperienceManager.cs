using Godot;
using System;

public partial class ExperienceManager : Node
{
	[Signal]
	public delegate void ExperienceUpdatedEventHandler(float currentExperience, float targetExperience);

	const float TARGET_EXPERIENCE_GROWTH = 5.0F;

	float currentExperience = 0.0F;
	int currentLevel = 1;
	float targetExperience = 5.0F;
	GameEvents gameEvents;

	public override void _Ready()
	{
		gameEvents = GetNode("/root/GameEvents") as GameEvents;
		gameEvents.ExperienceVialCollected += (float number) => OnExperienceVialCollected(number);
	}

	public void IncrementExperience(float number)
	{
		currentExperience = Mathf.Min(currentExperience + number, targetExperience);
		EmitSignal(SignalName.ExperienceUpdated, currentExperience, targetExperience);
		if (currentExperience == targetExperience)
		{
			currentLevel++;
			targetExperience += TARGET_EXPERIENCE_GROWTH;
			currentExperience = 0;
			EmitSignal(SignalName.ExperienceUpdated, currentExperience, targetExperience);
		}
	}

	public void OnExperienceVialCollected(float number)
	{
		IncrementExperience(number);
	}
}

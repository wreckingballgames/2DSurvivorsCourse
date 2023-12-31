using Godot;
using System;

public partial class ExperienceManager : Node
{
	[Signal]
	public delegate void ExperienceUpdatedEventHandler(float currentExperience, float targetExperience);
	[Signal]
	public delegate void LeveledUpEventHandler(int newLevel);

	const float TARGET_EXPERIENCE_GROWTH = 5.0F;

	private float currentExperience = 0.0F;
	private int currentLevel = 1;
	private float targetExperience = 1.0F;
	private GameEvents gameEvents;

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
			EmitSignal(SignalName.LeveledUp, currentLevel);
		}
	}

	public void OnExperienceVialCollected(float number)
	{
		IncrementExperience(number);
	}
}

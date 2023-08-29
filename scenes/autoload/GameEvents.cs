using Godot;
using System;

public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(float number);

	public void EmitExperienceVialCollected(float number)
	{
		EmitSignal(SignalName.ExperienceVialCollected, number);
	}
}

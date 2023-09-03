using Godot;
using System;

public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(float number);
	[Signal]
	public delegate void AbilityUpgradeAddedEventHandler(AbilityUpgrade upgrade, Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, Godot.Variant>> currentUpgrades);

	public void EmitExperienceVialCollected(float number)
	{
		EmitSignal(SignalName.ExperienceVialCollected, number);
	}

	public void EmitAbilityUpgradeAdded(AbilityUpgrade upgrade, Godot.Collections.Dictionary<string, Godot.Collections.Dictionary<string, Godot.Variant>> currentUpgrades)
	{
		EmitSignal(SignalName.AbilityUpgradeAdded, upgrade, currentUpgrades);
	}
}

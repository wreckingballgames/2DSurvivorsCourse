using Godot;
using System;

public partial class UpgradeScreen : CanvasLayer
{
	[Signal]
	public delegate void UpgradeSelectedEventHandler(AbilityUpgrade upgrade);

	[Export]
	public PackedScene UpgradeCardScene { get; set; }

	private HBoxContainer cardContainer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cardContainer = GetNode<HBoxContainer>("%CardContainer"); // This form of GetNode throws an exception if the cast is invalid rather than returning null as the "as" keyword does. Which do you think is better?
		GetTree().Paused = true;
	}

	public void SetAbilityUpgrades(System.Collections.Generic.List<AbilityUpgrade> upgrades)
	{
		foreach (AbilityUpgrade upgrade in upgrades)
		{
			var cardInstance = UpgradeCardScene.Instantiate() as AbilityUpgradeCard;
			cardContainer.AddChild(cardInstance);
			cardInstance.SetAbilityUpgrade(upgrade);
			cardInstance.Selected += () => OnUpgradeSelected(upgrade);
		}
	}

	public void OnUpgradeSelected(AbilityUpgrade upgrade)
	{
		EmitSignal(SignalName.UpgradeSelected, upgrade);
		GetTree().Paused = false;
		QueueFree();
	}
}

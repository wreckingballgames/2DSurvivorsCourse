using Godot;
using System;

public partial class UpgradeScreen : CanvasLayer
{
	[Export]
	public PackedScene UpgradeCardScene { get; set; }

	private HBoxContainer cardContainer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cardContainer = GetNode<HBoxContainer>("%CardContainer"); // This form of GetNode throws an exception if the cast is invalid rather than returning null as the "as" keyword does. Which do you think is better?
		GetTree().Paused = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetAbilityUpgrades(System.Collections.Generic.List<AbilityUpgrade> upgrades)
	{
		foreach (AbilityUpgrade upgrade in upgrades)
		{
			var cardInstance = UpgradeCardScene.Instantiate() as AbilityUpgradeCard;
			cardContainer.AddChild(cardInstance);
			cardInstance.SetAbilityUpgrade(upgrade);
		}
	}
}

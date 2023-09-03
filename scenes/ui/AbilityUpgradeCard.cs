using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{
	[Signal]
	public delegate void SelectedEventHandler();

	// I want to start using automatic properties and considering the difference between fields and properties in my code. It starts here
	public Label NameLabel { get; set; }
	public Label DescriptionLabel { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NameLabel = GetNode<Label>("%NameLabel");
		DescriptionLabel = GetNode<Label>("%DescriptionLabel");
		GuiInput += (InputEvent inputEvent) => OnGuiInput(inputEvent);
	}
	
	public void SetAbilityUpgrade(AbilityUpgrade upgrade)
	{
		NameLabel.Text = upgrade.Name;
		DescriptionLabel.Text = upgrade.Description;
	}

	public void OnGuiInput(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("left_click"))
		{
			EmitSignal(SignalName.Selected);
		}
	}
}

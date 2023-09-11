using Godot;
using System;

public partial class EndScreen : CanvasLayer
{
	private Button restartButton;
	private Button quitButton;
	private Label titleLabel;
	private Label descriptionLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTree().Paused = true;

		restartButton = GetNode("%RestartButton") as Button;
		restartButton.Pressed += () => OnRestartButtonPressed();

		quitButton = GetNode("%QuitButton") as Button;
		quitButton.Pressed += () => OnQuitButtonPressed();

		titleLabel = GetNode("%TitleLabel") as Label;
		descriptionLabel = GetNode("%DescriptionLabel") as Label;
	}

	public void SetDefeat()
	{
		titleLabel.Text = "Defeat";
		descriptionLabel.Text = "You lost!";
	}

	public void OnRestartButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
	}

	public void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}

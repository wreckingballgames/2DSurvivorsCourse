using Godot;
using System;

public partial class VictoryScreen : CanvasLayer
{
	private Button restartButton;
	private Button quitButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTree().Paused = true;

		restartButton = GetNode("%RestartButton") as Button;
		restartButton.Pressed += () => OnRestartButtonPressed();

		quitButton = GetNode("%QuitButton") as Button;
		quitButton.Pressed += () => OnQuitButtonPressed();
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

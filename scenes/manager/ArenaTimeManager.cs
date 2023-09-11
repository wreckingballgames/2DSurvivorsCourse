using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	[Export]
	public PackedScene victoryScreenScene;

	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;
		timer.Timeout += () => OnTimerTimeout();
	}

	public double GetTimeElapsed()
	{
		return timer.WaitTime - timer.TimeLeft;
	}

	public void OnTimerTimeout()
	{
		var victoryScreenInstance = victoryScreenScene.Instantiate();
		AddChild(victoryScreenInstance);
	}
}

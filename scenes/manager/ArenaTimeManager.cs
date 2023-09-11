using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	[Export]
	public PackedScene endScreenScene;

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
		var endScreenInstance = endScreenScene.Instantiate();
		AddChild(endScreenInstance);
	}
}

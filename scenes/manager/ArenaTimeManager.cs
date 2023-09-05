using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;
	}

	public double GetTimeElapsed()
	{
		return timer.WaitTime - timer.TimeLeft;
	}
}

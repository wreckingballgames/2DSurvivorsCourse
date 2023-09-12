using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	[Export]
	public PackedScene endScreenScene;
	[Export]
	public int arenaDifficulty = 0;
	[Export]
	public int difficultyInterval = 5;

	[Signal]
	public delegate void ArenaDifficultyIncreasedEventHandler(int arenaDifficulty);

	private Timer timer;

	public override void _Ready()
	{
		timer = GetNode("%Timer") as Timer;
		timer.Timeout += () => OnTimerTimeout();
	}

    public override void _Process(double delta)
    {
        base._Process(delta);

		var nextTimeTarget = timer.WaitTime - ((arenaDifficulty + 1) * difficultyInterval);
		if (timer.TimeLeft <= nextTimeTarget)
		{
			arenaDifficulty += 1;
			EmitSignal(SignalName.ArenaDifficultyIncreased, arenaDifficulty);
		}
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

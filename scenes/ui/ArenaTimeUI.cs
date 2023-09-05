using Godot;
using System;

public partial class ArenaTimeUI : CanvasLayer
{
	[Export]
	public ArenaTimeManager arenaTimeManager;

	private Label label;

    public override void _Ready()
    {
        label = GetNode("%Label") as Label;
    }

    public override void _Process(double delta)
    {
		if (arenaTimeManager == null)
		{
			return;
		}

        var timeElapsed = Math.Floor(arenaTimeManager.GetTimeElapsed());
		label.Text = FormatSeconds((float)timeElapsed);
    }

	public String FormatSeconds(float seconds)
	{
		var minutes = MathF.Floor(seconds / 60);
		var remainingSeconds = seconds - (minutes * 60);

		return $"{minutes}:{remainingSeconds:00}";
	}
}

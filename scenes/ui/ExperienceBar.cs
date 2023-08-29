using Godot;
using System;

public partial class ExperienceBar : CanvasLayer
{
	[Export]
	ExperienceManager experienceManager;
	ProgressBar progressBar;

    public override void _Ready()
    {
		progressBar = GetNode<ProgressBar>("%ProgressBar");
		progressBar.Value = 0;
        experienceManager.ExperienceUpdated += (float currentExperience, float targetExperience) => OnExperienceUpdated(currentExperience, targetExperience);
    }

	public void OnExperienceUpdated(float currentExperience, float targetExperience)
	{
		if (targetExperience == 0)
		{
			return;
		}

		var percent = currentExperience / targetExperience;
		progressBar.Value = percent;
	}
}

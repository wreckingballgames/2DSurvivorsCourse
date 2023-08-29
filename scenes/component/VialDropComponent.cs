using Godot;
using System;

public partial class VialDropComponent : Node
{
	[Export(PropertyHint.Range, "0, 1")]
	float dropPercent = 0.5F;
	[Export]
	HealthComponent healthComponent;
	[Export]
	PackedScene vialScene;

    public override void _Ready()
    {
		healthComponent.Died += () => OnDied();
    }

	public void OnDied()
	{
		if (GD.Randf() > dropPercent)
		{
			return;
		}

		if (vialScene == null)
		{
			return;
		}

		var spawnPosition = (Owner as Node2D).GlobalPosition; // He did a check if owner is Node2D here that I'm unsure how to do in C#
		ExperienceVial vialInstance = vialScene.Instantiate() as ExperienceVial;
		Owner.GetParent().CallDeferred("add_child", vialInstance);
		vialInstance.GlobalPosition = spawnPosition;
	}
}

using Godot;
using System;

public partial class VialDropComponent : Node
{
	[Export(PropertyHint.Range, "0, 1")]
	public float dropPercent = 0.5F;
	[Export]
	public HealthComponent healthComponent;
	[Export]
	public PackedScene vialScene;

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

		if (Owner.IsClass("Node2D"))
		{
			var spawnPosition = (Owner as Node2D).GlobalPosition;
			ExperienceVial vialInstance = vialScene.Instantiate() as ExperienceVial;

			var entitiesLayer = GetTree().GetFirstNodeInGroup("entities_layer") as Node2D;
			entitiesLayer.CallDeferred("add_child", vialInstance);
			vialInstance.GlobalPosition = spawnPosition;
		}
		
	}
}

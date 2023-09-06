using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
	[Export]
	public HealthComponent healthComponent;

    public override void _Ready()
    {
        AreaEntered += (Area2D area) => OnAreaEntered(area);
    }

	public void OnAreaEntered(Area2D area)
	{
		if (area.IsClass("HitboxComponent"))
		{
			return;
		}

		if (healthComponent == null)
		{
			return;
		}

		HitboxComponent hitbox = area as HitboxComponent;
		healthComponent.Damage(hitbox.Damage);
	}
}

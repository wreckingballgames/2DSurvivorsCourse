using Godot;
using System;

public partial class HealthComponent : Node
{
	[Signal]
	public delegate void DiedEventHandler();
	[Export]
	float maxHealth = 10.0F;
	float currentHealth;

	public override void _Ready()
	{
		currentHealth = maxHealth;
	}

	public void Damage(float damage)
	{
		currentHealth = Mathf.Max(currentHealth - damage, 0);
		Callable.From(() => CheckDeath()).CallDeferred(); // Making callables from methods this way is very useful
	}

	public void CheckDeath()
	{
		if (currentHealth == 0)
		{
			EmitSignal(SignalName.Died);
			Owner.CallDeferred("queue_free");
		}
	}
}

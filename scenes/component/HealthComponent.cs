using Godot;
using System;

public partial class HealthComponent : Node
{
	[Signal]
	public delegate void DiedEventHandler();
	[Signal]
	public delegate void HealthChangedEventHandler();

	[Export]
	public float maxHealth = 10.0F;
	
	public float currentHealth;

	public override void _Ready()
	{
		currentHealth = maxHealth;
	}

	public void Damage(float damage)
	{
		currentHealth = Mathf.Max(currentHealth - damage, 0);
		EmitSignal(SignalName.HealthChanged);
		Callable.From(() => CheckDeath()).CallDeferred(); // Making callables from methods this way is very useful
	}

	public float GetHealthPercent()
	{
		if (maxHealth <= 0)
		{
			return 0;
		}
		return Mathf.Min(currentHealth / maxHealth, 1);
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

using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float maxSpeed = 125.0F;
	[Export]
	public float accelerationSmoothing = 25.0F;

	private Area2D collisionArea2D;
	private int numberOfCollidingBodies = 0;
	private Timer damageIntervalTimer;
	private HealthComponent healthComponent;
	private ProgressBar healthBar;

    public override void _Ready()
    {
        base._Ready();

		collisionArea2D = GetNode("CollisionArea2D") as Area2D;
		collisionArea2D.BodyEntered += (Node2D body) => OnBodyEntered(body);
		collisionArea2D.BodyExited += (Node2D body) => OnBodyExited(body);

		damageIntervalTimer = GetNode("DamageIntervalTimer") as Timer;
		damageIntervalTimer.Timeout += () => OnDamageIntervalTimerTimeout();

		healthComponent = GetNode("HealthComponent") as HealthComponent;
		healthComponent.HealthChanged += () => OnHealthChanged();

		healthBar = GetNode("%HealthBar") as ProgressBar;
		UpdateHealthDisplay();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		var movementVector = GetMovementVector();

		var targetVelocity = movementVector * maxSpeed;

		Velocity = Velocity.Lerp(targetVelocity, 1.0F - (float)Math.Exp(-delta * accelerationSmoothing));

		MoveAndSlide();
	}

	public void CheckIfDamageDealt()
	{
		if (numberOfCollidingBodies == 0 || !(damageIntervalTimer.IsStopped()))
		{
			return;
		}

		healthComponent.Damage(1); // Magic number
		GD.Print(healthComponent.currentHealth); // Debug message
		damageIntervalTimer.Start();
	}

	public void UpdateHealthDisplay()
	{
		healthBar.Value = healthComponent.GetHealthPercent();
	}

	public Vector2 GetMovementVector()
	{
		var movementVector = Vector2.Zero;

		movementVector.X = Input.GetAxis("move_left", "move_right");
		movementVector.Y = Input.GetAxis("move_up", "move_down");

		return movementVector.Normalized();
	}

	public void OnBodyEntered(Node2D body)
	{
		numberOfCollidingBodies += 1;
		CheckIfDamageDealt();
	}

	public void OnBodyExited(Node2D body)
	{
		numberOfCollidingBodies -= 1;
	}

	public void OnDamageIntervalTimerTimeout()
	{
		CheckIfDamageDealt();
	}

	public void OnHealthChanged()
	{
		UpdateHealthDisplay();
	}
}

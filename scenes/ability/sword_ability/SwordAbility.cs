using Godot;
using System;

public partial class SwordAbility : Node2D
{
	public HitboxComponent Hitbox { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hitbox = GetNode("%HitboxComponent") as HitboxComponent;
	}
}

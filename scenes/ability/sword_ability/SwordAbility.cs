using Godot;
using System;

public partial class SwordAbility : Node2D
{
	public HitboxComponent hitbox;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hitbox = GetNode("%HitboxComponent") as HitboxComponent;
	}
}

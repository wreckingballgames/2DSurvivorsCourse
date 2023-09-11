using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public PackedScene endScreenScene;

	private Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode("%Player") as Player;
		player.healthComponent.Died += () => OnPlayerDied();
	}

	public void OnPlayerDied()
	{
		var endScreenInstance = endScreenScene.Instantiate() as EndScreen;
		AddChild(endScreenInstance); // This instance's ready method is called when it is added to the scene tree, guaranteed
		endScreenInstance.SetDefeat();
	}
}

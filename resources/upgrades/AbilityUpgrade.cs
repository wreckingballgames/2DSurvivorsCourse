using Godot;
using System;

public partial class AbilityUpgrade : Resource
{
	[Export]
	public string ID { get; set; }
	[Export]
	public string Name { get; set; }
	[Export(PropertyHint.MultilineText)]
	public string Description { get; set; }
}

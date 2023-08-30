using Godot;
using System;

public partial class AbilityUpgrade : Resource
{
	[Export]
	public string id;
	[Export]
	string name;
	[Export(PropertyHint.MultilineText)]
	string description;
}

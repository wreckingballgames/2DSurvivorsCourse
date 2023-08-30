using Godot;
using System;

public partial class UpgradeManager : Node
{
	[Export]
	Godot.Collections.Array<AbilityUpgrade> upgradePool;
	[Export]
	ExperienceManager experienceManager;

	System.Collections.Generic.Dictionary<String, System.Collections.Generic.Dictionary<String, Godot.Variant>> currentUpgrades;

    public override void _Ready()
    {
		currentUpgrades = new System.Collections.Generic.Dictionary<String, System.Collections.Generic.Dictionary<String, Godot.Variant>>{};
        if (experienceManager != null)
		{
			experienceManager.LeveledUp += (int newLevel) => OnLeveledUp(newLevel);
		}
    }

	public void OnLeveledUp(int newLevel)
	{
		AbilityUpgrade chosenUpgrade = upgradePool.PickRandom();
		if (chosenUpgrade == null)
		{
			return;
		}

		var hasUpgrade = currentUpgrades.ContainsKey(chosenUpgrade.id);
		if (hasUpgrade == false)
		{
			var newDictionary = new System.Collections.Generic.Dictionary<String, Godot.Variant>{};
			newDictionary.Add("resource", chosenUpgrade);
			newDictionary.Add("quantity", 1);
			currentUpgrades[chosenUpgrade.id] = newDictionary;
		}
		else
		{
			int quantitySwap = (int)currentUpgrades[chosenUpgrade.id]["quantity"];
			currentUpgrades[chosenUpgrade.id]["quantity"] = quantitySwap + 1;
		}
	}
}

using Godot;
using System;

public partial class UpgradeManager : Node
{
	[Export]
	public Godot.Collections.Array<AbilityUpgrade> UpgradePool { get; set; }
	// public System.Collections.Generic.List<AbilityUpgrade> UpgradePool { get; set; } // Does not work because only Variant-compatible types are able to be exported
	[Export]
	public ExperienceManager ExperienceManager { get; set; }
	[Export]
	public PackedScene UpgradeScreenScene { get; set; }

	// Dictionary of dictionaries; don't get mixed up accessing all the members buried inside. Can I rework this?
	System.Collections.Generic.Dictionary<String, System.Collections.Generic.Dictionary<String, Godot.Variant>> currentUpgrades;

    public override void _Ready()
    {
		currentUpgrades = new System.Collections.Generic.Dictionary<String, System.Collections.Generic.Dictionary<String, Godot.Variant>>{};
        if (ExperienceManager != null)
		{
			ExperienceManager.LeveledUp += (int newLevel) => OnLeveledUp(newLevel);
		}
    }

	public void OnLeveledUp(int newLevel)
	{
		AbilityUpgrade chosenUpgrade = UpgradePool.PickRandom();
		if (chosenUpgrade == null)
		{
			return;
		}

		// Temporary array to pass chosenUpgrade into UpgradeScreen.SetAbilityUpgrades. Is there a better way?
		var chosenUpgradeAsList = new System.Collections.Generic.List<AbilityUpgrade>();
		chosenUpgradeAsList.Add(chosenUpgrade);

		var upgradeScreenInstance = UpgradeScreenScene.Instantiate() as UpgradeScreen;
		AddChild(upgradeScreenInstance);
		upgradeScreenInstance.SetAbilityUpgrades(chosenUpgradeAsList);
	}

	public void ApplyUpgrade(AbilityUpgrade upgrade)
	{
		var hasUpgrade = currentUpgrades.ContainsKey(upgrade.ID);
		if (hasUpgrade == false)
		{
			var newDictionary = new System.Collections.Generic.Dictionary<String, Godot.Variant>{};
			newDictionary.Add("resource", upgrade);
			newDictionary.Add("quantity", 1);
			currentUpgrades[upgrade.ID] = newDictionary;
		}
		else
		{
			int quantitySwap = (int)currentUpgrades[upgrade.ID]["quantity"];
			currentUpgrades[upgrade.ID]["quantity"] = quantitySwap + 1;
		}
	}
}

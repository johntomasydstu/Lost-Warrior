using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour{

	public string ItemName;
	public string ItemDescription;
	public int ItemId;
	public Sprite ItemSprite;
	public enum ItemTypes{WEAPON, ARMOUR, MATERIAL, CONSUMABLE};
	public int ItemQuantity;
	public bool Stackable;
	public ItemTypes ItemType;

	public int HealthToRestore; //The amount of health the item restores. Should only be used for items of the CONSUMABLE type.

	public int WeaponDamage; //The amount of damage the item (weapon) deals. Should only be used for items of the WEAPON type.

	public string ArmourWeaponType; //The type of equipment that the Armour/Weapon is (eg. bronze, iron...)

	public bool found; //Used ONLY for the ITEM CRAFTING SYSTEM to check if ingredient is found in inventory.
	public bool craftable; //Used ONLY for the ITEM CRAFTING SYSTEM to check if player has all the required items to craft a certain item.
	public int recipeToCraft; //Used ONLY for the ITEM CRAFTING SYSTEM to craft an item

}

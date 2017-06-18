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
	public int HealthToRestore; //The amount of health the item restores. Should only be used for items of the CONSUMABLE type.
	public ItemTypes ItemType;

}

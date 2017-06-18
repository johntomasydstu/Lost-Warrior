using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour{

	public static List<BaseItem> ListOfItems = new List<BaseItem>(); //The list of all items in the game

	public Sprite[] sprites; //A list of sprites that the item can have

	// Use this for initialization
	void Start () {
		
		//Wood
		BaseItem i0 = gameObject.AddComponent<BaseItem>();
		i0.ItemName = "Wood";
		i0.ItemDescription = "A material gathered from trees. Can be used to craft many items.";
		i0.ItemId = 0;
		i0.ItemType = BaseItem.ItemTypes.MATERIAL;
		i0.ItemSprite = sprites[0];
		i0.Stackable = true;
		ListOfItems.Add (i0);

		//Iron Ore
		BaseItem i1 = gameObject.AddComponent<BaseItem>();
		i1.ItemName = "Iron Ore";
		i1.ItemDescription = "Can be smelted into iron ingots";
		i1.ItemId = 1;
		i1.ItemType = BaseItem.ItemTypes.MATERIAL;
		i1.ItemSprite = sprites[1];
		i1.Stackable = true;
		ListOfItems.Add (i1);

		//Small Healh Potion
		BaseItem i2 = gameObject.AddComponent<BaseItem>();
		i2.ItemName = "Small Health Potion";
		i2.ItemDescription = "Heals 10 HP";
		i2.ItemId = 2;
		i2.ItemType = BaseItem.ItemTypes.CONSUMABLE;
		i2.ItemSprite = sprites[2];
		i2.Stackable = true;
		i2.HealthToRestore = 10;
		ListOfItems.Add (i2);

		//Bronze Sword
		BaseItem i3 = gameObject.AddComponent<BaseItem>();
		i3.ItemName = "Bronze Sword";
		i3.ItemDescription = "A sword made out of bronze. +5 Attack";
		i3.ItemId = 3;
		i3.ItemType = BaseItem.ItemTypes.WEAPON;
		i3.ItemSprite = sprites[3];
		i3.Stackable = false;
		i3.WeaponDamage = 5;
		i3.ArmourWeaponType = "Bronze";
		ListOfItems.Add (i3);

		//Bronze Armour
		BaseItem i4 = gameObject.AddComponent<BaseItem>();
		i4.ItemName = "Bronze Armour";
		i4.ItemDescription = "A suit of armour made out of bronze. +5 Defence";
		i4.ItemId = 4;
		i4.ItemType = BaseItem.ItemTypes.ARMOUR;
		i4.ItemSprite = sprites[4];
		i4.Stackable = false;
		i4.ArmourWeaponType = "Bronze";
		ListOfItems.Add (i4);

		//Iron Sword
		BaseItem i5 = gameObject.AddComponent<BaseItem>();
		i5.ItemName = "Iron Sword";
		i5.ItemDescription = "A sword made out of Iron. +10 Attack";
		i5.ItemId = 5;
		i5.ItemType = BaseItem.ItemTypes.WEAPON;
		i5.ItemSprite = sprites[5];
		i5.Stackable = false;
		i5.WeaponDamage = 10;
		i5.ArmourWeaponType = "Iron";
		ListOfItems.Add (i5);

		//Iron Armour
		BaseItem i6 = gameObject.AddComponent<BaseItem>();
		i6.ItemName = "Iron Armour";
		i6.ItemDescription = "A suit of armour made out of Iron. +10 Defence";
		i6.ItemId = 6;
		i6.ItemType = BaseItem.ItemTypes.ARMOUR;
		i6.ItemSprite = sprites[6];
		i6.Stackable = false;
		i6.ArmourWeaponType = "Iron";
		ListOfItems.Add (i6);

//		foreach (var item in ListOfItems)
//		{
//			Debug.Log("Item " + item.ItemId + ": " + item.ItemName);
//		}
			
	}
}

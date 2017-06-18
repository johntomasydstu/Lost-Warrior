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

//		foreach (var item in ListOfItems)
//		{
//			Debug.Log(item.ItemName);
//		}

		//Debug.Log ("ListOfItems: " + ListOfItems.ToString());
	}
}

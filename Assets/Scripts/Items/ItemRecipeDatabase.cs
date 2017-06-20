using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRecipeDatabase : MonoBehaviour {

	public Dictionary<List<BaseItem>, BaseItem> CraftingRecipes = new Dictionary<List<BaseItem>, BaseItem> ();

	public List<string> RecipeDescriptions = new List<string>();

	public List<int> RecipeID = new List<int>();
	public List<Sprite> RecipeIcons = new List<Sprite>();

	public GameObject content;

	public InventoryListWindow InventoryListWindowScript;

	public ItemCraftingScreen ItemCraftingScreenScript;

	public BaseItem craftableItem;

	//public List<List<List<BaseItem>>> ListOfItemRecipes = new List<List<List<BaseItem>>>(); //The list of all item recipes in the game


	public bool done = false;

	public ItemDatabase ItemDatabaseScript;


	// Use this for initialization
	void Awake () {
		
		//RECIPE: Iron Sword
		//RECIPE: Iron Sword
		//RECIPE: Iron Sword
		List<BaseItem> Iron_Sword_Recipe = new List<BaseItem>(); //Recipe/Ingredients List

		string Iron_Sword_RecipeDesc = "Items needed to craft: @- Wood (x1) @- IronOre (x2)";
		Iron_Sword_RecipeDesc = Iron_Sword_RecipeDesc.Replace("@", Environment.NewLine);
		RecipeDescriptions.Add(Iron_Sword_RecipeDesc); 


		int Iron_Sword_ID = 0;
		RecipeID.Add (Iron_Sword_ID);


		Sprite Iron_Sword_Icon = ItemDatabase.ListOfItems [5].ItemSprite;
		RecipeIcons.Add (Iron_Sword_Icon);



		//Ingredient 1 - Wood x 1
		BaseItem Iron_Sword_Ingredient1 = ItemDatabase.ListOfItems [0]; 
		Iron_Sword_Ingredient1.ItemQuantity = 1;
		Iron_Sword_Recipe.Add (Iron_Sword_Ingredient1);

		//Ingredient 2 = Iron x 2
		BaseItem Iron_Sword_Ingredient2 = ItemDatabase.ListOfItems [1];
		Iron_Sword_Ingredient2.ItemQuantity = 2;
		Iron_Sword_Recipe.Add (Iron_Sword_Ingredient2);



		CraftingRecipes.Add(Iron_Sword_Recipe, ItemDatabase.ListOfItems[5]); 






		//RECIPE: Iron Armour
		//RECIPE: Iron Armour
		//RECIPE: Iron Armour
		List<BaseItem> Iron_Armour_Recipe = new List<BaseItem>(); //Recipe/Ingredients List

		string Iron_Armour_RecipeDesc = "Items needed to craft: @- IronOre (x8)";
		Iron_Armour_RecipeDesc = Iron_Armour_RecipeDesc.Replace("@", Environment.NewLine);
		RecipeDescriptions.Add(Iron_Armour_RecipeDesc); 


		int Iron_Armour_ID = 1;
		RecipeID.Add (Iron_Armour_ID);


		Sprite Iron_Armour_Icon = ItemDatabase.ListOfItems [6].ItemSprite;
		RecipeIcons.Add (Iron_Armour_Icon);



		//Ingredient 1 - Wood x 1
		BaseItem Iron_Armour_Ingredient1 = ItemDatabase.ListOfItems [1]; 
		Iron_Armour_Ingredient1.ItemQuantity = 8;
		Iron_Armour_Recipe.Add (Iron_Armour_Ingredient1);



		CraftingRecipes.Add(Iron_Armour_Recipe, ItemDatabase.ListOfItems[6]); 




	}


	public void CraftItem(int id)
	{
		List<BaseItem> output = new List<BaseItem>();

		foreach (List<BaseItem> recipe in CraftingRecipes.Keys) 
		{
			foreach (BaseItem Ingredient in recipe) 
			{
				Ingredient.found = false;
				print ("IngredientsList: " + recipe);

				foreach (BaseItem item in InventoryListWindowScript.PlayerInventory) 
				{
					if (item.ItemName == Ingredient.ItemName && item.ItemQuantity >= Ingredient.ItemQuantity) 
					{
						Ingredient.found = true;
						print (item.ItemName + " Is Equal to ingredient " + Ingredient.ItemName);
					} 
					else
					{
						print (item.ItemName + " Is Not Equal to ingredient " + Ingredient.ItemName);
					}
				}
				print (Ingredient.ItemName + " Found = " + Ingredient.found);
			}

			craftableItem = gameObject.AddComponent<BaseItem> ();
			//CraftingRecipes.TryGetValue (recipe, out craftableItem.craftable);
			foreach (BaseItem Ingredient in recipe) 
			{
				
				if (Ingredient.found != true) 
				{
					craftableItem.craftable = false;
					print ("CraftableItem.craftable = " + craftableItem.craftable);
					print ("You lack the required items to craft " + craftableItem.ItemName);
					return;
				}
			}
			craftableItem.craftable = true;
			print ("CraftableItem.craftable = " + craftableItem.craftable);
			print ("You have the right amount of items to craft " + craftableItem.ItemName);

		}


		if (craftableItem.craftable = true) 
		{

			print ("id: " + id);
			BaseItem craftedItem;// = ItemDatabase.ListOfItems[id];

			//CraftingRecipes.TryGetValue (, out craftedItem);


			print ("Contains!!!");
			List<List<BaseItem>> keyList = new List<List<BaseItem>>(this.CraftingRecipes.Keys);
			foreach(List<BaseItem> key in keyList)
			{
				print("Key: " + key.ToString());
			}
			CraftingRecipes.TryGetValue (keyList[id], out craftedItem);
			//print ("Crafted Item: " + craftedItem.ItemName + " " + craftedItem.ItemQuantity);
			print("CraftedItem: " + craftedItem);

			if (craftedItem != null) 
			{
				InventoryListWindowScript.AddItemToInventory (craftedItem.ItemId, 1);

				//remove item
				foreach (Transform child in content.transform) 
				{
					BaseItem childBaseItemScript = child.GetComponent<BaseItem> ();
					foreach (List<BaseItem> recipe in CraftingRecipes.Keys) 
					{
						foreach (BaseItem Ingredient in recipe) 
						{
							if (childBaseItemScript.ItemName == Ingredient.ItemName)
							{
								InventoryListWindowScript.RemoveItemFromInventory (child.gameObject, Ingredient.ItemQuantity);
							}
						}

					}

				}

			}
		}
	}
}

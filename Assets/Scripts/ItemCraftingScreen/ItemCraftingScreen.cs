using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCraftingScreen : MonoBehaviour {

	public InventoryListWindow InventoryListWindowScript;

	public ItemRecipeDatabase ItemRecipeDatabaseScript;

	public GameObject itemRecipeSlotPrefab;
	public GameObject content;
	public Text ItemRecipeDescriptionBox;
	public Button CraftButton;
	public ToggleGroup itemRecipeSlotToggleGroup;
	public Transform selectedItemRecipeSlot;
	public BaseItem selectedItemRecipeSlotBaseItemScript;
	private bool recipeSlotsLoaded;




	// Use this for initialization
	void Start () 
	{
		int i = -1;
		foreach (List<BaseItem> recipe in ItemRecipeDatabaseScript.CraftingRecipes.Keys) 
		{
			i++;
			GameObject itemRecipeSlot = Instantiate (itemRecipeSlotPrefab) as GameObject;
			itemRecipeSlot.name = itemRecipeSlotPrefab.ToString();
			itemRecipeSlot.transform.SetParent (content.transform);
			BaseRecipe itemRecipeSlotBaseRecipeScript = itemRecipeSlot.GetComponent<BaseRecipe> ();
			itemRecipeSlot.GetComponent<Toggle> ().group = itemRecipeSlotToggleGroup;
			//recipeSlotsLoaded = false;
		
		}
	}

		
	
	// Update is called once per frame
	void Update ()
	{
		int i = -1;

		foreach (List<BaseItem> recipe in ItemRecipeDatabaseScript.CraftingRecipes.Keys) 
		{
			i++;
			print(ItemRecipeDatabaseScript.RecipeDescriptions [i]);
			SetItemRecipeDescriptionBoxText ();
			//recipeSlotsLoaded = true;

		}


	}





	public void SetItemRecipeDescriptionBoxText ()//string description) 
	{
		selectedItemRecipeSlot = null;

		int i = -1;
		foreach (Transform child in content.transform) 
		{
			i++;
			Toggle childToggle = child.GetComponent<Toggle> ();
			if (childToggle.isOn) 
			{ 
				string description = ItemRecipeDatabaseScript.RecipeDescriptions [i];
				selectedItemRecipeSlot = child;
				selectedItemRecipeSlotBaseItemScript = selectedItemRecipeSlot.GetComponent<BaseItem> ();
				selectedItemRecipeSlotBaseItemScript.recipeToCraft = i;
				print ("Item to craft: " + selectedItemRecipeSlotBaseItemScript.recipeToCraft);

				CraftButton.gameObject.SetActive(true);
				print ("Childison!!!!");
				ItemRecipeDescriptionBox.text = (description);
				return;
			}
			else if (!childToggle.isOn)
			{
				CraftButton.gameObject.SetActive(false);
				ItemRecipeDescriptionBox.text = ""; 
			}
		}
	}


	public void craftItem ()
	{
		ItemRecipeDatabaseScript.CraftItem (ItemRecipeDatabaseScript.RecipeID[selectedItemRecipeSlotBaseItemScript.recipeToCraft]);
	}


}

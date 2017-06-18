using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWindow : MonoBehaviour {
	public List<BaseItem> PlayerInventory = new List<BaseItem>(); // The Player's Inventory

	public PlayerHealthManager PlayerHealthManagerScript;

	public GameObject itemSlotPrefab;
	public GameObject content;
	public ToggleGroup itemSlotToggleGroup;

	private Transform selectedItemSlot;

	public Image ItemIconBox;
	public Sprite emptyIcon;
	public Text ItemDescriptionBox;
	public Button UseEquipButton;


	private int xPos = 0;
	private int yPos = 0;
	private GameObject itemSlot;
	private Text itemSlotTextName;
	private Text itemSlotTextAmount;
	private Image itemSlotIcon;
	private bool selected;
	private bool UseEquipPressed;



	void Start () {
		UseEquipButton.gameObject.SetActive (false); // Sets the "Use/Equip" button to inactive
	}
		

	void Update () 
	{
		SetItemIconAndDescription ();
	}



	//Sets the item Icon and Description and displays it on the right side of the inventory screen.
	//Checks if any of the "content" object's children is toggled on, and if so, sets the ItemIconBox to the ItemIcon 
	//of the child's BaseItem's component, and sets the ItemDescriptionBox to the ItemDescription of the child's BaseItem's component
	//If no object is toggled on, the ItemIconBox will be set the "emptyIcon" sprite and ItemDescriptionBox will be set to an empty string.
	void SetItemIconAndDescription () 
	{

		foreach (Transform child in content.transform) 
		{
			Toggle childToggle = child.GetComponent<Toggle> ();
			Text ItemSlotTextAmount = child.transform.FindChild("text_ItemAmount").GetComponent<Text>();
			BaseItem childBaseItemScript = child.GetComponent<BaseItem> ();
			if (childToggle.isOn) 
			{
				selectedItemSlot = child;
				ItemDescriptionBox.text = childBaseItemScript.ItemDescription;
				ItemIconBox.sprite = childBaseItemScript.ItemSprite;
				if (childBaseItemScript.ItemType == BaseItem.ItemTypes.CONSUMABLE || childBaseItemScript.ItemType == BaseItem.ItemTypes.WEAPON ||
					childBaseItemScript.ItemType == BaseItem.ItemTypes.ARMOUR) 
				{
					UseEquipButton.gameObject.SetActive (true);
				}
				return;
			}
			else if (!childToggle.isOn)
			{
				UseEquipButton.gameObject.SetActive(false);
				ItemDescriptionBox.text = ""; //
				ItemIconBox.sprite = emptyIcon; //Sets the ItemIconBox to the "emptyIcon" sprite
			}
		}
	}

	public void UseEquip()
	{
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		Text ItemSlotTextAmount = selectedItemSlot.transform.FindChild("text_ItemAmount").GetComponent<Text>();
		if (selectedItemSlotBaseItemScript.ItemType == BaseItem.ItemTypes.CONSUMABLE) 
		{
			selectedItemSlotBaseItemScript.ItemQuantity -= 1;
			print ("health to restore: " + selectedItemSlotBaseItemScript.HealthToRestore);
			PlayerHealthManagerScript.playerCurrentHealth += selectedItemSlotBaseItemScript.HealthToRestore;
			print ("yummy!");
			ItemSlotTextAmount.text = ("(x" + selectedItemSlotBaseItemScript.ItemQuantity + ")");
		}

		if (selectedItemSlotBaseItemScript.ItemQuantity == 0) 
		{
			PlayerInventory.Remove (selectedItemSlotBaseItemScript);
			Destroy (selectedItemSlot.gameObject);
		}

		foreach (Transform child in content.transform) 
		{			
			
		}
	}



	public void AddItemToInventory(int id, int Quantity = 1)
	{

		if (content.transform.childCount > 0) 
		{
			bool found = false;
			print ("Found: " + found);
			foreach (Transform child in content.transform) 
			{
				print ("Child: " + child);
				BaseItem childBaseItemScript = child.GetComponent<BaseItem> ();
				if (childBaseItemScript.ItemName == ItemDatabase.ListOfItems [id].ItemName && ItemDatabase.ListOfItems [id].Stackable == true) 
				{
					found = true;
					print ("Found: " + found);
					childBaseItemScript.ItemQuantity = childBaseItemScript.ItemQuantity + Quantity;
					Text childTextAmount = child.transform.FindChild ("text_ItemAmount").GetComponent<Text> ();
					childTextAmount.text = ("(x" + childBaseItemScript.ItemQuantity + ")");
				} 

			}
			if (!found) 
			{
				GameObject itemSlot = Instantiate(itemSlotPrefab) as GameObject; 
				itemSlot.name = itemSlotPrefab.ToString();
				BaseItem itemSlotBaseItemScript = itemSlot.GetComponent<BaseItem> ();
				itemSlot.transform.SetParent(content.transform);
				itemSlot.name = itemSlotBaseItemScript.ToString();
				itemSlot.GetComponent<Toggle> ().group = itemSlotToggleGroup;
				//		itemSlot.GetComponent<RectTransform> ().localPosition = new Vector3 (xPos, yPos, 0);
				//		yPos -= (int)itemSlot.GetComponent<RectTransform> ().rect.height;
				itemSlotBaseItemScript.ItemName = ItemDatabase.ListOfItems[id].ItemName;
				itemSlotBaseItemScript.ItemDescription = ItemDatabase.ListOfItems[id].ItemDescription;
				itemSlotBaseItemScript.ItemSprite = ItemDatabase.ListOfItems[id].ItemSprite;
				itemSlotBaseItemScript.ItemType = ItemDatabase.ListOfItems[id].ItemType;
				itemSlotBaseItemScript.Stackable = ItemDatabase.ListOfItems[id].Stackable;
				itemSlotBaseItemScript.HealthToRestore = ItemDatabase.ListOfItems[id].HealthToRestore;


				itemSlotBaseItemScript.ItemQuantity = Quantity;
				PlayerInventory.Add (itemSlotBaseItemScript);


				itemSlotTextName = itemSlot.GetComponentInChildren<Text> ();
				itemSlotTextName.text = itemSlotBaseItemScript.ItemName;
				itemSlotTextAmount = itemSlot.transform.FindChild("text_ItemAmount").GetComponent<Text>();
				itemSlotTextAmount.text = ("(x" + itemSlotBaseItemScript.ItemQuantity + ")");

				itemSlotIcon = itemSlot.transform.FindChild("ItemIcon").GetComponent<Image> ();
				itemSlotIcon.sprite = ItemDatabase.ListOfItems[id].ItemSprite;
			}
		}
		else 
		{
			GameObject itemSlot = Instantiate(itemSlotPrefab) as GameObject; 
			itemSlot.name = itemSlotPrefab.ToString();
			BaseItem itemSlotBaseItemScript = itemSlot.GetComponent<BaseItem> ();
			itemSlot.transform.SetParent(content.transform);
			itemSlot.name = itemSlotBaseItemScript.ToString();
			itemSlot.GetComponent<Toggle> ().group = itemSlotToggleGroup;
			//		itemSlot.GetComponent<RectTransform> ().localPosition = new Vector3 (xPos, yPos, 0);
			//		yPos -= (int)itemSlot.GetComponent<RectTransform> ().rect.height;
			itemSlotBaseItemScript.ItemName = ItemDatabase.ListOfItems[id].ItemName;
			itemSlotBaseItemScript.ItemDescription = ItemDatabase.ListOfItems[id].ItemDescription;
			itemSlotBaseItemScript.ItemSprite = ItemDatabase.ListOfItems[id].ItemSprite;
			itemSlotBaseItemScript.ItemType = ItemDatabase.ListOfItems[id].ItemType;
			itemSlotBaseItemScript.Stackable = ItemDatabase.ListOfItems[id].Stackable;
			itemSlotBaseItemScript.HealthToRestore = ItemDatabase.ListOfItems[id].HealthToRestore;


			itemSlotBaseItemScript.ItemQuantity = Quantity;
			PlayerInventory.Add (itemSlotBaseItemScript);


			itemSlotTextName = itemSlot.GetComponentInChildren<Text> ();
			itemSlotTextName.text = itemSlotBaseItemScript.ItemName;
			itemSlotTextAmount = itemSlot.transform.FindChild("text_ItemAmount").GetComponent<Text>();
			itemSlotTextAmount.text = ("(x" + itemSlotBaseItemScript.ItemQuantity + ")");

			itemSlotIcon = itemSlot.transform.FindChild("ItemIcon").GetComponent<Image> ();
			itemSlotIcon.sprite = ItemDatabase.ListOfItems[id].ItemSprite;
		}
}










	//Add Item function
	//Adds the specified item to the Player's Inventory.
	public void AddItem(int id, int Quantity = 1) //Parameters include the item id, and the quantity to add (set to 1 by default)
	{
		GameObject item = Instantiate(itemSlotPrefab) as GameObject; 
		BaseItem i = item.GetComponent<BaseItem> ();

		i.ItemName = ItemDatabase.ListOfItems[id].ItemName;
		i.ItemDescription = ItemDatabase.ListOfItems[id].ItemDescription;
		i.ItemSprite = ItemDatabase.ListOfItems[id].ItemSprite;
		i.ItemType = ItemDatabase.ListOfItems[id].ItemType;
		i.Stackable = ItemDatabase.ListOfItems[id].Stackable;

		i.ItemQuantity = Quantity;
		PlayerInventory.Add (i);

		foreach (Transform child in content.transform) {

		}
			

	}

	public void UpdateInventorySlotsInWindow()
	{


		foreach (Transform child in content.transform) {
			Destroy (child.gameObject);
		}

		for(int i = 0; i < PlayerInventory.Count ; i++) //gameobject find and look for the player's inventory and get the count of the inventory.
		{
			//Debug.Log ("ItemNameasdasd: " + PlayerInventory [i].ItemName);
			itemSlot = (GameObject)Instantiate(itemSlotPrefab);
			itemSlot.name = i.ToString();
			itemSlot.GetComponent<BaseItem> ().ItemName = itemSlot.name;

			itemSlotTextName = itemSlot.GetComponentInChildren<Text> ();
			itemSlotTextName.text = PlayerInventory [i].ItemName;

			itemSlotTextAmount = itemSlot.transform.FindChild("text_ItemAmount").GetComponent<Text>();
			itemSlotTextAmount.text = ("(x" + PlayerInventory[i].ItemQuantity + ")");

			itemSlotIcon = itemSlot.transform.FindChild("ItemIcon").GetComponent<Image> ();
			itemSlotIcon.sprite = PlayerInventory [i].ItemSprite;

			itemSlot.GetComponent<Toggle> ().group = itemSlotToggleGroup;
			itemSlot.transform.SetParent(content.transform);
			itemSlot.GetComponent<RectTransform> ().localPosition = new Vector3 (xPos, yPos, 0);
			yPos -= (int)itemSlot.GetComponent<RectTransform> ().rect.height;
		}
	}





	void tempfunction () 
	{
		foreach (Transform child in content.transform) 
		{
			Toggle childToggle = child.GetComponent<Toggle> ();
			Text ItemSlotTextAmount = child.transform.FindChild("text_ItemAmount").GetComponent<Text>();
			BaseItem childBaseItemScript = child.GetComponent<BaseItem> ();
			if (childToggle.isOn) 
			{
				ItemDescriptionBox.text = childBaseItemScript.ItemDescription;
				ItemIconBox.sprite = childBaseItemScript.ItemSprite;
				if (childBaseItemScript.ItemType == BaseItem.ItemTypes.CONSUMABLE || childBaseItemScript.ItemType == BaseItem.ItemTypes.WEAPON ||
					childBaseItemScript.ItemType == BaseItem.ItemTypes.ARMOUR) 
				{
					UseEquipButton.gameObject.SetActive (true);
				}
				if (UseEquipPressed) 
				{ 
					if (childBaseItemScript.ItemType == BaseItem.ItemTypes.CONSUMABLE) 
					{
						childBaseItemScript.ItemQuantity -= 1;
						print ("health to restore: " + childBaseItemScript.HealthToRestore);
						PlayerHealthManagerScript.playerCurrentHealth += childBaseItemScript.HealthToRestore;
						print ("yummy!");
						ItemSlotTextAmount.text = ("(x" + childBaseItemScript.ItemQuantity + ")");
						UseEquipPressed = false;
						return;
					}

				}
				if (childBaseItemScript.ItemQuantity == 0) 
				{
					PlayerInventory.Remove (childBaseItemScript);
					Destroy (child.gameObject);
					return;
				}
				return;
			}
			else if (!childToggle.isOn)
			{
				UseEquipButton.gameObject.SetActive(false);
				ItemDescriptionBox.text = "";
				ItemIconBox.sprite = emptyIcon;
			}

		}
	}





}
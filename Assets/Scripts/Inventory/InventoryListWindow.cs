using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryListWindow : MonoBehaviour {
	public List<BaseItem> PlayerInventory = new List<BaseItem>(); // The Player's Inventory

	public PlayerHealthManager PlayerHealthManagerScript;
	public PlayerStats PlayerStatsScript;
	public ItemRecipeDatabase ItemRecipeDatabaseScript;


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

	public Transform EquippedWeapon;
	public Text EquippedWeaponText;

	public Transform EquippedArmour;
	public Text EquippedArmourText;



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
			Text ItemSlotTextAmount = child.transform.Find("text_ItemAmount").GetComponent<Text>();
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


	public void RemoveItemFromInventory(GameObject item, int amount)
	{
		BaseItem itemBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();

		itemBaseItemScript.ItemQuantity -= amount;
		ItemSlotTextAmount.text = ("(x" + itemBaseItemScript.ItemQuantity + ")");

		if (itemBaseItemScript.ItemQuantity == 0) 
		{
			PlayerInventory.Remove (itemBaseItemScript);
			Destroy (selectedItemSlot.gameObject);
		}
	}



	public void UseEquip()
	{
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
		if (selectedItemSlotBaseItemScript.ItemType == BaseItem.ItemTypes.CONSUMABLE) 
		{
			selectedItemSlotBaseItemScript.ItemQuantity -= 1;
			PlayerHealthManagerScript.playerCurrentHealth += selectedItemSlotBaseItemScript.HealthToRestore;
			ItemSlotTextAmount.text = ("(x" + selectedItemSlotBaseItemScript.ItemQuantity + ")");
		}

		if (selectedItemSlotBaseItemScript.ItemType == BaseItem.ItemTypes.WEAPON) 
		{
			if (selectedItemSlot == EquippedWeapon) {
				UnequipWeapon ();
			} 
			else 
			{
				EquipWeapon(selectedItemSlotBaseItemScript.ArmourWeaponType, selectedItemSlotBaseItemScript.WeaponDamage);
				EquippedWeapon = selectedItemSlot;
			}


		}

		if (selectedItemSlotBaseItemScript.ItemType == BaseItem.ItemTypes.ARMOUR) 
		{
			if (selectedItemSlot == EquippedArmour) {
				UnequipArmour ();
			} 
			else 
			{
				EquipArmour (selectedItemSlotBaseItemScript.ArmourWeaponType);
				EquippedArmour = selectedItemSlot;
			}

		}

		if (selectedItemSlotBaseItemScript.ItemQuantity == 0) 
		{
			PlayerInventory.Remove (selectedItemSlotBaseItemScript);
			Destroy (selectedItemSlot.gameObject);
		}
	}

	public void EquipWeapon(string type, int damage)
	{
		if (EquippedWeapon != null) 
		{
			EquippedWeaponText = EquippedWeapon.transform.Find("text_ItemAmount").GetComponent<Text>();
			EquippedWeaponText.text = "";
		}

		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		PlayerStatsScript.EquipWeapon (selectedItemSlotBaseItemScript.ArmourWeaponType, selectedItemSlotBaseItemScript.WeaponDamage);
		ItemSlotTextAmount.text = "(Equipped)";

	}

	public void EquipArmour(string type)
	{
		if (EquippedArmour != null) 
		{
			EquippedArmourText = EquippedArmour.transform.Find("text_ItemAmount").GetComponent<Text>();
			EquippedArmourText.text = "";
		}

		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		PlayerStatsScript.EquipArmour (selectedItemSlotBaseItemScript.ArmourWeaponType);
		ItemSlotTextAmount.text = "(Equipped)";
	}

	public void UnequipWeapon()
	{
		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		PlayerStatsScript.UnequipWeapon ();
		ItemSlotTextAmount.text = "";
		EquippedWeapon = null;
	}

	public void UnequipArmour()
	{
		Text ItemSlotTextAmount = selectedItemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
		BaseItem selectedItemSlotBaseItemScript = selectedItemSlot.GetComponent<BaseItem> ();
		PlayerStatsScript.UnequipArmour ();
		ItemSlotTextAmount.text = "";
		EquippedArmour = null;
	}


	public void AddItemToInventory(int id, int Quantity = 1)
	{

		if (content.transform.childCount > 0) 
		{
			bool found = false;
			//print ("Found: " + found);
			foreach (Transform child in content.transform) 
			{
				//print ("Child: " + child);
				BaseItem childBaseItemScript = child.GetComponent<BaseItem> ();
				if (childBaseItemScript.ItemName == ItemDatabase.ListOfItems [id].ItemName && ItemDatabase.ListOfItems [id].Stackable == true) 
				{
					found = true;
					print ("Found: " + found);
					childBaseItemScript.ItemQuantity = childBaseItemScript.ItemQuantity + Quantity;
					Text childTextAmount = child.transform.Find ("text_ItemAmount").GetComponent<Text> ();
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
				itemSlotBaseItemScript.ArmourWeaponType = ItemDatabase.ListOfItems[id].ArmourWeaponType;
				itemSlotBaseItemScript.WeaponDamage = ItemDatabase.ListOfItems[id].WeaponDamage;



				itemSlotBaseItemScript.ItemQuantity = Quantity;
				PlayerInventory.Add (itemSlotBaseItemScript);


				itemSlotTextName = itemSlot.GetComponentInChildren<Text> ();
				itemSlotTextName.text = itemSlotBaseItemScript.ItemName;
				itemSlotTextAmount = itemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
				if (itemSlotBaseItemScript.Stackable == true) {
					itemSlotTextAmount.text = ("(x" + itemSlotBaseItemScript.ItemQuantity + ")");
				} 
				else 
				{
					itemSlotTextAmount.text = "";
				}

				itemSlotIcon = itemSlot.transform.Find("ItemIcon").GetComponent<Image> ();
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
			itemSlotBaseItemScript.ArmourWeaponType = ItemDatabase.ListOfItems[id].ArmourWeaponType;
			itemSlotBaseItemScript.WeaponDamage = ItemDatabase.ListOfItems[id].WeaponDamage;




			itemSlotBaseItemScript.ItemQuantity = Quantity;
			PlayerInventory.Add (itemSlotBaseItemScript);


			itemSlotTextName = itemSlot.GetComponentInChildren<Text> ();
			itemSlotTextName.text = itemSlotBaseItemScript.ItemName;
			itemSlotTextAmount = itemSlot.transform.Find("text_ItemAmount").GetComponent<Text>();
			itemSlotTextAmount.text = ("(x" + itemSlotBaseItemScript.ItemQuantity + ")");

			itemSlotIcon = itemSlot.transform.Find("ItemIcon").GetComponent<Image> ();
			itemSlotIcon.sprite = ItemDatabase.ListOfItems[id].ItemSprite;
		}
	}
}
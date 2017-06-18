using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryWindow : MonoBehaviour {

	public int startingPosX;
	public int startingPosY;
	public int slotCntPerPage;
	public int slotCntLength;
	public GameObject itemSlotPrefab;
	public ToggleGroup itemSlotToggleGroup;

	private int xPos;
	private int yPos;
	private GameObject itemSlot;
	private int itemSlotCnt;
	private List<GameObject> inventorySlots;

	private List<BaseItem> playerInventory;




	// Use this for initialization
	void Start () {
		CreateInventorySlotsInWindow();
		//AddItemsFromInventory();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CreateInventorySlotsInWindow()
	{
		inventorySlots = new List<GameObject> ();
		xPos = startingPosX;
		yPos = startingPosY;
		for(int i = 0; i < slotCntPerPage; i++)
		{
			itemSlot = (GameObject)Instantiate(itemSlotPrefab);
			itemSlot.name = "Empty";
			itemSlot.GetComponent<Toggle> ().group = itemSlotToggleGroup;
			inventorySlots.Add (itemSlot);
			itemSlot.transform.SetParent(this.gameObject.transform);
			itemSlot.GetComponent<RectTransform> ().localPosition = new Vector3 (xPos, yPos, 0);
			xPos += (int)itemSlot.GetComponent<RectTransform> ().rect.width;
			itemSlotCnt++;
			if (itemSlotCnt % slotCntLength == 0) 
			{
				itemSlotCnt = 0;
				yPos -= (int)itemSlot.GetComponent<RectTransform> ().rect.width;
				xPos = startingPosX;
			}


		}
	}


//	private void AddItemsFromInventory()
//	{
//		BasePlayer basePlayerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<BasePlayer> ();
//		playerInventory = basePlayerScript.ReturnPlayerInventory ();
//		for (int i = 0; i < playerInventory.Count; i++) 
//		{
//			if (inventorySlots[i].name == "Empty") 
//			{
//				inventorySlots [i].name = i.ToString();//playerInventory[i].ItemName;
//				//look at the item and add the proper icon to display
//			}
//				
//		}
//			
//	}


}


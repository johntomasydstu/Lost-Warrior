using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideItemCraftScreen : MonoBehaviour {

	public StatsScreenShowHide StatsScreenShowHideScript;
	public ShowHideInventory ShowHideInventoryScript;


	public Transform canvas;
	public CanvasGroup CanvasGroup;

	public bool itemCraftScreenShowing = false;


	void Awake ()
	{
		itemCraftScreenShowing = false; 
		//invShowing = false;
		CanvasGroup = canvas.GetComponent<CanvasGroup> ();
		print (itemCraftScreenShowing);

	}

	void Start ()
	{
		CanvasGroup.alpha = 0f;
		CanvasGroup.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("g")) 
		{
			//print("'i' key pressed!");
			//Checks if the inventory is not showing and if the Stat's Screen is also not showing
			//and if so, shows the inventory, but if the inventory is already showing or if the
			//Stat's Screen is already showing, it hides the inventory.
			if (!itemCraftScreenShowing && !StatsScreenShowHideScript.StatScreenShowing && !ShowHideInventoryScript.invShowing) 
			{
				//print("Inventory Showing");
				CanvasGroup.alpha = 0.75f;
				CanvasGroup.blocksRaycasts = true;
				itemCraftScreenShowing = true;
			} 
			else 
			{
				//print("Inventory Not Showing");
				CanvasGroup.alpha = 0f;
				CanvasGroup.blocksRaycasts = false;
				itemCraftScreenShowing = false;

			}

		} 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInventory : MonoBehaviour {

	public StatsScreenShowHide StatsScreenShowHideScript;

	public Transform canvas;
	public CanvasGroup CanvasGroup;

	public bool invShowing = false;


	void Awake ()
	{
		invShowing = false; 
		//invShowing = false;
		CanvasGroup = canvas.GetComponent<CanvasGroup> ();
		print (invShowing);

	}

	void Start ()
	{
		CanvasGroup.alpha = 0f;
		CanvasGroup.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("i")) 
		{
			print("'i' key pressed!");
			//Checks if the inventory is not showing and if the Stat's Screen is also not showing
			//and if so, shows the inventory, but if the inventory is already showing or if the
			//Stat's Screen is already showing, it hides the inventory.
			if (!invShowing && !StatsScreenShowHideScript.StatScreenShowing) 
			{
				//print("Inventory Showing");
				CanvasGroup.alpha = 0.75f;
				CanvasGroup.blocksRaycasts = true;
				invShowing = true;
			} 
			else 
			{
				//print("Inventory Not Showing");
				CanvasGroup.alpha = 0f;
				CanvasGroup.blocksRaycasts = false;
				invShowing = false;

			}

		} 
	}
}
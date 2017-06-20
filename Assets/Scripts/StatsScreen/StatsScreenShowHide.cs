using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScreenShowHide : MonoBehaviour {

	public ShowHideInventory ShowHideInventoryScript;
	public ShowHideItemCraftScreen ShowHideItemCraftScreenScript;


	public Transform canvas;
	public CanvasGroup CanvasGroup;

	public bool StatScreenShowing = false;

	void Awake ()
	{
		StatScreenShowing = false;
		CanvasGroup = canvas.GetComponent<CanvasGroup> ();
	}

	void Start ()
	{
		CanvasGroup.alpha = 0f;
		CanvasGroup.blocksRaycasts = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("u")) 
		{
			if (!StatScreenShowing && !ShowHideInventoryScript.invShowing && !ShowHideItemCraftScreenScript.itemCraftScreenShowing) 
			{
				CanvasGroup.alpha = 0.75f;
				CanvasGroup.blocksRaycasts = true;
				StatScreenShowing = true;
				Time.timeScale = 0;
			} 
			else 
			{
				CanvasGroup.alpha = 0f;
				CanvasGroup.blocksRaycasts = false;
				StatScreenShowing = false;
				Time.timeScale = 1;

			}

		} 
	}
}

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
			if (!invShowing && !StatsScreenShowHideScript.StatScreenShowing) 
			{
				CanvasGroup.alpha = 0.75f;
				CanvasGroup.blocksRaycasts = true;
				invShowing = true;
			} 
			else 
			{
				CanvasGroup.alpha = 0f;
				CanvasGroup.blocksRaycasts = false;
				invShowing = false;

			}

		} 
	}
}
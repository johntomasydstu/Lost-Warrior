using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {
	public PlayerStats PlayerStatsScript;
	public Canvas WinGameCanvas;

	// Use this for initialization
	void OnTriggerEnter2D () {
		if (PlayerStatsScript.currentLevel >= 12) 
		{
			WinGameCanvas.gameObject.SetActive(true);
		}
	}

}

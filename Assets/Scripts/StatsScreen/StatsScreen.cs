using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour {

	public PlayerStats PlayerStatsScript;

	public Text text_PlayerLevel;
	public Text text_PlayerHealthStat;
	public Text text_PlayerAttackStat;


	// Use this for initialization
	void Start () {
		text_PlayerLevel.text = "Player Level = "  + PlayerStatsScript.currentLevel.ToString();


		if (PlayerStatsScript.modifiedHealthStat > 0) {
			text_PlayerHealthStat.text = "Health  = " + PlayerStatsScript.baseHealthStat.ToString () 
				+ " + " + PlayerStatsScript.modifiedHealthStat.ToString ();
		} 
		else 
		{
			text_PlayerHealthStat.text = "Health  = " + PlayerStatsScript.baseHealthStat.ToString ();
		}



		if (PlayerStatsScript.modifiedAttackStat > 0) 
		{
			text_PlayerAttackStat.text = "Attack  = "  + PlayerStatsScript.baseAttackStat.ToString() + " + " 
				+ PlayerStatsScript.modifiedAttackStat .ToString() ;
		}
		else 
		{
			text_PlayerAttackStat.text = "Attack  = "  + PlayerStatsScript.baseAttackStat.ToString();
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		text_PlayerLevel.text = "Player Level = "  + PlayerStatsScript.currentLevel.ToString();


		if (PlayerStatsScript.modifiedHealthStat > 0) {
			text_PlayerHealthStat.text = "Health  = " + PlayerStatsScript.baseHealthStat.ToString () 
				+ " + " + PlayerStatsScript.modifiedHealthStat.ToString ();
		} 
		else 
		{
			text_PlayerHealthStat.text = "Health  = " + PlayerStatsScript.baseHealthStat.ToString ();
		}



		if (PlayerStatsScript.modifiedAttackStat > 0) 
		{
			text_PlayerAttackStat.text = "Attack  = "  + PlayerStatsScript.baseAttackStat.ToString() + " + " 
				+ PlayerStatsScript.modifiedAttackStat .ToString() ;
		}
		else 
		{
			text_PlayerAttackStat.text = "Attack  = "  + PlayerStatsScript.baseAttackStat.ToString();
		}
	}
}

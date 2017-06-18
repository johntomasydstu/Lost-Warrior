using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public PlayerStats PlayerStatsScript;

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public SpriteRenderer spriteRender;


	// Use this for initialization
	void Start () {

		playerMaxHealth = PlayerStatsScript.HealthStat;
		playerCurrentHealth = playerMaxHealth;


		spriteRender = GetComponent<SpriteRenderer>();
	


	}
	
	// Update is called once per frame
	void Update () {
		
		playerMaxHealth = PlayerStatsScript.HealthStat;

		if (playerCurrentHealth <= 0) 
		{
			gameObject.SetActive (false);

		}

	}

	public void hit()
	{
		WaitForSeconds (1);
	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	IEnumerator WaitForSeconds(int seconds) {
		Debug.Log("Before Waiting for seconds");
//		spriteRender().color = Color.HSVToRGB(0,255,255);
		yield return new WaitForSeconds(seconds);
		//GetComponent<SpriteRenderer> ().color = Color.white;
		Debug.Log("After Waiting for Seconds");
	}
}

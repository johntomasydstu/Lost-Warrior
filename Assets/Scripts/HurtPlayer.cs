using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	//Amount of health to take away from the player
	public int damageToGive;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When an object touches the Collider
	void OnCollisionEnter2D(Collision2D other) 
	{
		//If the object's name is "Player"
		if (other.gameObject.name == "Player") 
		{
			//Accesses the "HurtPlayer" function in the "PlayerHealthManager" script of the player, and tells the script how much damage to take away
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); 
			other.gameObject.GetComponent<PlayerHealthManager> ().hit (); 
		}
	}
}


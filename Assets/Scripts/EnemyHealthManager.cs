using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	
	public int MaxHealth;
	public int CurrentHealth;

	public int ExpToGive;

	public InventoryListWindow InventoryListWindowScript;

	private PlayerStats thePlayerLevel;


	// Use this for initialization
	void Start () {

		CurrentHealth = MaxHealth;

		thePlayerLevel = FindObjectOfType<PlayerStats> ();

	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) 
		{
			Destroy (gameObject);
			InventoryListWindowScript.AddItemToInventory(2, 1); //Adds an item with the id of 2 (Small Health Potion) to the player's inventory.

			thePlayerLevel.AddExperience (ExpToGive);
		}

	}

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}

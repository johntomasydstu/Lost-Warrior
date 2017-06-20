using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	
	public int MaxHealth; //Max health of the monster
	public int CurrentHealth; //Current health of the monster

	public int ExpToGive; //Exp that the monster gives upon being killed

	public InventoryListWindow InventoryListWindowScript;

	private PlayerStats PlayerStats; 

	public int delay; //Delay until the monster respawns

	public int slimeLevel;


	// Use this for initialization
	void Start () {

		MaxHealth = MaxHealth * slimeLevel;

		CurrentHealth = MaxHealth;

		PlayerStats = FindObjectOfType<PlayerStats> ();

	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) 
		{
			InventoryListWindowScript.AddItemToInventory(2, 1); //Adds an item with the id of 2 (Small Health Potion) to the player's inventory.
//			InventoryListWindowScript.AddItemToInventory(3, 1); //Adds an item with the id of 3 (Bronze Sword) to the player's inventory.
//			InventoryListWindowScript.AddItemToInventory(4, 1); //Adds an item with the id of 4 (Bronze Armour) to the player's inventory.
//			InventoryListWindowScript.AddItemToInventory(5, 1); //Adds an item with the id of 5 (Iron Sword) to the player's inventory.
//			InventoryListWindowScript.AddItemToInventory(6, 1); //Adds an item with the id of 6 (Iron Armour) to the player's inventory.


			PlayerStats.AddExperience (ExpToGive * slimeLevel); //Gives exp to player

			float slimePosX = gameObject.transform.position.x;
			float slimePosY = gameObject.transform.position.y;
			float slimePosZ = gameObject.transform.position.z;

			Destroy(this.gameObject); 
				
		}

	}

	public void HurtEnemy(int damageToGive)
	{
		CurrentHealth -= damageToGive; //Damages the enemy
	}

}

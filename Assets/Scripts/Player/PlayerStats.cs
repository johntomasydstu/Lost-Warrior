using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

	public int currentLevel; // Current level of the player
	public int currentExp; //Current exp of the player
	public int[] toLevelUp; //How much xp is needed to level up

	public int baseAttackStat; //Player's attack
	public int baseHealthStat; //Player's health

	public int modifiedAttackStat; //Amount of extra damage that the player can deal through equipped weapons
	public int modifiedHealthStat; //Amount of extra health that the player has through equipped armour

	public int AttackStat; //= baseAttackStat + modifiedAttackStat;
	public int HealthStat; //= baseHealthStat + modifiedHealthStat;

	public Slider ExpBar;
	public Text ExpText;
	public Text LevelText; //The Text Object that shows the Player's Level

	public GameObject Sword;
	public GameObject Armour;

	//Colors
	private Color32 Invisible = new Color32(255, 255, 255, 0);
	private Color32 Bronze = new Color32(197, 106, 9, 255);
	private Color32 White = new Color32(255, 255, 255, 255);

	//Sword.GetComponent<Renderer> ().material.color = Invisible;
	//Armour.GetComponent<Renderer> ().material.color = Invisible;



	void Awake ()
	{
		
		ExpText.text = "" + currentExp + "XP / " + toLevelUp [currentLevel] + "XP";
		ExpBar.maxValue = toLevelUp[currentLevel];
		ExpBar.value = currentExp;
		ExpText.text = "" + currentExp + "XP / " + toLevelUp [currentLevel] + "XP";


		LevelText.text = currentLevel.ToString();

		if (currentExp >= toLevelUp [currentLevel]) 
		{
			currentLevel++;

			ExpBar.value = 0;

		}

		baseAttackStat = 5 + (currentLevel - 1);
		baseHealthStat = 30 + (currentLevel * 5);

		AttackStat = baseAttackStat + modifiedAttackStat;
		HealthStat = baseHealthStat + modifiedHealthStat;	
	}

	void Start ()
	{
		Sword.GetComponent<Renderer> ().material.color = Invisible;
		Armour.GetComponent<Renderer> ().material.color = Invisible;

	}
	

	//Equips a weapon. Checks the "type" parameter and changes the colour of the "Sword" object to correct 
	//colour (e.g if bronze sets the colour to bronze), and sets the "modifiedAttackStat" variable
	//to the damage parameter.
	public void EquipWeapon (string type, int damage) 
	{
		modifiedAttackStat = damage; //Sets the player's modifiedAttackStat variable 
		print ("modifiedAttackStat: " + modifiedAttackStat);
		if (type == "Bronze")
		{
			print ("Type: " + type);
			Sword.GetComponent<Renderer> ().material.color = Bronze; //Sets the Sword's colour to "Bronze".
		}
		if (type == "Iron") 
		{
			print ("Type: " + type);
			Sword.GetComponent<Renderer> ().material.color = White; //Sets the Sword's colour to "White"
		}

	}

	//Equips Armour. Checks the "type" parameter and changes the colour of the "Armour" object to correct 
	//colour (e.g if bronze sets the colour to bronze)
	public void EquipArmour (string type) 
	{
		if (type == "Bronze") 
		{
			print ("Type: " + type);
			this.GetComponent<Renderer> ().material.color = Invisible; //Makes the player invisible.
			Armour.GetComponent<Renderer> ().material.color = Bronze; //Sets the Armour's colour to "Bronze".
		}

		if(type == "Iron") 
		{
			print ("Type: " + type);
			this.GetComponent<Renderer> ().material.color = Invisible; //Makes the player invisible.
			Armour.GetComponent<Renderer> ().material.color = White; //Sets the Armour's colour to "White".
		}

	}

	public void UnequipWeapon () 
	{
		modifiedAttackStat = 0; //Sets the player's modifiedAttackStat variable 
		Sword.GetComponent<Renderer> ().material.color = Invisible; // Makes the Sword invisible.
	}

	public void UnequipArmour () 
	{
		this.GetComponent<Renderer> ().material.color = White; //Makes the player visible.
		Armour.GetComponent<Renderer> ().material.color = Invisible; // Makes the Armour invisible.
	}


	// Update is called once per frame
	void Update () {



		ExpText.text = "" + currentExp + "XP / " + toLevelUp [currentLevel] + "XP";
		ExpBar.maxValue = toLevelUp[currentLevel];
		ExpBar.value = currentExp;
		ExpText.text = "" + currentExp + "XP / " + toLevelUp [currentLevel] + "XP";


		LevelText.text = currentLevel.ToString();

		if (currentExp >= toLevelUp [currentLevel]) 
		{
			print ("CurrentLevel: " + currentLevel);
			currentLevel++;
			print ("CurrentLevel: " + currentLevel);
			ExpBar.value = 0;

		}

		baseAttackStat = 5 + (currentLevel - 1);
		baseHealthStat = 30 + (currentLevel * 5);

		AttackStat = baseAttackStat + modifiedAttackStat;
		HealthStat = baseHealthStat + modifiedHealthStat;
			
	}

	public void AddExperience(int ExpToAdd)
	{
		currentExp += ExpToAdd;

	}




}

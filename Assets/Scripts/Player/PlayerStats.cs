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
		HealthStat = baseHealthStat + modifiedHealthStat;	}


	// Update is called once per frame
	void Update () {

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

	public void AddExperience(int ExpToAdd)
	{
		currentExp += ExpToAdd;
	}




}

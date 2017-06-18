using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public EnemyHealthManager enemyHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthBar.maxValue = enemyHealth.MaxHealth;
		healthBar.value = enemyHealth.CurrentHealth;
		HPText.text = "HP: " + enemyHealth.CurrentHealth + "/" + enemyHealth.MaxHealth;
		
	}
}

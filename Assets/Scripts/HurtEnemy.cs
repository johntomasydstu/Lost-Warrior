using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {


	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;

	//How long the attack goes for (should be the same as the duration of the attack animation)
	private float attackTime;

	// Use this for initialization
	void Start () {
		damageToGive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AttackStat;
	}
	
	// Update is called once per frame
	void Update () {
		
		damageToGive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AttackStat;

		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy" && Input.GetKeyDown ("j")) 
		{
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

		}
	}
		
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class chopTree : MonoBehaviour {

	public SpriteRenderer treetop;
	public SpriteRenderer treelower;
	public Sprite treestump;
	public Sprite temp;

	public Transform canvas;


	public float regenDelay = 3.0f;
	private bool chopped;

	public InventoryListWindow InventoryListWindowScript;


	void Start()
	{
		//InventoryListWindowScript = GameObject.Find("CanvasInventory/InventoryListWindow").GetComponent<InventoryListWindow>();
		chopped = false;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKeyDown ("k")) 
		{
			if (chopped == false) 
			{
				treetop.enabled = false; //Makes the top of the tree invisible
				treelower.sprite = treestump; //Makes the lower part of the tree turn into a tree stump	
				chopped = true;
				print ("Chopped!!");

				InventoryListWindowScript.AddItemToInventory(0, 1); //Adds an item with the id of 0 (wood) to the player's inventory.

				StartCoroutine ("waitForSeconds",regenDelay);
			}

		}
	}

	IEnumerator waitForSeconds(float regenDelay)
	{
		yield return new WaitForSeconds(regenDelay);
		treetop.enabled = true; //Makes the top of the tree invisible
		treelower.sprite = temp; //Makes the lower part of the tree turn into top part of tree
		chopped = false;


	
	}
}
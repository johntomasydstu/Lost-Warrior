using UnityEngine;
using System.Collections;

public class mineRock : MonoBehaviour {

	public SpriteRenderer rock;
	public Sprite rock_empty;
	public Sprite temp;

	public float regenDelay = 3;
	private bool mined;

	public InventoryListWindow InventoryListWindowScript;




	void Start()
	{
		mined = false;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKeyDown ("k")) 
		{
			if (mined == false) 
			{
				rock.sprite = rock_empty; //Makes the lower part of the tree turn into a tree stump	
				mined = true;
				print ("Mined!!");

				InventoryListWindowScript.AddItemToInventory(1, 1); //Adds an item with the id of 1 (iron ore) to the player's inventory.

				StartCoroutine ("waitForSeconds",regenDelay);
			}

		}
	}

	IEnumerator waitForSeconds(float regenDelay)
	{
		yield return new WaitForSeconds(regenDelay);
		rock.sprite = temp; //Makes the lower part of the tree turn into a tree stump	
		mined = false;
	}
}

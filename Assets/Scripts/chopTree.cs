using UnityEngine;
using System.Collections;

public class chopTree : MonoBehaviour {

	public SpriteRenderer treetop;
	public SpriteRenderer treelower;
	public Sprite treestump;
	public Sprite temp;

	public float regenDelay = 3;
	private bool chopped;



	void Start()
	{
		chopped = false;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown ("j")) 
		{
			if (chopped == false) 
			{
				treetop.enabled = false; //Makes the top of the tree invisible
				treelower.sprite = treestump; //Makes the lower part of the tree turn into a tree stump	
				chopped = true;
				StartCoroutine ("waitForSeconds",regenDelay);
			}

		}
	}

	IEnumerator waitForSeconds(float regenDelay)
	{
		yield return new WaitForSeconds(regenDelay);
		treetop.enabled = true; //Makes the top of the tree invisible
		treelower.sprite = temp; //Makes the lower part of the tree turn into a tree stump	
		chopped = false;


	
	}
}
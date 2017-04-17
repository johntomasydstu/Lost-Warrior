using UnityEngine;
using System.Collections;

public class mineRock : MonoBehaviour {

	public SpriteRenderer rock;
	public Sprite rock_empty;
	public Sprite temp;

	public float regenDelay = 3;
	private bool mined;



	void Start()
	{
		mined = false;
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetKeyDown ("j")) 
		{
			if (mined == false) 
			{
				rock.sprite = rock_empty; //Makes the lower part of the tree turn into a tree stump	
				mined = true;
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

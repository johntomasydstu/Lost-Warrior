using UnityEngine;
using System.Collections;

public class weaponAnimControl : MonoBehaviour {

	Animator anim;

	public Vector2 lastMove;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();


	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"), 0f);
		}
		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) 
		{
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (movement_vector != Vector2.zero) {

			anim.SetBool ("IsWalking", true);
			anim.SetFloat ("Input_X", movement_vector.x);
			anim.SetFloat ("Input_Y", movement_vector.y);


		} else {

			anim.SetBool ("IsWalking", false);
		}


		anim.SetFloat ("LastMoveX",lastMove.x);
		anim.SetFloat ("LastMoveY",lastMove.y);


		if (Input.GetKeyDown(KeyCode.J)) 
		{
			attackTimeCounter = attackTime;
			attacking = true;
			anim.SetBool ("IsAttacking", true);
		}

		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;		
		}

		if (attackTimeCounter <= 0)
		{
			attacking = false;
			anim.SetBool ("IsAttacking", false);
		}

	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rbody;
	Animator anim;

	public Vector2 lastMove;

	private bool freezeMovement;

	public bool canMoveWhileAttacking;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	// Use this for initialization
	void Start () 
	{
		//print ("attacking = " + attacking);
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Checks if the player's "IsAttacking" animation variable is on
		print("isAttacking = " + anim.GetBool("IsAttacking"));

		if (!freezeMovement) 
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

			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);

			anim.SetFloat ("LastMoveX",lastMove.x);
			anim.SetFloat ("LastMoveY",lastMove.y);
				

			if (Input.GetKeyDown(KeyCode.J)) 
			{
				attackTimeCounter = attackTime;
				attacking = true;
				if (!canMoveWhileAttacking) 
				{
					freezeMovement = true;
				}
				//rbody.velocity = Vector2.zero;
				anim.SetBool ("IsAttacking", true);
				print("isAttacking = " + anim.GetBool("IsAttacking"));

			}


		}


		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;		
		}

		if (attackTimeCounter <= 0)
		{
			attacking = false;
			if (!canMoveWhileAttacking) 
			{
				freezeMovement = false;
			}
			anim.SetBool ("IsAttacking", false);
			print("isAttacking = " + anim.GetBool("IsAttacking"));

		}
	
	}
}

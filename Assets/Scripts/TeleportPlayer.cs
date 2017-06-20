using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportPlayer : MonoBehaviour {

	public GameObject Player;
	public Camera Camera;
	public Vector3 tpCoords;

	void OnTriggerEnter2D()
	{
		Player.transform.position = tpCoords;
		Camera.transform.position = tpCoords;

	}

}

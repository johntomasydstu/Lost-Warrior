﻿using UnityEngine;
using System.Collections;

public class itemPickUp : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Item") 
		{
			inventory.AddItem (other.GetComponent<Item> ());
		}
	}
}

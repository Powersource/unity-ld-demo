﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player;
	Rigidbody2D playerRigidbody;
	// Declaring this as public so I can change it in the editor
	// Warning! Don't set the value in here if you do that.
	// Then if you change it in the editor it's a pain to get
	// back control of it. Set it in the Start method instead
	public int speedConstant;

	// Use this for initialization
	void Start () {
		// Searches through the scene for a GameObject called "player"
		// and stores it for later use. It is slow and if you find
		// yourself using it outside of initialization you're
		// probably doing something wrong.
		player = GameObject.Find ("player");
		playerRigidbody = player.GetComponent<Rigidbody2D> ();
		speedConstant = 10;
	}
	
	// Update is called once per frame
	// Put visual-related stuff in here
	void Update () {
	
	}

	// This is called every physics tick.
	// Remember to multiply eg. movement distance by Time.deltaTime
	// to make the game run the same at different framerates.
	// If you do you will be better at coding games than
	// many professional studios.
	void FixedUpdate(){
		// Simple debug messages. Note that they can lag your game in
		// large quantities (not fun to debug (especially when it
		// causes unity to crash in the middle of it)).
		Debug.Log ("Player position: " + player.transform.position);

		// First we make the player able to walk right and left.
		// There are several ways to read input in unity but the GetAxis methods
		// are absolutely the simplest and most effective. This line reads from both
		// a/d/left/right as well as the left stick on a controller and when
		// people launch your game they get a little pre-built options menu
		// where they can set up their controls.
		// You can change the defaults in the editor through
		// Edit->Project Settings->Input
		// There are also many other interesting things in the project settings.
		float horizontalInputDir = Input.GetAxisRaw ("Horizontal");
		// Create a new Vector2 object (2-dimensional vector)
		// with our horizontal input on the x-axis and the current
		// y-velocity on the y-axis
		Vector2 direction = new Vector2 (horizontalInputDir * speedConstant, playerRigidbody.velocity.y);
		// Set the player GameObject's velocity in the direction
		// of travel                             //times the time since the last time we moved it.
		// And yes java people, we are multiplying an object.
		playerRigidbody.velocity = direction;

		// Then we make the player able to jump
		// Saves the vertical input i.e. up/down. Up is positive.
		float verticalInputDir = Input.GetAxisRaw ("Vertical");

	}
}
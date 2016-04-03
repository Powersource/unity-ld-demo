using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		// Searches through the scene for a GameObject called "player"
		// and stores it for later use. It is slow and if you find
		// yourself using it outside of initialization you're
		// probably doing something wrong.
		player = GameObject.Find ("player");
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
		Debug.Log("Player position: " + player.transform.position.ToString());
		// There are several ways to read input in unity but the GetAxis methods
		// are absolutely the simplest and most effective. This reads from both
		// a/d/left/right as well as the left stick on a controller and when
		// people launch your game they get a little pre-built options menu
		// where they can set up their controls.
		// You can change the defaults in the editor through
		// Edit->Project Settings->Input
		// There are also many other interesting things in the project settings.
		float horizontalInputDir = Input.GetAxisRaw ("Horizontal");
		// Create a new Vector2 object (2-dimensional vector)
		// with our horizontal input on the x-axis
		Vector2 direction = new Vector2 (horizontalInputDir, 0);
		// Translate (move) the player GameObject in the direction
		// of travel times the time since the last time we moved it.
		// Here you could also multiply by e.g. a speed variable.
		// And yes java people, we are multiplying an object.
		player.transform.Translate (Time.deltaTime * direction);
	}
}
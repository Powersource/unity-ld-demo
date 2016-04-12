using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player;
	Rigidbody2D playerRigidbody;
	// Declaring this public will let us change the value in the editor
	// Warning! Don't set the value in here if you do that.
	// If you do that and change it in the editor (outside of play mode) you have to right click
	// the script component and click reset to get back to the value you set in the script.
	// Set it in the Start method instead.
	// The range tag will give us a slider to more easily change it.
	[Range(0f, 25f)]
	public float speedConstant;

	// Use this for initialization
	void Start () {
		// Searches through the scene for a GameObject called "player"
		// and stores it for later use. It is slow and if you find
		// yourself using it outside of initialization you're
		// probably doing something wrong.
		player = GameObject.Find ("player");
		// Getting and storing the player's Rigidbody2D component
		playerRigidbody = player.GetComponent<Rigidbody2D> ();
		// Assign the constant a value
		speedConstant = 5f;
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
		// Multiply the input direction by a constant to get a more useable speed.
		float horizontalSpeed = horizontalInputDir * speedConstant;
		// Set the player rigidbody's x velocity to the one determined by the input
		// and keep the y velocity. (we can't change the x velocity directly)
		playerRigidbody.velocity = new Vector2 (horizontalSpeed, playerRigidbody.velocity.y);

		// Then we make the player able to jump.
		// Saves the vertical input i.e. up/down. Up is positive.
		float verticalInputDir = Input.GetAxisRaw ("Vertical");
		// When working with layers in unity you have to use bitmasks.
		// NameToLayer returns the position of the mentioned layer and
		// then we shift the 1 that many positions to the left to "select" it.
		// In this instance nothing much happens since Default's position is 0.
		// We could also simply set the mask to int.MaxValue to select every layer.
		int defaultLayer = 1 << LayerMask.NameToLayer ("Default");
		// Check if I'm pressing up AND the player's collider is touching the default layer.
		// Try standing next to a wall and jump. You'll see that this solution isn't perfect.
		// It could be improved by using a raycast under the player for standing-on-ground
		// detection.
		if (verticalInputDir > 0 && playerRigidbody.IsTouchingLayers(defaultLayer)) {
			// Give the player some upward momentum. The speedConstant is
			// arbitrary here but worked out fine.
			playerRigidbody.velocity += Vector2.up * speedConstant;
		}
	}
}
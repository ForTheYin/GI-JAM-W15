using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public Camera mainCam;
	public BoxCollider2D topWall; 
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall; 
	public BoxCollider2D rightWall; 

	public Transform Player01;
	public Transform Player02;

	// Use this for initialization
	// Not using update for performance sake
	void Start () {
	
		float screenLeft = mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x;
		float screenRight = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x;
		float screenWidth = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x;
		float screenHeight = mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y;

		float playerLeft = mainCam.ScreenToWorldPoint (new Vector3 (75f, 0f, 0f)).x;
		float playerRight = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width - 75f, 0f, 0f)).x;


		// Move top walls to the edge
		topWall.size = new Vector2 (screenWidth, 1f);
		topWall.center = new Vector2 (0f, screenHeight + 0.5f);

		// Move bottom walls to the edge
		bottomWall.size = new Vector2 (screenWidth, 1f);
		bottomWall.center = new Vector2 (0f, (screenHeight + 0.5f) * -1);

		// Move left walls to the edge
		leftWall.size = new Vector2 (1f, 2 * screenHeight);
		leftWall.center = new Vector2 (screenLeft - 0.5f, 0f);

		// Move right walls to the edge
		rightWall.size = new Vector2 (1f, 2 * screenHeight);
		rightWall.center = new Vector2 (screenRight + 0.5f, 0f);

		// Reset player positions
		Player01.position = new Vector2 (0f, 0f);
		Player02.position = new Vector2 (0f, 0f);

		Player01.Translate (playerLeft, 0f, 0f);
		Player02.Translate (playerRight, 0f, 0f);

	}
}

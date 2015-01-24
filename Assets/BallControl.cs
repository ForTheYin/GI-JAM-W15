using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	public float ballSpeed = 100;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(2);
		initBall();
	}﻿

	void initBall() {
		int randomInt = Random.Range(0,2);
		if (randomInt <= 0.5f) {
			//Debug.Log ("Shoot right");
			rigidbody2D.AddForce(new Vector2(ballSpeed,10));
		} else {
			//Debug.Log ("Shoot left");
			rigidbody2D.AddForce(new Vector2(-ballSpeed,-10));
		}
	}
	
	IEnumerator resetBall() {
		rigidbody2D.velocity = new Vector2 (0, 0);
		transform.position = new Vector2 (0, 0);
		yield return new WaitForSeconds (1);
		initBall ();
	}
	
	void OnCollisionEnter2D(Collision2D colInfo){
		if(colInfo.collider.tag == "Player") {
			//Debug.Log ("It works.");
			float velY = rigidbody2D.velocity.y/2 + colInfo.collider.rigidbody2D.velocity.y/3;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velY);
		}
	}
}

using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	public float ballSpeed = 100;
	int spinning_speed;
	public GameObject Score_Manager;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(3);
		initBall();
	}﻿

	void initBall() {
		spinning_speed = 0;
		int x_dir = Random.Range (0, 2);
		if (x_dir == 0) {
			x_dir = -1;
		}
		int y_dir = Random.Range (0, 2);
		if (y_dir == 0) {
			y_dir = -1;
		}
		float x_pow = Random.Range (0f, 1f);
		float y_pow = 1f - x_pow;
		                   
		float x_res = x_dir * x_pow * ballSpeed;
		float y_res = y_dir * y_pow * ballSpeed;
		rigidbody2D.AddForce(new Vector2( x_res, y_res));
	}
	
	IEnumerator resetBall() {
		spinning_speed = 0;
		rigidbody2D.velocity = new Vector2 (0, 0);
		transform.position = new Vector2 (0, 0);
		Renderer[] temp = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in temp) {
			r.enabled = false;
		}
		yield return new WaitForSeconds (4);
		foreach (Renderer r in temp) {
			r.enabled = true;
		}
		yield return new WaitForSeconds (3);
		initBall ();
	}

	void FixedUpdate(){
		transform.Rotate (new Vector3 (transform.rotation.x, transform.rotation.y, spinning_speed));
	}

	void OnCollisionEnter2D(Collision2D colInfo){
		float velX = rigidbody2D.velocity.x + colInfo.collider.rigidbody2D.velocity.x/3;
		float velY = rigidbody2D.velocity.y + colInfo.collider.rigidbody2D.velocity.y/3;
		rigidbody2D.velocity = new Vector2(velX, velY);
		spinning_speed = Random.Range(10,50);
		Score_Manager.GetComponent<GameManager> ().scoreUpdate ();
		
	}
}

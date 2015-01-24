using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	
	public float speed = 10.0f;
	public float respawn = 2.0f;

	// 'l' = left
	// 'r' = right
	// 'n' = stationary
	// 'd' = down
	// 'u' = up;

	char currentDirection = 'n';
	char inmoveableDirection = 'n';
	float hitTime = 0.0f;

	void OnTriggerEnter2D(Collider2D triggerInfo) {
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.b, renderer.material.color.g, 0.5f);
			collider2D.enabled = false;
			hitTime = Time.time;
	}
	void OnCollisionEnter2D(Collision2D hitInfo) {
		if (hitInfo.collider.gameObject.name == "Ball"){
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.b, renderer.material.color.g, 0.5f);

			GameObject.Find("Master").GetComponent<GameManager>().scoreUpdate(transform.root.name);

			collider2D.enabled = false;
			hitTime = Time.time;
		}
	}


	// Update is called once per frame
	void Update () {
		if (collider2D.enabled == false && Time.time - hitTime > respawn){
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.b, renderer.material.color.g, 1.0f);
			collider2D.enabled = true;
		}

		if (Input.GetKey(moveUp) && inmoveableDirection != 'u'){
			rigidbody2D.velocity = new Vector2(0, speed);
			currentDirection = 'u';
		} else if (Input.GetKey(moveDown) && inmoveableDirection != 'd'){
			rigidbody2D.velocity = new Vector2(0, -speed);
			currentDirection = 'd';
		} else if (Input.GetKey(moveLeft) && inmoveableDirection != 'l'){
			rigidbody2D.velocity = new Vector2(-speed, 0);
			currentDirection = 'l';
		} else if (Input.GetKey(moveRight) && inmoveableDirection != 'r'){
			rigidbody2D.velocity = new Vector2(speed, 0);
			currentDirection = 'r';
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
			currentDirection = 'n';
		}
	}

}

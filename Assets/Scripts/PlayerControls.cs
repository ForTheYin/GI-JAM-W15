using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public float Xbound;
	public float Ybound;
	public GameObject[] Egg_Arr;

	public float speed = 10.0f;

	public void Fix_Eggs(){
		for(int i =0; i < Egg_Arr.Length; i++){
			Egg_Arr[i].GetComponent<Egg_Script>().FixEgg();
		}

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(moveUp) ){
			if(transform.position.y < Ybound){
				rigidbody2D.velocity = new Vector2(0f, speed);
			}else{
				rigidbody2D.velocity = new Vector2(0f, 0f);
				transform.position = new Vector2(transform.position.x, Ybound);
			}
		} else if (Input.GetKey(moveDown)){
			if(transform.position.y > -Ybound){
				rigidbody2D.velocity = new Vector2(0, -speed);
			}else{
				rigidbody2D.velocity = new Vector2(0f, 0f);
				transform.position = new Vector2(transform.position.x, -Ybound);
			}
		} else if (Input.GetKey(moveLeft)){
			if(transform.position.x > -Xbound){
				rigidbody2D.velocity = new Vector2(-speed, 0);
			}else{
				rigidbody2D.velocity = new Vector2(0f, 0f);
				transform.position = new Vector2(-Xbound, transform.position.y);
			}
		} else if (Input.GetKey(moveRight)){
			if(transform.position.x < Xbound){
				rigidbody2D.velocity = new Vector2(speed, 0);
			}else{
				rigidbody2D.velocity = new Vector2(0f, 0f);
				transform.position = new Vector2(Xbound, transform.position.y);
			}
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}

}

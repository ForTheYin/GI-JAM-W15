using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public string XAxisController;
	public string YAxisController;
	public float threshold = 0.7f;
	
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

		if (XAxisController != ""){
			float augmentedX = speed * Input.GetAxisRaw(XAxisController);
			
			if (Input.GetAxis(XAxisController) < threshold){
				if(transform.position.x > -Xbound){
					rigidbody2D.velocity = new Vector2(augmentedX, 0);
				}else{
					rigidbody2D.velocity = new Vector2(0f, 0f);
					transform.position = new Vector2(-Xbound, transform.position.y);
				}
			} else if (Input.GetAxis(XAxisController) > -threshold){
				if(transform.position.x < Xbound){
					rigidbody2D.velocity = new Vector2(augmentedX, 0);
				}else{
					rigidbody2D.velocity = new Vector2(0f, 0f);
					transform.position = new Vector2(Xbound, transform.position.y);
				}
			}

			if (Mathf.Abs(Input.GetAxis(XAxisController)) < threshold){
				rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
			}
		}

		if (YAxisController != ""){
			float augmentedY = speed * Input.GetAxisRaw(YAxisController);

			if (Input.GetAxis(YAxisController) > threshold){
				if(transform.position.y < Ybound){
					rigidbody2D.velocity = new Vector2(0f, augmentedY);
				}else{
					rigidbody2D.velocity = new Vector2(0f, 0f);
					transform.position = new Vector2(transform.position.x, Ybound);
				}
			} else if (Input.GetAxis(YAxisController) < -threshold){
				if(transform.position.y > -Ybound){
					rigidbody2D.velocity = new Vector2(0, augmentedY);
				}else{
					rigidbody2D.velocity = new Vector2(0f, 0f);
					transform.position = new Vector2(transform.position.x, -Ybound);
				}
			}

			if (Mathf.Abs(Input.GetAxis(YAxisController)) < threshold){
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
			}
		}


	}

}

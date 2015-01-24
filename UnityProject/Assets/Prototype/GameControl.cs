using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	public const int delay = 3;
	public float weight;
	public float tap_weight;

	public TextMesh announce_left;
	public TextMesh announce_right;

	public Rigidbody p1;
	public Rigidbody p2;

	public Camera main_camera;
	public Camera p1_camera;
	public Camera p2_camera;

	bool moved;
	float initalized;

	float p1_power;
	float p2_power;
	float p1_current_power;
	float p2_current_power;

	// Use this for initialization
	void Start () {
		moved = false;
		initalized = 0.0f;

		p1_current_power = 0.0f;
		p2_current_power = 0.0f;

		p1_power = 0.0f;
		p2_power = 0.0f;

		main_camera.enabled = false;
		p1_camera.enabled = true;
		p1_camera.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if ((Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.P)) && !moved && initalized <= 0.0f) {
			initalized = Time.time;
		}

		if (Time.time - initalized < delay && initalized > 0.0f){
			announce_left.text = (delay - (Time.time - initalized)).ToString();
			announce_right.text = (delay - (Time.time - initalized)).ToString();

			if (Input.GetKey(KeyCode.Q)){
				p1_power += weight;
			} 
			if (Input.GetKey(KeyCode.P)){
				p2_power += weight;
			}

		} else if (initalized > 0.0f){
			p1.AddForce(p1_power, 0, 0);
			p2.AddForce(-p2_power, 0, 0);

			p1_current_power = p1_power;
			p2_current_power = p2_power;

			initalized = 0.0f;
			main_camera.enabled = true;
			p1_camera.enabled = false;
			p1_camera.enabled = false;


			moved = true;

		}

		if (moved){
			if (p1_current_power > 0 && Input.GetKey(KeyCode.Q)){
				p1_current_power -= tap_weight;
				p1.AddForce(-tap_weight, 0, 0);
			}

			if (p2_current_power > 0 && Input.GetKey(KeyCode.P)){
				p2_current_power += tap_weight;
				p2.AddForce(tap_weight, 0, 0);
			} 
		}

	}
}

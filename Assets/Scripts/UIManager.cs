using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	AudioSource My_Source;
	public KeyCode Start_Key;
	public string Submit_Key;

	void Start(){
		My_Source = GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		if (Input.GetKey(Start_Key) || Input.GetAxis(Submit_Key) != 0.0f){
			My_Source.enabled = true;
			Invoke ("Game_Start",2.2f);
		}
	}

	public void Game_Start(){
		Application.LoadLevel ("Main");
	}
}

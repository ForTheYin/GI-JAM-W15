using UnityEngine;
using System.Collections;

public class Player_Manager : MonoBehaviour {
	public GameObject[] Pad_Arr;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void Fix_Egg(){
		for (int i=0; i < Pad_Arr.Length; i++) {
			Pad_Arr[i].GetComponent<PlayerControls>().Fix_Eggs();
		}
	}
}

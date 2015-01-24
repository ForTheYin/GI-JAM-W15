using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static int playerScore01 = 0;
	static int playerScore02 = 0;

	public GUISkin layoutSkin;

	public void scoreUpdate(string hitName) {
		if (hitName == "Player02"){
			playerScore01++;
		} else if (hitName == "Player01"){
			playerScore02++;
		}

		Debug.Log("playerScore01: " + playerScore01 + ", playerScore02: "+ playerScore02);
	}

	void OnGUI(){
		GUI.skin = layoutSkin;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 14, 20, 100, 100), "" + playerScore01);
		GUI.Label (new Rect (Screen.width / 2 + 150 - 14, 20, 100, 100), "" + playerScore02);
	}
}

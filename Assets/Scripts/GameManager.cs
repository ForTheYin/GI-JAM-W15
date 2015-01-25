using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	static int GameScore = 0;

	public GUISkin layoutSkin;

	public void scoreUpdate() {
		GameScore++;
	}

	void OnGUI(){
		GUI.skin = layoutSkin;
		GUI.Label (new Rect (Screen.width / 2 - 15, 20, 100, 100), "" + GameScore);
	}
}

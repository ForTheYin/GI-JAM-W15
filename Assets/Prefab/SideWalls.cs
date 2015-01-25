using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.gameObject.tag == "Hen") {
			hitInfo.gameObject.SendMessage("resetBall");
		} 
		transform.parent.GetComponent<GameSetup> ().Reset_Players ();
	}
}

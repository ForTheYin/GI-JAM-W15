using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			hitInfo.gameObject.SendMessage("resetBall");
		}
	}
}

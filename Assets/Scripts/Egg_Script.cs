using UnityEngine;
using System.Collections;

public class Egg_Script : MonoBehaviour {
	public GameObject Egg_Thread;
	Animator my_anim;
	// Use this for initialization
	void Start () {
		my_anim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Hen") {
			BreakEgg();
		}
	}

	public void FixEgg(){
		
		my_anim.SetBool ("Is_Broken", false);
		collider2D.enabled = true;
	}

	void BreakEgg(){
		my_anim.SetBool ("Is_Broken", true);
		GameObject EGG_Explosion;
		EGG_Explosion = Instantiate(Egg_Thread, transform.position, transform.rotation) as GameObject;
		EGG_Explosion.transform.parent = this.transform;
		Destroy (EGG_Explosion, 5f);
		collider2D.enabled = false;
	}
}

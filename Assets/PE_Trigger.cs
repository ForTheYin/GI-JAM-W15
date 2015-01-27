using UnityEngine;
using System.Collections;

public class PE_Trigger : MonoBehaviour {
	public GameObject my_Effect;

	public void Use_Effect(){
		GameObject EF_Instance;
		EF_Instance = Instantiate(my_Effect, transform.position + new Vector3(0f, 0f, -3f), transform.rotation) as GameObject;
		EF_Instance.transform.localScale = this.transform.localScale;
		Destroy (EF_Instance, 5f);
	}
}

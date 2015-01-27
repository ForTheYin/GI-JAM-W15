using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] Chicken;
	public GameObject[] Bgm_Arr;
	public AudioClip[] ChickenSound;

	int Life_Left = 2;
	static int GameScore = 0;
	static int MAXScore = 0;
	static AudioSource MySource;
	public GUISkin layoutSkin;

	void Start(){
		MySource = GetComponent<AudioSource> ();
		init_stage ();
	}

	void init_stage(){
		GameScore = 0;
		Bgm_Arr [0].GetComponent<AudioSource> ().volume = 1f;
		Bgm_Arr [1].GetComponent<AudioSource> ().volume = 0f;
		Bgm_Arr [2].GetComponent<AudioSource> ().volume = 0f;
	}

	public void Reduce_Life(){
		Bgm_Arr [0].GetComponent<AudioSource> ().volume = 0f;
		Bgm_Arr [1].GetComponent<AudioSource> ().volume = 0f;
		Bgm_Arr [2].GetComponent<AudioSource> ().volume = 0f;
		MySource.PlayOneShot (ChickenSound[5]);
		Invoke ("Check_Condition", 4f);
	}
	void Check_Condition(){
		if (Life_Left < 0) {
			Application.LoadLevel ("TitleScreen");
		} else {
			Chicken [Life_Left].GetComponent<PE_Trigger> ().Use_Effect (); 
			Destroy (Chicken [Life_Left], 0.5f);
			Life_Left--;
			Bgm_Arr [0].GetComponent<AudioSource> ().volume = 1f;
			Bgm_Arr [1].GetComponent<AudioSource> ().volume = 0f;
			Bgm_Arr [2].GetComponent<AudioSource> ().volume = 0f;
		}
	}

	public void scoreUpdate() {
		int rand_int = Random.Range (0, 5);
		MySource.PlayOneShot (ChickenSound[rand_int]);
		GameScore++;
		if(MAXScore < GameScore){
			MAXScore = GameScore;
		}
		if (GameScore >= 30) {
			Bgm_Arr [1].GetComponent<AudioSource> ().volume = 1f;
		}else if(GameScore >= 50){
			Bgm_Arr [2].GetComponent<AudioSource> ().volume = 1f;
		}
	}

	void OnGUI(){
		GUI.skin = layoutSkin;
		GUI.Label (new Rect (Screen.width / 10 , 10, 300, 100), "MAX:" + MAXScore);
		GUI.Label (new Rect (Screen.width - 200, 10, 300, 100), "Player:" + GameScore);
	}
}

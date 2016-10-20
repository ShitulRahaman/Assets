using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectTimeDamge : MonoBehaviour {

	public string Name="ballon";
	public int ObastracleWait = 1;
	public int DamegeTime;
	public float NextHitDelay;
	public int ObstraclePoint=0;

	private bool HeroTakeAction = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if ((coll.gameObject.tag == "Player") && !(Name == "ballon")) {
			if (HeroTakeAction) {
				GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().DamgeSoundPlay();
				StartCoroutine (GameDamge ());	
			}
		} else if((Name == "ballon")&&(coll.gameObject.tag == "Player")) {
			
				GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().BalloonSoundPlay();
		
		
		}
	}


	IEnumerator GameDamge(){
		GameUtility.GAME_TIME=GameUtility.GAME_TIME - DamegeTime;
		HeroTakeAction = false;
		GameObject TextEffectorObject = GameObject.FindGameObjectWithTag ("TextEffect");
		if (TextEffectorObject != null) {
			TextEffectorObject = TextEffectorObject.GetComponent<Obstracle> ().ObstracleEffector;
			TextEffectorObject.SetActive (true);
			TextEffectorObject.GetComponent<Text> ().text = "- " + DamegeTime+" s";

			yield return new WaitForSeconds (NextHitDelay);
			TextEffectorObject.SetActive (false);
		//	HeroTakeAction = true;
		}
		HeroTakeAction = true;

	}

}

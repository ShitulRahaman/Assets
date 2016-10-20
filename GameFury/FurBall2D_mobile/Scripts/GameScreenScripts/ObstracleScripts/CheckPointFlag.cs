using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPointFlag : MonoBehaviour {

	public int AddTime = 60;
	public float TextEffectShowTime=1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag=="Player"){
			GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().CheckPontFlagSoundPlay();
			StartCoroutine (GameDamge());
		}

	}


	IEnumerator GameDamge(){
		GameUtility.GAME_TIME=GameUtility.GAME_TIME + AddTime;

		GameObject TextEffectorObject = GameObject.FindGameObjectWithTag ("TextEffect");
		if (TextEffectorObject != null) {
			TextEffectorObject = TextEffectorObject.GetComponent<Obstracle> ().ObstracleEffector;
			gameObject.GetComponent<Animator> ().SetBool("ScaleDown",true);
			TextEffectorObject.SetActive (true);
			TextEffectorObject.GetComponent<Text> ().text = "+ " + AddTime+" s";
			GameUtility.CurrentObstarclePoint = 0;
			yield return new WaitForSeconds (TextEffectShowTime);
			TextEffectorObject.SetActive (false);
			Destroy (gameObject);
			//	HeroTakeAction = true;
		}


	}
}

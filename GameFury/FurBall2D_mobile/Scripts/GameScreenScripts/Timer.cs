using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	public int TimeCount;
	public GameObject hero;
	private Text TimerObject;

	// Use this for initialization
	void Start () {
		GameUtility.GAME_TIME=TimeCount;
		TimerObject = GetComponent<Text> ();
		TimerObject.text=""+GameUtility.GAME_TIME+" s";
		StartCoroutine (DelayForOneSecond());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GameUtility.GAME_TIME>TimeCount){
			GameUtility.GAME_TIME = TimeCount;
		}
	
	}


	IEnumerator DelayForOneSecond(){
		while(GameUtility.GAME_TIME>0){
		yield return new WaitForSeconds (1f);
			GameUtility.GAME_TIME--;
			TimerObject.text=""+GameUtility.GAME_TIME+" s";

		}

		StartCoroutine (hero.GetComponent<PlayerController_m> ().HeroDead ());
	}
}

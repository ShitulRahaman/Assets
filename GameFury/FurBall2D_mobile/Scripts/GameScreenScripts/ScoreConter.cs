using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreConter : MonoBehaviour {


	public Transform Player;
	public Transform CheckpointFlag;
	private Text ScoreObject;
	private float  StartPosition;
	// Use this for initialization
	void Start () {
		ScoreObject = GetComponent<Text> ();
		StartPosition = Player.position.x;
		GameObject flagObject=Instantiate (CheckpointFlag).gameObject;
		flagObject.transform.position = new Vector3 (GameUtility.PreviousTargetPoint+GameUtility.NextTargetPoint,flagObject.transform.position.y,flagObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		GameUtility.GAME_SCORE = (int)(Player.position.x - StartPosition);

		FlagCalCulation ();
	
		ScoreObject.text=""+GameUtility.GAME_SCORE+" m";
	}


	void FlagCalCulation(){
	
		if ((GameUtility.GAME_SCORE - GameUtility.PreviousTargetPoint) >=GameUtility.NextTargetPoint) {
			GameUtility.PreviousTargetPoint = GameUtility.GAME_SCORE;
			GameObject flagObject=Instantiate (CheckpointFlag).gameObject;
			flagObject.transform.position = new Vector3 (GameUtility.PreviousTargetPoint+GameUtility.NextTargetPoint,flagObject.transform.position.y,flagObject.transform.position.z);

			//Debug.Log (GameUtility.GAME_SCORE_BAR_VALUE);
		} else {
		
			GameUtility.GAME_SCORE_BAR_VALUE=GameUtility.GAME_SCORE - GameUtility.PreviousTargetPoint;
		}
	
	
	
	}


}

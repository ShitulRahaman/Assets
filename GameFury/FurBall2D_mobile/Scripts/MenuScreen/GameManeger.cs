using UnityEngine;
using System.Collections;

public class GameManeger : MonoBehaviour {

	public int GameLevel;
	public bool IsAndroid;
	public bool SoundOn;

	public float DefecultTolaranceThresold;
	public float NextTargetPoint;
	void Awake(){
		GameUtility.Game_Level= GameLevel;
		GameUtility.IsAndroid = IsAndroid;

		GameUtility.Game_Deficulty_ThreSold = DefecultTolaranceThresold;
		GameUtility.NextTargetPoint = NextTargetPoint;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EasySelectChange(){
	
	}


}

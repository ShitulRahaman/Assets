using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public GameObject PauseButton;
	public GameObject PausePopUp;
	public Slider TimeScroll;
	public Slider DistanceScroll;

	void OnEnable(){

		Time.timeScale = 1f;

	}
	// Use this for initialization
	void Start () {
		//Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TimeSecondScrollBar ();
		DitanceScrollBar ();
	}

	public void TimeSecondScrollBar(){
		TimeScroll.value = GameUtility.GAME_TIME;
	}
	public void DitanceScrollBar(){
		//Debug.Log (GameUtility.GAME_SCORE_BAR_VALUE);
		DistanceScroll.value = GameUtility.GAME_SCORE_BAR_VALUE;

	}

	public void PauseButtonResponse(){
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().PopUpSoundPlay();
		PausePopUp.SetActive (true);
	
	}



}

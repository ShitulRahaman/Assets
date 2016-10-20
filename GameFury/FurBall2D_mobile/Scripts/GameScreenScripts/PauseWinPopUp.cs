using UnityEngine;
using System.Collections;

public class PauseWinPopUp : MonoBehaviour {


	public GameObject BlureScreen;
	public GameObject PauseButton;
	public GameObject UIPanel;
	public GameObject FadeIn;
	void OnEnable(){
		
		BlureScreen.SetActive (true);
		UIPanel.SetActive (false);
		StartCoroutine (PausePopUpOPen());


	}


	// Use this for initialization
	void Start () {
		//Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void PlayButtonResponse(){
		Time.timeScale = 1f;
		PauseButton.SetActive (true);
		UIPanel.SetActive (true);
		BlureScreen.SetActive (false);
		gameObject.SetActive (false);
	
	
	}

	public void ReloadButtonResponse(){
		Time.timeScale = 1f;
		UIPanel.SetActive (true);
		PauseButton.SetActive (true);
		BlureScreen.SetActive (false);
		gameObject.SetActive (false);
		Application.LoadLevel (GameUtility.GAME_SCREEN);

	}
	public void MenuButtonResponse(){
		Time.timeScale = 1f;

		FadeIn.SetActive (true);
		StartCoroutine (GameScreenChage());

	}

	IEnumerator GameScreenChage(){
		yield return new WaitForSeconds (.5f);
		UIPanel.SetActive (true);
		PauseButton.SetActive (true);
		BlureScreen.SetActive (false);
		gameObject.SetActive (false);
		Application.LoadLevel (GameUtility.MENU_SCREEN);
	}

	IEnumerator  PausePopUpOPen(){


		PauseButton.SetActive (false);

		yield return new WaitForSeconds (gameObject.GetComponent<Animator> ().runtimeAnimatorController.animationClips.LongLength+.5f);

		Time.timeScale=0;

	}

}

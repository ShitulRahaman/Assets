using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameWinePanel : MonoBehaviour {


	public Text Distance ;
	public Text Record;
	public GameObject BlurPanel;
	public GameObject UIControllPanel;
	public GameObject FadeIn;

	void OnEnable(){
		if (!PlayerPrefs.HasKey ("record")) {
			PlayerPrefs.SetInt ("record",0);		
		
		}
		HighScoreCount ();

		BlurPanel.SetActive (true);
		UIControllPanel.SetActive (false);
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		Distance.text = "" + GameUtility.GAME_SCORE+" m";

	}

	public void CloseButtonResponse(){
	
	}

	public void RetryButtonResponse(){
		Time.timeScale = 1;
		Application.LoadLevel (GameUtility.GAME_SCREEN);
	}

	public void BackButtonResponse(){
		Time.timeScale = 1;
		FadeIn.SetActive (true);
		StartCoroutine (GameScreenChage());
	
	}
	IEnumerator GameScreenChage(){
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (GameUtility.MENU_SCREEN);
	}

	void HighScoreCount(){
		for(int i=0;i<5;i++){
			if(PlayerPrefs.GetInt ("record" + i)<GameUtility.GAME_SCORE){
				PlayerPrefs.SetInt ("record" + i,GameUtility.GAME_SCORE);
				 break;
			}
		}

		Record.text = "" + PlayerPrefs.GetInt ("record"+0)+" m";
		
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

	public Sprite[] SoundImage;
	public Image SoundButton;
	public Color[] SelectColor;
	public Text[] DifficultyOption;
	public GameObject PopUpPanel;
	public GameObject InfoPanel;
	public GameObject Tutorial;
	public Slider PingoMovmentSpeed;
	public GameObject FadeIn;


	//Tutorial Image
	public Image TutorialView;
	public Sprite [] TutorialImage;
	public GameObject[] TuroialButton;

	private bool HardClickFlag=false;
	private bool MediumClickFlag=true;
	private bool EasyClickFlag=false;


	private int ImageIndex=0;
	// Use this for initialization


	void Start () {

	
		
		if (!PlayerPrefs.HasKey ("PingoSound")) {
			PlayerPrefs.SetFloat ("PingoSound", GameUtility.GameSoundVolume );
			PingoMovmentSpeed.value = GameUtility.GameSoundVolume;
		
		
		} else {
			GameUtility.pingoMovmentSpeed = PlayerPrefs.GetFloat ("PingoSound");
			PingoMovmentSpeed.value = GameUtility.GameSoundVolume;
		}



		//EasyButtonResponse ();
		addRecord ();
		PopUpPanel.SetActive (false);
		InfoPanel.SetActive (false);
		Tutorial.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void PlayButtonResponce(){
		FadeIn.SetActive (true);
		StartCoroutine (ButtonSoundPlay());
	}
		
	public void SettingButtonResponce(){
		//GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().PopUpSoundPlay();
		PopUpPanel.SetActive (true);
		//PingoMovmentSpeed.value = GameUtility.pingoMovmentSpeed;
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().PopUpSoundPlay();
	


		if (!PlayerPrefs.HasKey ("Defficulty")) {
			PlayerPrefs.SetInt ("Defficulty", 0);
			EasyButtonResponse ();



		} else {
			switch (PlayerPrefs.GetInt ("Defficulty")) {
			case 0:
				DifficultyOption [0].color = SelectColor [1];
				EasyClickFlag = true;
				DifficultyOption [1].color = SelectColor [0];
				MediumClickFlag = false;
				DifficultyOption [2].color = SelectColor [0];
				HardClickFlag = false;
				GameUtility.Level_ObastraclePoint = 10;
				GameUtility.Deficulty_Level = 0;

				break;
			case 1:
				DifficultyOption [1].color = SelectColor [1];
				MediumClickFlag = true;
				DifficultyOption [0].color = SelectColor [0];
				EasyClickFlag = false;
				DifficultyOption [2].color = SelectColor [0];
				HardClickFlag = false;
				GameUtility.Level_ObastraclePoint = 20;
				GameUtility.Deficulty_Level = 0;

				break;
			case 2:
				DifficultyOption [2].color = SelectColor [1];
				HardClickFlag = true;
				DifficultyOption [0].color = SelectColor [0];
				EasyClickFlag = false;
				DifficultyOption [1].color = SelectColor [0];
				MediumClickFlag = false;
				GameUtility.Level_ObastraclePoint = 30;
				GameUtility.Deficulty_Level = 1;
				//PlayerPrefs.SetInt ("Defficulty", 2 );
				break;
			}
		}
		//Debug.Log (GameUtility.pingoMovmentSpeed);
	}
	public void TutorialButtonResponce(){

		Tutorial.SetActive (true);
		ImageIndex = 0;
		TutorialView.sprite = TutorialImage [0];
		TuroialButton [0].SetActive (false);
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().PopUpSoundPlay ();
	}
	public void InfoButtonResponce(){
		
		InfoPanel.SetActive (true);
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().PopUpSoundPlay ();
	}

	public void ExitButtonResponce(){
		//GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().ButtonSoundPlay ();
		Application.Quit ();
	}

	public void SoundButtonResponce(){
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().ButtonSoundPlay ();
		if (GameUtility.GameSoundOn) {
			SoundButton.sprite = SoundImage [0];
			GameUtility.GameSoundOn = false;
		} else {
		
			SoundButton.sprite = SoundImage [1];
			GameUtility.GameSoundOn = true;
		}
	}

	public void ShareButtonResponce(){
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().ButtonSoundPlay ();
	}
	public void ClosePopUpButtonResponce(){
	
		PopUpPanel.SetActive (false);
		Tutorial.SetActive (false);
	}
	public void CloseInfoButtonResponce(){

		InfoPanel.SetActive (false);
		Tutorial.SetActive (false);
	}

	public void TutorialNextButtonResponce(){
		ImageIndex++;


		TuroialButton [0].SetActive (true);
		TutorialView.sprite = TutorialImage [ImageIndex];
		if ((TutorialImage.Length-1) == ImageIndex) {
			
			TuroialButton [1].SetActive (false);
		}
			
	}
	public void TutorialBackButtonResponce(){
		ImageIndex--;


		TuroialButton [1].SetActive (true);
		TutorialView.sprite = TutorialImage [ImageIndex];
		if (ImageIndex ==0) {

			TuroialButton [0].SetActive (false);
		}
	}

	public void TutorialVedioButtonResponce(){

		Application.OpenURL("https://www.youtube.com/watch?v=OnbDCYYSS2k&feature=share");
	}

	public void HardButtonResponse (){
		if (!HardClickFlag) {
			
			DifficultyOption [2].color = SelectColor [1];
			HardClickFlag = true;
			DifficultyOption [0].color = SelectColor [0];
			EasyClickFlag = false;
			DifficultyOption [1].color = SelectColor [0];
			MediumClickFlag = false;
			GameUtility.Level_ObastraclePoint = 30;
			GameUtility.Deficulty_Level = 1;
			PlayerPrefs.SetInt ("Defficulty", 2 );
		} else {
			DifficultyOption [2].color = SelectColor [0];
			HardClickFlag = false;
		}
	}

	public void MeduimButtonResponse (){
		if (!MediumClickFlag) {

			DifficultyOption [1].color = SelectColor [1];
			MediumClickFlag = true;
			DifficultyOption [0].color = SelectColor [0];
			EasyClickFlag = false;
			DifficultyOption [2].color = SelectColor [0];
			HardClickFlag = false;
			GameUtility.Level_ObastraclePoint = 20;
			GameUtility.Deficulty_Level = 0;
			PlayerPrefs.SetInt ("Defficulty", 1);
		} else {
			DifficultyOption [1].color = SelectColor [0];
			MediumClickFlag = false;
		}
	}
	public void EasyButtonResponse (){
		if (!EasyClickFlag) {

			DifficultyOption [0].color = SelectColor [1];
			EasyClickFlag = true;
			DifficultyOption [1].color = SelectColor [0];
			MediumClickFlag = false;
			DifficultyOption [2].color = SelectColor [0];
			HardClickFlag = false;
			GameUtility.Level_ObastraclePoint = 10;
			GameUtility.Deficulty_Level = 0;
			PlayerPrefs.SetInt ("Defficulty", 0 );
		} else {
			DifficultyOption [0].color = SelectColor [0];
			EasyClickFlag = false;
		}
	}

	public void PingoSpeedChangeResponse(){
	
		GameUtility.GameSoundVolume = PingoMovmentSpeed.value;
		PlayerPrefs.SetFloat ("PingoSound", GameUtility.GameSoundVolume );
	}




	IEnumerator SoundButtonSoundPlay(){
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().ButtonSoundPlay ();
		yield return new WaitForSeconds (0.4f);
		Application.LoadLevel (GameUtility.GAME_SCREEN);
	}
	IEnumerator ButtonSoundPlay(){
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().ButtonSoundPlay ();
		yield return new WaitForSeconds (0.4f);
		Application.LoadLevel (GameUtility.GAME_SCREEN);
	}

	public void addRecord(){
		for(int i=0;i<5;i++){

			if (!PlayerPrefs.HasKey ("record" + i)) {

				PlayerPrefs.SetInt ("record" + i, 0);
				GameUtility.GameRecord [i] = 0;

			} else {

				GameUtility.GameRecord [i] =PlayerPrefs.GetInt ("record" + i);
			}
		}
	
	
	}

}

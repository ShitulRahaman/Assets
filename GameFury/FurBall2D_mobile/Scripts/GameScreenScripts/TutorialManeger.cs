using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManeger : MonoBehaviour {

	public  GameObject tutorialPanel;

	public Image TutorialImageView;
	public Sprite[] TutorialImagePack;
	private int ImageIndex = 0;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("TUTORIAL")) {
			PlayerPrefs.SetInt("TUTORIAL",0);
			tutorialPanel.SetActive (true);


		} else {
			
		tutorialPanel.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void NextButtonResponse(){
		if ((TutorialImagePack.Length-1) == ImageIndex) {
			tutorialPanel.SetActive (false);
		} else {
			ImageIndex++;
			TutorialImageView.sprite = TutorialImagePack [ImageIndex];
		}

	}
	public void SkipButtonResponse(){
		tutorialPanel.SetActive (false);
	}
}

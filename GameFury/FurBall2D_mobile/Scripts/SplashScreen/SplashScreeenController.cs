using UnityEngine;
using System.Collections;

public class SplashScreeenController : MonoBehaviour {

	public GameObject FadeInAnimation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MouseInput ();
		//TouchInput ();
	}


	void MouseInput(){
		if(Input.GetMouseButtonDown(0)){
			FadeInAnimation.SetActive (true);
			StartCoroutine (GameScreenChage());
		}
	}

	void TouchInput(){
		if(Input.touchCount>0){
			if(Input.GetTouch(0).phase==TouchPhase.Began){
				FadeInAnimation.SetActive (true);
				StartCoroutine (GameScreenChage());
			}
		}
	
	
	}


	IEnumerator GameScreenChage(){
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel (GameUtility.MENU_SCREEN);
	}
}

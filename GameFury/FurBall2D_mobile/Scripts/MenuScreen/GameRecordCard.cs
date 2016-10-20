using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameRecordCard : MonoBehaviour {

	public Text [] Recordes;

	void OnEnable(){
		
	}
	// Use this for initialization
	void Start () {
	
		for(int i=0;i<Recordes.Length;i++){
			Recordes[i].text=PlayerPrefs.GetInt ("record" + i)+" m";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Record1ShareButton(){

	}
	public void Record2ShareButton(){

	}
	public void Record3ShareButton(){

	}
	public void Record4ShareButton(){

	}
	public void Record5ShareButton(){

	}

}

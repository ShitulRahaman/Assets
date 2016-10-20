using UnityEngine;
using System.Collections;

public class MidScrollBg : MonoBehaviour {

	public float scrollSpeed;
	public float scrollFreezePoint=0.1f;
	public float MovingSpeed;
	public bool AutoScroll=false;

	private float Pos=0;
	private float HeroLastPositionX;

	void Start ()
	{
		HeroLastPositionX = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
	}

	void Update ()
	{

		if (!AutoScroll) {
			//Debug.Log(Mathf.Abs (GameObject.FindGameObjectWithTag ("Player").transform.position.x - HeroLastPositionX));
			if(GameObject.FindGameObjectWithTag("Player")!=null && Mathf.Abs(GameObject.FindGameObjectWithTag ("Player").transform.position.x-HeroLastPositionX)>=scrollFreezePoint){
				
			Pos = Pos + GameUtility.accelarometerSpped / MovingSpeed;
			HeroLastPositionX=GameObject.FindGameObjectWithTag ("Player").transform.position.x;
			
		}
		
		} else {
			//if(GameObject.FindGameObjectWithTag("Player")!=null && (GameObject.FindGameObjectWithTag ("Player").transform.position.x-HeroLastPositionX)>=1.1f){
				
				Pos = Pos + scrollSpeed;
			
		}

		if(Pos>1f){
			Pos -= 1f;
		}
		Vector2 offset = new Vector2 (Pos,0f);
		
		GetComponent<Renderer> ().material.mainTextureOffset = offset;

	}


}

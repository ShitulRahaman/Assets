using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	public float CloudKillTime;
	public float Speed;
	public float Range;

	private bool Showed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Render.InsideCamera (Camera.main, this.gameObject)) {
			Showed = true;
		} else {
			if(Showed){
				Destroy (gameObject);
			}
		
		}
	}

	void FixedUpdate(){
		
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x+(Speed*Time.deltaTime),gameObject.transform.position.y,gameObject.transform.position.z);

	
		
	}
}

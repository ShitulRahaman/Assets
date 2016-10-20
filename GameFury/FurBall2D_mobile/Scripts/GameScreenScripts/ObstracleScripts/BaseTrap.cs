using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BaseTrap : MonoBehaviour
{


	public float DoorCloseTime;
	public float HeroMovingTime;


	private bool HeroMoving = true;
 

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("ads");
	}


	void OnTriggerEnter2D (Collider2D Ob)
	{
		if (HeroMoving) {
			StartCoroutine (DoorEffect ());
		}
	}


	IEnumerator DoorEffect ()
	{

		GetComponentInParent<Animator> ().SetBool ("DoorClose", true);
		DamageShowedTimer ();
		yield return new WaitForSeconds (DoorCloseTime);

		GetComponentInParent<Animator> ().SetBool ("DoorClose", false);
		HeroMoving = false;

		yield return new WaitForSeconds (HeroMovingTime);

		HeroMoving = true;
	}

	void DamageShowedTimer(){

		StartCoroutine (TextEffector());
	}

	IEnumerator TextEffector(){
		int time = Mathf.FloorToInt(DoorCloseTime);

		//GameObject newCanvas = Instantiate(canvas) as GameObject;
		GameObject TextEffectorObject = GameObject.FindWithTag ("TextEffect");
	

		if (TextEffectorObject != null) {
			TextEffectorObject = TextEffectorObject.GetComponent<Obstracle> ().ObstracleEffector;
			TextEffectorObject.SetActive (true);

			Debug.Log ("some thisfg");
			//TextEffect.SetActive (true);
			while (time > 0) {

				TextEffectorObject.GetComponent<Text> ().text = "+ " + time + " s";
				yield return new WaitForSeconds (1f);

				time--;
			}
			TextEffectorObject.SetActive (false);
		}

	}

}

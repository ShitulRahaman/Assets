using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreeTrap : MonoBehaviour
{


	public float LeafCloseTime;
	public float AnimationCompleteTime;
	public float HeroMovingTime;
	public float SpeedMove;


	private GameObject hero;
	private bool HeroMoving = true;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if(HeroMoving){
		///hero.transform.position = new Vector3 (hero.transform.position.x+SpeedMove*Time.deltaTime,hero.transform.position.y+SpeedMove*Time.deltaTime,0f);
		
	}

	void OnTriggerEnter2D (Collider2D Ob)
	{
		if (HeroMoving) {
			hero = Ob.gameObject;
			StartCoroutine (LeafEffect ());
		}
		//StartCoroutine (LeafEffect());
	}

	IEnumerator LeafEffect ()
	{
		//hero.SetActive (false);

		DamageShowedTimer ();
		gameObject.GetComponentInParent<Animator> ().SetBool ("LeafClose", true);
		hero.GetComponent<Animator> ().SetBool("Hide",true);
		yield return new WaitForSeconds (AnimationCompleteTime);
		hero.GetComponent<Animator> ().SetBool("Hide",false);
		hero.SetActive (false);
	
		yield return new WaitForSeconds (LeafCloseTime);

		gameObject.GetComponentInParent<Animator> ().SetBool ("LeafClose", false);

		yield return new WaitForSeconds (AnimationCompleteTime);

		hero.SetActive (true);

		hero.GetComponent<PlayerController_m> ().isGrounded = true;
		HeroMoving = false;

		yield return new WaitForSeconds (HeroMovingTime);

		HeroMoving = true;
		hero.GetComponent<CircleCollider2D> ().isTrigger = false;
	
	}

	void DamageShowedTimer ()
	{

		StartCoroutine (TextEffector ());
	}

	IEnumerator TextEffector ()
	{
		int time = Mathf.FloorToInt (LeafCloseTime);
		GameObject TextEffectorObject = GameObject.FindGameObjectWithTag ("TextEffect");
		if (TextEffectorObject != null) {
			TextEffectorObject = TextEffectorObject.GetComponent<Obstracle> ().ObstracleEffector;
			TextEffectorObject.SetActive (true);
	

			while (time > 0) {
				
				TextEffectorObject.GetComponent<Text> ().text = "- " + time + " s";
				yield return new WaitForSeconds (1f);

				time--;
			}
			TextEffectorObject.SetActive (false);

		}
	}
}

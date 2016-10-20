using UnityEngine;
using System.Collections;

public class PlayerController_m : MonoBehaviour {
	
	public float maxSpeed = 6f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float verticalSpeed = 20;
	public GameObject WinigPanel;
	public GameObject SoundMeneger;
	[HideInInspector]
	public bool lookingRight = true;
	bool doubleJump = false;
	public GameObject Boost;
//	private Animator cloudanim;
	public GameObject Cloud;
	private Rigidbody2D rb2d;
	private Animator anim;
	public bool isGrounded = false;


	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		Cloud = GameObject.Find("Cloud");
	}
	

	void OnCollisionEnter2D(Collision2D collision2D) {


		if (collision2D.relativeVelocity.magnitude > 20){
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){

		if(collider.gameObject.tag=="dead"){
			//Debug.Log ("ass");
			StartCoroutine (HeroDead());

		}

	}

	void Update () {

		if (Input.GetMouseButtonDown (0) && (isGrounded || !doubleJump) && !GameUtility.IsAndroid)
		{
			rb2d.AddForce(new Vector2(0,jumpForce));

			if (!doubleJump && !isGrounded)
			{
				doubleJump = true;
				Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			//	cloudanim.Play("cloud");		
			}
		}



		if (Input.GetMouseButtonDown(1) && !isGrounded && !GameUtility.IsAndroid)
		{
			rb2d.AddForce(new Vector2(0,-jumpForce));
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}

	}


	void FixedUpdate()
	{ 
		if (!GameUtility.IsAndroid) {
			KeybordInput ();
		} else {
			MobileInpput ();
		}
	}



	void MobileInpput(){
	
	
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.acceleration.x*GameUtility.pingoMovmentSpeed;
	
		GameUtility.accelarometerSpped=hor;
		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	
	}

	void KeybordInput(){
	
		if (isGrounded) 
			doubleJump = false;


		float hor = Input.GetAxis ("Horizontal");
		GameUtility.accelarometerSpped=hor;
		anim.SetFloat ("Speed", Mathf.Abs (hor));

		rb2d.velocity = new Vector2 (hor * maxSpeed, rb2d.velocity.y);

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, 0.15F, whatIsGround);

		anim.SetBool ("IsGrounded", isGrounded);

		if ((hor > 0 && !lookingRight)||(hor < 0 && lookingRight))
			Flip ();

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	
	}

	public void JumpHeroUp(){
	//	SoundMeneger.GetComponent<GameSoundEffecter> ().JumpSpund ();

		if ((isGrounded || !doubleJump) && GameUtility.IsAndroid)
		{
			rb2d.AddForce(new Vector2(0,jumpForce));
			SoundMeneger.GetComponent<GameSoundEffecter> ().JumpSpund ();
			if (!doubleJump && !isGrounded)
			{
				doubleJump = true;
				Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
					
			}
		}
	}

	public void JumpHeroDown(){
		if (!isGrounded && GameUtility.IsAndroid)
		{
			rb2d.AddForce(new Vector2(0,-jumpForce));
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
		}
	}

	public void Flip()
	{
		lookingRight = !lookingRight;
		Vector3 myScale = transform.localScale;
		myScale.x *= -1;
		transform.localScale = myScale;
	}


	public IEnumerator  HeroDead(){
	
		WinigPanel.SetActive (true);

		gameObject.SetActive (false);
		GameSoundEffecter.GameSoundEffect.GetComponent<GameSoundEffecter> ().GameOverSoundPlay();
		GameUtility.GAME_TIME = -1;
		yield return new WaitForSeconds (WinigPanel.GetComponent<Animator> ().runtimeAnimatorController.animationClips.LongLength+1f);
		//Destroy (gameObject);
		Time.timeScale=0f;
		Destroy (gameObject);
	}

}

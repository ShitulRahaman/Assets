using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlatformController : MonoBehaviour {

	public float BackBeamOffsetX;
	public float BackBeamY;
	public GameObject Player;
	public GameObject obstracleManeger;
	public GameObject BackBeamPrefab;
	public GameObject[] BasePlatForm;


	private List <GameObject> LoadGameObjectChild;
	private float BasePositionOffSet;
	private float platforSize ;
	private	GameObject BackBeam;
	private bool HaveBackBeam = false;
	GameObject SingleBasePlatform ;
	void Awake(){
		LoadGameObjectChild = new List<GameObject> ();
	}

	// Use this for initialization
	void Start () {

		for( int i=0;i<gameObject.transform.childCount;i++){
			Bounds PlatformArea = gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds;
			LoadGameObjectChild.Add (gameObject.transform.GetChild(i).gameObject);
		//	SingleBasePlatform = gameObject.transform.GetChild(i).gameObject;
			platforSize = platforSize + PlatformArea.size.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void FixedUpdate(){
		
		GameObjectChildShorting ();
		//obstracleManeger.GetComponent<Obstracle> ().DownAbstracleSet (SingleBasePlatform.transform);
		if(Player.transform.localScale.x < 0f){
			//obstracleManeger.GetComponent<Obstracle> ().DownAbstracleSet (SingleBasePlatform.transform);
			if(!HaveBackBeam){
				BackBeamGenarator ();
				HaveBackBeam = true;
			}

		} 
	}




	 void PlatformGeneratorSinglePosetive(){
		 SingleBasePlatform = Instantiate (BasePlatForm[PlatformIndexGenaretor()]);
		Bounds PlatformArea = SingleBasePlatform.GetComponent<SpriteRenderer>().bounds;
		SingleBasePlatform.transform.position= new Vector3(BasePositionOffSet+PlatformArea.size.x/2,SingleBasePlatform.transform.position.y,SingleBasePlatform.transform.position.z);
		SingleBasePlatform.transform.parent = gameObject.transform;
		LoadGameObjectChild.Add (SingleBasePlatform);
		LoadGameObjectChild.ToArray().OrderBy(Child => Child.transform.position.x);

		obstracleManeger.GetComponent<Obstracle> ().DownAbstracleSet (SingleBasePlatform.transform);


	}
	void PlatformGeneratorSingleNegative(){

		SingleBasePlatform = Instantiate (BasePlatForm[PlatformIndexGenaretor()]);
		Bounds PlatformArea = SingleBasePlatform.GetComponent<SpriteRenderer>().bounds;
		SingleBasePlatform.transform.position= new Vector3(BasePositionOffSet,SingleBasePlatform.transform.position.y,SingleBasePlatform.transform.position.z);
		SingleBasePlatform.transform.parent = gameObject.transform;
		LoadGameObjectChild.Add (SingleBasePlatform);
		LoadGameObjectChild.ToArray().OrderBy(Child => Child.transform.position.x);

	}
	public void GenarateNextPlatform(){
		

		if (Player.transform.localScale.x > 0f) {

			if(BackBeam!=null){
				Destroy (BackBeam);
				HaveBackBeam = false;
			}
			GameObject lastChild = LoadGameObjectChild.ToArray ().LastOrDefault<GameObject> ();
			BasePositionOffSet = lastChild.transform.position.x + lastChild.GetComponent<SpriteRenderer> ().bounds.size.x/2;
			PlatformGeneratorSinglePosetive ();


		} 
	} 
	void GameObjectChildShorting(){
		foreach(GameObject child in LoadGameObjectChild.ToArray() ){
			if(child!=null){
				if(Render.IsDestroyPlatform(Camera.main,child,platforSize/2)){

					LoadGameObjectChild.Remove (child);
					GenarateNextPlatform ();
					Destroy (child);
					break;
				}
			}
		}
	
		LoadGameObjectChild.ToArray().OrderBy(Child => Child.transform.position.x);
	}

	int PlatformIndexGenaretor(){
		int index=Random.Range(0,BasePlatForm.Length);
		return index;
	}



	void BackBeamGenarator(){
		BackBeam = Instantiate (BackBeamPrefab);
		BackBeam.transform.parent = gameObject.transform;
		BackBeam.transform.position = new Vector3 (LoadGameObjectChild.FirstOrDefault<GameObject>().transform.position.x-LoadGameObjectChild.FirstOrDefault<GameObject>().GetComponent<SpriteRenderer>().bounds.size.x/2,LoadGameObjectChild.FirstOrDefault<GameObject>().transform.position.y,BackBeam.transform.position.z);
	
	}

}

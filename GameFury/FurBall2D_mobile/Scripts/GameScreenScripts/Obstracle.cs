using UnityEngine;
using System.Collections;

public class Obstracle : MonoBehaviour {


	public GameObject [] ObstracleUpObject;
	public GameObject [] ObstracleDownObject;
	public GameObject ObstracleEffector;
	public Transform HeroPostion;
	public Vector2 upOffset ;
	public float ObstracleFractutionX;


	private int Last_ObstraclePosionX=0;
	private int Next_ObstraclePosionX = 10;

	void Awake (){
		
	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void UpAbstracleSet(Transform Anchor){
	
		Bounds PlatformArea = Anchor.GetComponent<SpriteRenderer>().bounds;
			GameObject Object = Instantiate (ObstracleUpObject [0]);
			Object.transform.parent =Anchor ;
		Object.transform.position = new Vector3(Anchor.position.x+upOffset.x+ObstracleSetpostion(),Anchor.position.y-(PlatformArea.size.y+upOffset.y));

	}

	public void DownAbstracleSet(Transform Anchor){

		ObstacleSetPositionCalculation (Anchor);
	}



	int ObstracleObjectIndex(){
		int index = Random.Range (0,ObstracleDownObject.Length);
		Debug.Log (index);
		return index;
	
	}


	public void ObstacleSetPositionCalculation(Transform Anchor){

	
		int Current_obstracle_PosionX=(int)HeroPostion.position.x-Last_ObstraclePosionX;

		if((Next_ObstraclePosionX<=Current_obstracle_PosionX)&&GameUtility.Level_ObastraclePoint>GameUtility.CurrentObstarclePoint){
			Last_ObstraclePosionX = Next_ObstraclePosionX;

			int NextObjectRange =(int)(GameUtility.NextTargetPoint / GameUtility.Level_ObastraclePoint);

			Next_ObstraclePosionX = Random.Range (2,NextObjectRange);
		
			int index = ObstracleObjectIndex ();
			GameObject Object = Instantiate (ObstracleDownObject [index]);
		
			Object.transform.parent = Anchor;
			GameUtility.CurrentObstarclePoint = GameUtility.CurrentObstarclePoint + Object.GetComponent<ObjectTimeDamge> ().ObstraclePoint;

			float postionx = Anchor.position.x + ObstracleSetpostion();

			Object.transform.position = new Vector3 (postionx, Object.transform.position.y, 0f);

			if(GameUtility.Deficulty_Level==1){

			Object = Instantiate (ObstracleDownObject [index]);

			Object.transform.parent = Anchor;
			GameUtility.CurrentObstarclePoint = GameUtility.CurrentObstarclePoint + Object.GetComponent<ObjectTimeDamge> ().ObstraclePoint;

			 postionx = Anchor.position.x - ObstracleSetpostion();

			Object.transform.position = new Vector3 (postionx, Object.transform.position.y, 0f);
			}



		}
		



	}



	float ObstracleSetpostion(){
		float postionx = Random.Range (-ObstracleFractutionX,ObstracleFractutionX);
		return postionx;
	}



}

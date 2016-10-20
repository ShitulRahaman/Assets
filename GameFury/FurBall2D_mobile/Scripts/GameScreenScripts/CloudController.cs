using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	public float CloudGenateTimeMax;
	public float CloudGenateTimeMin;
	public float CloudOffset;
	public float CloudTopRange;
	public float CloudSpeedRange;
	public Vector2 SeizeMax; 
	public Vector2 SeizeMin; 
	public GameObject Cloud;

	// Use this for initialization
	void Start () {
		StartCoroutine (CloudGenarete());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator CloudGenarete(){
		while(true){
				GameObject cloudObject = Instantiate (Cloud);
				cloudObject.transform.position = new Vector3 (Camera.main.transform.position.x-CloudOffset,Camera.main.transform.position.y+CloudPositionY(),cloudObject.transform.position.z);
				cloudObject.GetComponent<Cloud> ().Speed = CloudSpeedGenarator ();
				cloudObject.GetComponent<SpriteRenderer> ().sortingOrder = LayerSortOderGenerator ();
				cloudObject.transform.localScale = CloudSizeGenaretor();
			cloudObject.transform.parent = gameObject.transform;
			yield return new WaitForSeconds (CloudGenarateTime());
		}
	}

	float CloudPositionY(){
		float PositionY = Random.Range (0,CloudTopRange);
		return PositionY;
	}

	float CloudSpeedGenarator(){
		float CloudSpeed = Random.Range (1.5f,CloudSpeedRange);
		return CloudSpeed;
	}

	float CloudGenarateTime(){
		float Time = Random.Range (CloudGenateTimeMin,CloudGenateTimeMax);
		return Time;
	}

	int LayerSortOderGenerator(){

		int SortOrder = Random.Range (0,2);
		return SortOrder;
	}

	Vector3 CloudSizeGenaretor(){
		float CloudeSizeX = Random.Range (SeizeMin.x,SeizeMax.x);
		float CloudeSizeY = Random.Range(SeizeMin.y,SeizeMax.y);

		return new Vector3(CloudeSizeX,CloudeSizeY,1f);
	
	}

}

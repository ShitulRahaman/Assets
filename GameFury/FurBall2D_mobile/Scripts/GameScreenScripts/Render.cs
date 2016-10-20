using UnityEngine;
using System.Collections;

public class Render  {
	public  static bool InsideCamera(Camera cam,GameObject gameObject){
		Rect rect = new Rect (cam.transform.position.x-(cam.rect.width),cam.transform.position.y-(cam.rect.height),cam.rect.width*20,cam.rect.height*20);

		Rect rect1=new  Rect(gameObject.GetComponent<SpriteRenderer>().bounds.center.x+gameObject.GetComponent<SpriteRenderer>().bounds.size.x,gameObject.GetComponent<SpriteRenderer>().bounds.center.y,gameObject.GetComponent<SpriteRenderer>().bounds.size.x*5,gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
		//Debug.Log ("s" +rect.Overlaps(rect1 ));
		//Debug.Log ("s" +rect1+""+rect);
		return rect.Overlaps(rect1 );
	}

	public  static bool IsDestroyPlatform(Camera cam,GameObject gameObject,float destroyRange){
		//Debug.Log ("s" +rect.Overlaps(rect1 ));
		//Debug.Log ("s" +rect1+""+rect);
		float destroyFlag=cam.transform.position.x-gameObject.transform.position.x;
		return (destroyFlag>Mathf.Abs(destroyRange));
	}
}

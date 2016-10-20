using UnityEngine;
using System.Collections;

public class CameraController_m : MonoBehaviour 
{
	public Transform Player;
	public Vector3 CameraOffset;
	public float m_speed = 0.1f;
	Camera mycam;

	public void Start()
	{
		mycam = GetComponent<Camera> ();
		//mycam.orthographicSize = 3.5f;
	}

	public void Update()
	{

		//mycam.orthographicSize = (Screen.height / 100f) / 0.8f;

		if (Player) 
		{
		

			Vector3 cameraNewPos = new Vector3 (Player.position.x+CameraOffset.x,transform.position.y,0f);

			transform.position = Vector3.Lerp(transform.position, cameraNewPos, m_speed) + new Vector3(0, 0, -12);
		}


	}
}

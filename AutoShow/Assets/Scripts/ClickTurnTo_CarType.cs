using UnityEngine;
using System.Collections;

public class ClickTurnTo_CarType : MonoBehaviour {


	public GameObject camera;
	public GameObject carType_center;

		
	void Start()
		{
			camera = GameObject.Find("Main Camera");
			//	returnTo = GameObject.Find("returnTo");
		}
	/*	
	void OnMouseEnter() 
	{

	}
		
	void OnMouseOver() 
	{
		renderer.material.color = Color.blue;
	}
	void OnMouseExit() 
	{
		renderer.material.color = Color.white;
	}
	*/
	void OnClick() 
	{
		RotateCamera();
	}
		
	void RotateCamera()
	{
		camera.GetComponent<SmoothLookAt>().target = carType_center.transform;
	}
	}
using UnityEngine;
using System.Collections;

public class SmoothLookAt : MonoBehaviour 
{
	public Transform target;
	public float damping= 6.0f;
	public bool smooth= true;

	private GameObject manager;

	void  Start ()
	{	
		manager = GameObject.Find("GameManager");
		target = manager.GetComponent<GameManager>().SeletedCarInScene.transform;

   		if (GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
	
	void  LateUpdate ()
	{
		if (target) 
		{
			if (smooth)
			{
				//Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
				//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

				float moveSpeed = 10.0f;
				transform.position =new Vector3(Mathf.Lerp(this.transform.position.x, target.transform.position.x, Time.deltaTime * moveSpeed),3.31f,4.83f);

			}
			else
			{
			    transform.LookAt(target);
			}
		}
	}

	void Update(){

	}
	
	
		void  OnGUI () {
	        if (Time.time % 2 < 1) {
		        if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
		            print ("You clicked me!");
		        }
	        }
	    }
}
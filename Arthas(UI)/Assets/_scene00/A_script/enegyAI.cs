using UnityEngine;
using System.Collections;

public class enegyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public int minDistance;
	
	private Transform myTransform;
	
	void Awake(){
		
		myTransform=transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go=GameObject.FindGameObjectWithTag("Player");
		target=go.transform;
		maxDistance=60;
		minDistance=10;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position,myTransform.position,Color.red);
		//Look at target
		myTransform.rotation=Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position-myTransform.position),rotationSpeed*Time.deltaTime);
		//Move to target
	/*	if(Vector3.Distance(target.position,myTransform.position)>maxDistance)
		{
			transform.animation.Play("Y_idle");
		}*/
		if(Vector3.Distance(target.position,myTransform.position)<maxDistance && Vector3.Distance(target.position,myTransform.position)>minDistance)
		{
			//transform.animation.Play("I_run");
			transform.FindChild("Illidan").GetComponent<Animation>().Play("I_run");
			myTransform.position +=myTransform.forward*moveSpeed*Time.deltaTime;
		}
		/*if(Vector3.Distance(target.position,myTransform.position)<=minDistance)
		{
			transform.animation.CrossFade("Y_attack");
			transform.animation["Y_attack"].wrapMode=WrapMode.Loop;
			transform.animation["Y_attack"].speed=3.0f;
			
		}*/
		}
}

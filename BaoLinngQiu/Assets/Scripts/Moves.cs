using UnityEngine;
using System.Collections;

public class Moves : MonoBehaviour {
	public bool flag;
	private float y = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.y>6.5f)
		{
			flag=true;
		}else if(this.transform.position.y<6)
		{
			flag=false;
		}
		
		if(flag)
		{
			y-=0.12f;
			this.transform.position=
				new Vector3(this.transform.position.x,this.transform.position.y+y,this.transform.position.z);
		}else 
		{
			y+=0.12f;
			this.transform.position=
				new Vector3(this.transform.position.x,this.transform.position.y+y,this.transform.position.z);
		}
	}
}

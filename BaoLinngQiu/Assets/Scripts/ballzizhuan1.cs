using UnityEngine;
using System.Collections;

public class ballzizhuan1 : MonoBehaviour {
	private bool flag1 =false;
	private string wenlilili;
	public GameObject guangyun;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.transform.root.transform==this.transform)	      
				{	
					flag1=true;
					guangyun.transform.position = this.transform.position;

					wenlilili = this.renderer.material.mainTexture.name;
					PlayerPrefs.SetString("wl",wenlilili);		
					Debug.Log(wenlilili);
				}
				else 
					flag1 = false;

			}      	
		}
		if(flag1)
		{
			this.transform.Rotate(-Time.deltaTime * 500,0,0);
		}else{
			this.transform.Rotate(-Time.deltaTime * 50,0,0);
		}
	}
}

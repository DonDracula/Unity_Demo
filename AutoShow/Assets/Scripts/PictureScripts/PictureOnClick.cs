using UnityEngine;
using System.Collections;

public class PictureOnClick : MonoBehaviour {

	public GameObject tex;
	bool changeScale;

	public GameObject center;
	// Use this for initialization
	void Start () {
		changeScale = true;
		//state = new Vector3(-400f,600f,0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		if(changeScale)
		{
			tex.transform.position = center.transform.position;
		}
		else
		{
			this.transform.localScale = new Vector3(1,1,1);
			changeScale = true;
		}
		
		Debug.Log("xxxxx"+ changeScale);
	}
}

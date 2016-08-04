using UnityEngine;
using System.Collections;

public class Picturescale : MonoBehaviour {

	bool changeScale;
	// Use this for initialization
	void Start () {
		changeScale = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick()
	{
		if(changeScale)
		{
			this.transform.localScale=new Vector3(10,10,10);
			changeScale =false;
		}
		else
		{
			this.transform.localScale = new Vector3(1,1,1);
			changeScale = true;
		}

		Debug.Log("xxxxx"+ changeScale);

	}
}

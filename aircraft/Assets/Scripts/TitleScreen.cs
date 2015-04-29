using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		GUI.skin.label.fontSize = 120;

		GUI.skin.label.alignment = TextAnchor.LowerCenter;

		if(GUI.Button(new Rect(Screen.width * 0.5f-100,Screen.height * 0.5f,200,40),"Begin"))
		{
			Application.LoadLevel("Alfa raid");
		}

	}
}

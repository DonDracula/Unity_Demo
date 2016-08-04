using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public GameObject clickBtn;
	public List<GameObject> btnList = new List<GameObject>();
	public float i=0;
	// Use this for initialization
	void Start () {
	
	}
	
	void ChangerDepth(){
//		clickBtn.transform.FindChild("Background").gameObject.GetComponent<UISprite>().depth = 6;
		clickBtn.transform.position = new Vector3(clickBtn.transform.position.x,clickBtn.transform.position.y,-1);
		foreach(GameObject obj in btnList){
			if (obj != clickBtn){
				obj.transform.position = new Vector3(obj.transform.position.x,obj.transform.position.y,-0.5f-i);
				i+=0.025f;
//				obj.transform.FindChild("Background").gameObject.GetComponent<UISprite>().depth = 1;
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	}
}

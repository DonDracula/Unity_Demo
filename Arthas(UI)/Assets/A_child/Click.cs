using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	private GameObject gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		Debug.Log(gameObject.name);
			gameManager.GetComponent<GameManager>().clickBtn = gameObject;
			gameManager.GetComponent<GameManager>().i = 0;
			gameManager.SendMessage("ChangerDepth");
	}
}

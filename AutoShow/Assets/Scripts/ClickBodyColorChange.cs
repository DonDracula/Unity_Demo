using UnityEngine;
using System.Collections;

public class ClickBodyColorChange : MonoBehaviour {
	private Material bodyMaterial;
	public GameObject manager;
	public Color bodyColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bodyMaterial =GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>().SeletedCarInScene_BodyMaterial;
	}

	void OnClick()
	{
		bodyMaterial.SetColor("_Color", bodyColor);
	}
}

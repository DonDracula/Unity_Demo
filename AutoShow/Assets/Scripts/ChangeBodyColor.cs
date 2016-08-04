using UnityEngine;
using System.Collections;

public class ChangeBodyColor : MonoBehaviour {

	public Material bodyMaterial;
	public string colorIcon_name;

	public Color bodyColor_silver;
	public Color bodyColor_blue;
	public Color bodyColor_black;
	public Color bodyColor_red;
	public Color bodyColor_yellow;

	public GameObject Icon_bodyColor_silver;
	public GameObject Icon_bodyColor_blue;
	public GameObject Icon_bodyColor_black;
	public GameObject Icon_bodyColor_red;
	public GameObject Icon_bodyColor_yellow;

	public Texture blue;
	public Texture silver;
	public Texture black;
	public Texture red;
	public Texture yellow;

	void Awake () 
	{    
		//获取需要监听的按钮对象
		//GameObject button = GameObject.Find("UI Root/Camera/Anchor/Panel/Icon_middle");
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
		UIEventListener.Get(Icon_bodyColor_silver).onClick = ButtonClick;
		UIEventListener.Get(Icon_bodyColor_blue).onClick = ButtonClick;
		UIEventListener.Get(Icon_bodyColor_black).onClick = ButtonClick;
		UIEventListener.Get(Icon_bodyColor_red).onClick = ButtonClick;
		UIEventListener.Get(Icon_bodyColor_yellow).onClick = ButtonClick;

	}
	
	//计算按钮的点击事件
	void ButtonClick(GameObject button)
	{
		colorIcon_name = button.name;
		
	}

	// Use this for initialization
	void Start () {

		//bodyMaterial = this.GetComponent<GameManager>().SeletedCarInScene_BodyMaterial;

	}
	
	// Update is called once per frame
	void Update () {
		
		bodyMaterial = this.GetComponent<GameManager>().SeletedCarInScene_BodyMaterial;
		
	/*	switch(colorIcon_name)
		{
			case "ColorCarBody_black":
				bodyMaterial.SetColor("_Color", bodyColor_black);
				break;
			case "ColorCarBody_blue":
				bodyMaterial.SetColor("_Color", bodyColor_blue);
				break;
			case "ColorCarBody_red":
				bodyMaterial.SetColor("_Color", bodyColor_red);
				break;
			case "ColorCarBody_silver":
				bodyMaterial.SetColor("_Color", bodyColor_silver);
				break;
			case "ColorCarBody_yellow":
				bodyMaterial.SetColor("_Color", bodyColor_yellow);
				break;
		}
		*/
	}

	void OnGUI(){
	//	GUI.backgroundColor =Color.green;
		//GUI.DrawTexture(Rect(20,300,40,400), tttt, ScaleMode.ScaleToFit, true, 10.0f);
		if(GUI.Button(new Rect(500,100,40,40),black))
		{
			bodyMaterial.SetColor("_Color", bodyColor_black);
		}
		
//		GUI.backgroundColor =Color.cyan;
		if(GUI.Button(new Rect(500,150,40,40),blue))
		{
			bodyMaterial.SetColor("_Color", bodyColor_blue);
		}
		
	//	GUI.backgroundColor =Color.gray;
		if(GUI.Button(new Rect(500,200,40,40),red))
		{
			bodyMaterial.SetColor("_Color", bodyColor_red);
		}
		
	//	GUI.backgroundColor =Color.red;
		if(GUI.Button(new Rect(500,250,40,40),silver))
		{
			bodyMaterial.SetColor("_Color", bodyColor_silver);
		}
		
	//	GUI.backgroundColor =Color.black;
		if(GUI.Button(new Rect(500,300,40,40),yellow))
		{
			bodyMaterial.SetColor("_Color", bodyColor_yellow);
		}
	}
}

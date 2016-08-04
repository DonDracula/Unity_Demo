using UnityEngine;
using System.Collections;

public class ChangeGlassColor : MonoBehaviour {

	private Material glassMaterial;
	private string colorIcon_name;

	public Texture tttt;

	public Color glassColor_darkgreen;
	public Color glassColor_cyan;
	public Color glassColor_black;
	public Color glassColor_gray;
	public Color glassColor_red;

	public GameObject Icon_glassyColor_darkgreen;
	public GameObject Icon_glassColor_cyan;
	public GameObject Icon_glassColor_black;
	public GameObject Icon_glassColor_gray;
	public GameObject Icon_glassColor_red;

	public Texture darkgreen;
	public Texture cyan;
	public Texture black;
	public Texture red;
	public Texture gray;

	void Awake () 
	{    
		//获取需要监听的按钮对象
		//GameObject button = GameObject.Find("UI Root/Camera/Anchor/Panel/Icon_middle");
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
		UIEventListener.Get(Icon_glassyColor_darkgreen).onClick = ButtonClick;
		UIEventListener.Get(Icon_glassColor_cyan).onClick = ButtonClick;
		UIEventListener.Get(Icon_glassColor_black).onClick = ButtonClick;
		UIEventListener.Get(Icon_glassColor_gray).onClick = ButtonClick;
		UIEventListener.Get(Icon_glassColor_red).onClick = ButtonClick;
	}
	
	//计算按钮的点击事件
	void ButtonClick(GameObject button)
	{
		colorIcon_name = button.name;
		
	}
	
//	public string screenCarType_name;
	// Use this for initialization
	void Start () {

		//glassMaterial = this.GetComponent<GameManager>().SeletedCarInScene_GlassMaterial;

	}
	
	// Update is called once per frame
	void Update () {

		glassMaterial = this.GetComponent<GameManager>().SeletedCarInScene_GlassMaterial;

/*		switch(colorIcon_name)
		{
			case "ColorCarGlass_black":
				glassMaterial.SetColor("_Color", glassColor_black);
				break;
			case "ColorCarGlass_cyan":
				glassMaterial.SetColor("_Color", glassColor_cyan);
				break;
			case "ColorCarGlass_gray":
				glassMaterial.SetColor("_Color", glassColor_gray);
				break;
			case "ColorCarGlass_red":
				glassMaterial.SetColor("_Color", glassColor_red);
				break;
			case "ColorCarGlass_darkgreen":
				glassMaterial.SetColor("_Color", glassColor_darkgreen);
				break;

		}
		*/
	}

	void OnGUI(){
		GUI.backgroundColor =Color.green;
		//GUI.DrawTexture(Rect(20,300,40,400), tttt, ScaleMode.ScaleToFit, true, 10.0f);
		if(GUI.Button(new Rect(20,100,40,40),darkgreen))
		{
			glassMaterial.SetColor("_Color", glassColor_darkgreen);
		}

		GUI.backgroundColor =Color.cyan;
		if(GUI.Button(new Rect(20,150,40,40),cyan))
		{
			glassMaterial.SetColor("_Color", glassColor_cyan);
		}
		
		GUI.backgroundColor =Color.gray;
		if(GUI.Button(new Rect(20,200,40,40),gray))
		{
			glassMaterial.SetColor("_Color", glassColor_gray);
		}
		
		GUI.backgroundColor =Color.red;
		if(GUI.Button(new Rect(20,250,40,40),red))
		{
			glassMaterial.SetColor("_Color", glassColor_red);
		}

		GUI.backgroundColor =Color.black;
		if(GUI.Button(new Rect(20,300,40,40),black))
		{
			glassMaterial.SetColor("_Color", glassColor_black);
		}
	}
}
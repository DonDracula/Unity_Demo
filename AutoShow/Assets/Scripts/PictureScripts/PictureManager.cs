using UnityEngine;
using System.Collections;

public class PictureManager : MonoBehaviour {

	void Awake () 
	{    
		//SeletedCarInScene = CarType_suv;
		//获取需要监听的按钮对象
		//GameObject button = GameObject.Find("UI Root/Camera/Anchor/Panel/Icon_middle");
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
	//	UIEventListener.Get(Icon_suv).onClick = ButtonClick;
	//	UIEventListener.Get(Icon_mini).onClick = ButtonClick;
	//	UIEventListener.Get(Icon_middle).onClick = ButtonClick;
	}
	
	//计算按钮的点击事件
	void ButtonClick(GameObject button)
	{
	//	screenCarType_name = button.name;
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

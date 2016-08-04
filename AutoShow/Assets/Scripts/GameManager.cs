using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameManager Instance;

//	public GameObject CarType;
	public GameObject CarType_mini;
	public GameObject CarType_middle;
	public GameObject CarType_suv;

	public Material mini_BodyMaterial;
	public Material middle_BodyMaterial;
	public Material suv_BodyMaterial;

	public Material mini_GlassMaterial;
	public Material middle_GlassMaterial;
	public Material suv_GlassMaterial;

	public GameObject Icon_suv;
	public GameObject Icon_mini;
	public GameObject Icon_middle;

	private string screenCarType_name;
	
	public GameObject SeletedCarInScene;
	public Material SeletedCarInScene_BodyMaterial;
	public Material SeletedCarInScene_GlassMaterial;

	void Awake () 
	{    
		SeletedCarInScene = CarType_suv;
		//获取需要监听的按钮对象
		//GameObject button = GameObject.Find("UI Root/Camera/Anchor/Panel/Icon_middle");
		//设置这个按钮的监听，指向本类的ButtonClick方法中。
		UIEventListener.Get(Icon_suv).onClick = ButtonClick;
		UIEventListener.Get(Icon_mini).onClick = ButtonClick;
		UIEventListener.Get(Icon_middle).onClick = ButtonClick;
	}

	//计算按钮的点击事件
	void ButtonClick(GameObject button)
	{
		screenCarType_name = button.name;
		
	}
	
	// Use this for initialization
	void Start () {
		SeletedCarInScene = CarType_suv;
		SeletedCarInScene_BodyMaterial = suv_BodyMaterial;
		SeletedCarInScene_GlassMaterial = suv_GlassMaterial;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		//screenCarType_name = this.GetComponent<SmoothLookAt>().target.name;
		switch(screenCarType_name)
		{
		case "Icon_mini":
			SeletedCarInScene = CarType_mini;
			SeletedCarInScene_BodyMaterial = mini_BodyMaterial;
			SeletedCarInScene_GlassMaterial = mini_GlassMaterial;
			break;
			
		case "Icon_middle":
			SeletedCarInScene = CarType_middle;
			SeletedCarInScene_BodyMaterial = middle_BodyMaterial;
			SeletedCarInScene_GlassMaterial = middle_GlassMaterial;
			break;
			
		case "Icon_suv":
			SeletedCarInScene = CarType_suv;
			SeletedCarInScene_BodyMaterial = suv_BodyMaterial;
			SeletedCarInScene_GlassMaterial = suv_GlassMaterial;
			break;
		}

	}
}

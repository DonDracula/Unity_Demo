using UnityEngine;
using System.Collections;

public class records : MonoBehaviour {

	public Texture2D bu1,bu2,Tex,Tex1,Tex2;
	public GUIStyle MyStyle;
	public int[] score = new int[20];
	public Vector2 scrollPosition = Vector2.zero;
	public GUIStyle myStyle;
	public GUIStyle mmV,mmH;
	public string[] date = new string[20];
	public Texture2D jo;
	public Texture2D[] Numbers;
	public string [] sd;
	public string [] ss;

	public int dateOrScore =1;
	

	void Update(){
		if (Application.platform == RuntimePlatform.Android){ //如果设备为安卓设备 
			if (Input.GetKeyUp(KeyCode.Escape)){//按下的为返回键            
				Application.LoadLevel("begin");//回到主菜单
				//        	beginEscapeAndMenu.ss=2;//设置标志位，不退出游戏           
			}}
		
		float ratioScaleTemp=Screen.height*9/(16*540.0f);
		float ratioScaleTempH=Screen.height/960.0f;
		float sx1 = (Screen.width-Screen.height*9/16)/2;
		
		//var tt=Input.touches;
		if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
		{
			Vector2 tposition=Input.GetTouch(0).position;
			if(tposition.x<=(250+sx1)*ratioScaleTemp&&tposition.x>=(60+sx1)*ratioScaleTemp&&tposition.y>=700*ratioScaleTempH&&tposition.y<=820*ratioScaleTempH )
			{
				dateOrScore=0;
			}
			if(tposition.x<=(500+sx1)*ratioScaleTemp&&tposition.x>=(270+sx1)*ratioScaleTemp&&tposition.y>=700*ratioScaleTempH&&tposition.y<=820*ratioScaleTempH )
			{
				dateOrScore=1;
			}
		}
		
	}
	
	int scrollY=0;
	void OnGUI()
	{
		float curHeight=Screen.height;
		float curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
		float scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
		
		GUI.DrawTexture(new Rect(0+scaleM,0,curWidth,curHeight),Tex); 
		
		if(	GUI.Button(new Rect((50+scaleM),450,180,90),bu1,MyStyle))
		{
			Application.LoadLevel("begin");
		}
		if(GUI.Button(new Rect((220+scaleM),450,180,90),bu2,MyStyle))
		{
			Application.LoadLevel("begin");
		}
		
		
	}
}

using UnityEngine;
using System.Collections;

public class shezhi : MonoBehaviour {
	public Texture blackTexture;
	public Texture shezhiTexture;
	public GUIStyle MyStyle; //去掉系统默认的格式，使用自定义的格式外观
	public Texture helpTexture;
	public Texture backTexture;
	public Texture soundfxTexture;
	public Texture gamemusicTexture;
	public Texture SETTINGSTexture;

	public Texture anniuTexture;
	public Texture duigouTexture;

	public Texture chukongTexture;

	static bool set1=false;
	static bool set2=false;
	static bool set3=false;

	//参考手机的尺寸
	static public int cellHeight=800;
	static public int cellWidth=480;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("set1")==0) {
			set1=false;
		}else{
			set1=true;
		}
		if(PlayerPrefs.GetInt("set2")==0) {
			set2=false;
		}else{
			set2=true;
		}
		if(PlayerPrefs.GetInt("set3")==0) {
			set3=false;
		}else{
			set3=true;
		}
	}
	
	void OnGUI()
	{
		float curHeight=Screen.height;
		float curWidth=Screen.height * cellWidth/cellHeight;
		float scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
		
		GUI.DrawTexture(new Rect(0+scaleM,0,curWidth,curHeight), blackTexture);
		GUI.DrawTexture(new Rect(20+scaleM,20,curWidth-40,curHeight-40), shezhiTexture);
		
		//显示文字
		GUI.Label (new Rect ((120+scaleM), 40, 280, 100), SETTINGSTexture);
		GUI.Label (new Rect ((100+scaleM), 150, 130, 50), soundfxTexture);
		GUI.Label (new Rect ((100+scaleM), 220, 130, 50), gamemusicTexture);
		GUI.Label (new Rect ((100+scaleM), 290, 130, 50), chukongTexture);
		
		//背景音乐
		if(GUI.Button(new Rect((250+scaleM),150,40,40),anniuTexture,MyStyle))//按钮纹理和格式
		{
			set1=!set1;
		}
		if(set1) //实时判断是否要画对号
		{
			GUI.DrawTexture(new Rect((250+scaleM),150,40,40),duigouTexture);//按钮纹理和格式
		}
		
		//场景音乐
		if(GUI.Button(new Rect((250+scaleM),220,40,40),anniuTexture,MyStyle))//按钮纹理和格式
		{
			set2=!set2;
		}
		if(set2)
		{
			GUI.DrawTexture(new Rect((250+scaleM),220,40,40),duigouTexture);//按钮纹理和格式
		}
		//触控模式
		if(GUI.Button(new Rect((250+scaleM),290,40,40),anniuTexture,MyStyle))//按钮纹理和格式
		{
			set3=!set3;//对勾位置1
		}	
		if(set3)
		{
			GUI.DrawTexture(new Rect((250+scaleM),290,40,40),duigouTexture);//按钮纹理和格式
		}
		//确定按钮
		if(GUI.Button(new Rect((100+scaleM),400,60,60),helpTexture,MyStyle))//按钮纹理和格式
		{
			//如果按钮被按下 就判断是否要放音乐
			if(set1)
			{
				PlayerPrefs.SetInt("set1",1);//点确定储存	
			}else
			{
				PlayerPrefs.SetInt("set1",0);//点取消恢复
			}
			if(set2)
			{
				PlayerPrefs.SetInt("set2",1);
			}else{
				PlayerPrefs.SetInt("set2",0);
			}
			if(set3)
			{
				PlayerPrefs.SetInt("set3",1);
			}else{
				PlayerPrefs.SetInt("set3",0);
			}
			Application.LoadLevel("begin");//点确定跳转到主菜单界面
		}	
		if(GUI.Button(new Rect((230+scaleM),400,60,60),backTexture,MyStyle))//按钮纹理和格式
			Application.LoadLevel("begin");//点取消跳转到主菜单界面
	}
}

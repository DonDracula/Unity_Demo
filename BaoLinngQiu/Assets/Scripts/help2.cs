using UnityEngine;
using System.Collections;

public class help2 : MonoBehaviour {

	public Texture help2Texture,jiantouTexture;
	public GUIStyle MyStyle;
	
	void OnGUI()
	{
		float curHeight=Screen.height;
		float curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
		float scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
		
		GUI.DrawTexture(new Rect(scaleM,0,curWidth,curHeight),help2Texture);	
		if (GUI.Button(new Rect((300+scaleM),560,100,100),jiantouTexture,MyStyle))//箭头绘制纹理和格式
			Application.LoadLevel("begin");//触控帮助界面2点击箭头回到主界面
	}
	
	void Update()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				Application.LoadLevel("begin");
			}
		}	
	}
}

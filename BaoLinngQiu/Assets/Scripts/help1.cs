using UnityEngine;
using System.Collections;

public class help1 : MonoBehaviour {

	public Texture help1Texture,jiantouTexture;
	public GUIStyle MyStyle;
	
	void OnGUI()
	{
		float curHeight=Screen.height;
		float curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
		float scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
		
		GUI.DrawTexture(new Rect(scaleM,0,curWidth,curHeight),help1Texture);//绘制格式和纹理图
		if (GUI.Button(new Rect((300+scaleM),560,100,100),jiantouTexture,MyStyle))//绘制格式和纹理图
			Application.LoadLevel("help2");//点击三角进入下一页帮助界面
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

var help2Texture:Texture;
var jiantouTexture:Texture;
var MyStyle:GUIStyle;

function OnGUI()
 {
 	var curHeight=Screen.height;
	var curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
	var scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
		
	GUI.DrawTexture(Rect(scaleM,0,curWidth,curHeight),help2Texture);	
	if (GUI.Button(Rect((300+scaleM),560,100,100),jiantouTexture,MyStyle))//箭头绘制纹理和格式
        Application.LoadLevel("begin");//触控帮助界面2点击箭头回到主界面
}

function Update()
{
	if(Application.platform==RuntimePlatform.Android)
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Application.LoadLevel("begin");
		}
	}	
}
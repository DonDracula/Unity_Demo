var help1Texture:Texture;
var jiantouTexture:Texture;
var MyStyle:GUIStyle;

function OnGUI()
 {
 	var curHeight=Screen.height;
	var curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
	var scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
	
	GUI.DrawTexture(Rect(scaleM,0,curWidth,curHeight),help1Texture);//绘制格式和纹理图
	if (GUI.Button(Rect((300+scaleM),560,100,100),jiantouTexture,MyStyle))//绘制格式和纹理图
        Application.LoadLevel("help2");//点击三角进入下一页帮助界面
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
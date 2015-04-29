var blackTexture : Texture;
var shezhiTexture :Texture;

var MyStyle:GUIStyle;  //去掉系统默认的格式，使用自定义的格式外观

var helpTexture:Texture;
var backTexture:Texture;
var soundfxTexture:Texture;
var gamemusicTexture:Texture;
var SETTINGSTexture:Texture;

var anniuTexture:Texture;
var duigouTexture:Texture;

var chukongTexture : Texture;

static var set1=false;
static var set2=false;
static var set3=false;

//参考手机的尺寸
static var cellHeight=800;
static var cellWidth=480;

function Start() {
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

function OnGUI()
{
	var curHeight=Screen.height;
	var curWidth=Screen.height*cellWidth/cellHeight;
	var scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间

	GUI.DrawTexture(Rect(0+scaleM,0,curWidth,curHeight), blackTexture);
	GUI.DrawTexture(Rect(20+scaleM,20,curWidth-40,curHeight-40), shezhiTexture);
	
	//显示文字
	GUI.Label (Rect ((120+scaleM), 40, 280, 100), SETTINGSTexture);
	GUI.Label (Rect ((100+scaleM), 150, 130, 50), soundfxTexture);
	GUI.Label (Rect ((100+scaleM), 220, 130, 50), gamemusicTexture);
	GUI.Label (Rect ((100+scaleM), 290, 130, 50), chukongTexture);
	
	//背景音乐
	if(GUI.Button(Rect((250+scaleM),150,40,40),anniuTexture,MyStyle))//按钮纹理和格式
	{
		set1=!set1;
	}
	if(set1) //实时判断是否要画对号
	{
		GUI.DrawTexture(Rect((250+scaleM),150,40,40),duigouTexture);//按钮纹理和格式
	}
	
	//场景音乐
	if(GUI.Button(Rect((250+scaleM),220,40,40),anniuTexture,MyStyle))//按钮纹理和格式
	{
		set2=!set2;
	}
	if(set2)
	{
		GUI.DrawTexture(Rect((250+scaleM),220,40,40),duigouTexture);//按钮纹理和格式
	}
	//触控模式
	if(GUI.Button(Rect((250+scaleM),290,40,40),anniuTexture,MyStyle))//按钮纹理和格式
	{
		set3=!set3;//对勾位置1
	}	
	if(set3)
	{
		GUI.DrawTexture(Rect((250+scaleM),290,40,40),duigouTexture);//按钮纹理和格式
	}
	//确定按钮
	if(GUI.Button(Rect((100+scaleM),400,60,60),helpTexture,MyStyle))//按钮纹理和格式
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
	if(GUI.Button(Rect((230+scaleM),400,60,60),backTexture,MyStyle))//按钮纹理和格式
		Application.LoadLevel("begin");//点取消跳转到主菜单界面
 }
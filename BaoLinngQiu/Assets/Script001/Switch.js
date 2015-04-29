var backTexture : Texture;//背景图片
var ChooseYourSceneTexture :Texture;
var ChooseYourBallTexture:Texture;
var MyStyle:GUIStyle;//绘制样式
var PlayNowTexture:Texture;//开始游戏按钮图片
var LeaderBoardTexture:Texture;
var SettingsTexture:Texture;//设置按钮图片
var StatisticsTexture:Texture;//统计按钮图片
//纹理图片
var wenliTexture:Texture;var wenli1Texture:Texture;var wenli2Texture:Texture;
var wenli3Texture:Texture;var wenli4Texture:Texture;
var beijingyinyue:AudioSource;//背景音乐
var ball : Rigidbody;//刚体球
static var set3=0;
function Start()
{
	var set3=PlayerPrefs.GetInt("set3");
}
function OnGUI()
{
	var curHeight=Screen.height;
	var curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
	var scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间

    if (GUI.Button(Rect((40+scaleM),500,60,60),PlayNowTexture,MyStyle))//按钮纹理和样式
    {
      	if(set3==1)//如果游戏模式为触控模式则加载触控模式游戏场景
      	{
      		Application.LoadLevel("ball");
      	}else
      	{
      		Application.LoadLevel("ball1");
      	}
      	Destroy(this);//销毁节约资源
    }
    if (GUI.Button(Rect((120+scaleM),500,60,60),SettingsTexture,MyStyle))//按钮纹理和样式
    {
	        Application.LoadLevel("settings");//点击设置按钮进入设置场景
	        Destroy(this);//销毁节约资源
    }
  	if (GUI.Button(Rect((200+scaleM),500,60,60),StatisticsTexture,MyStyle))//按钮纹理和样式
    {
	        Application.LoadLevel("records");//点击设统计钮进入统计场景
	        Destroy(this);//销毁节约资源
    }
   	if (GUI.Button(Rect((280+scaleM),500,60,60),LeaderBoardTexture,MyStyle))//按钮纹理和样式
    {
	        Application.LoadLevel("help"); //点击帮助按钮进入帮助场景	
	        Destroy(this);//销毁节约资源
    } 
}  
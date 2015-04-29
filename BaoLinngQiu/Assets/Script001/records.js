var Tex:Texture2D;
var Tex1:Texture2D;
var Tex2:Texture2D;
var bu1:Texture2D;
var bu2:Texture2D;
var MyStyle:GUIStyle;
var score = new int[20];
var scrollPosition : Vector2 = Vector2.zero;
var myStyle:GUIStyle;
var mmV:GUIStyle;
var mmH:GUIStyle;
var date = new String[20];
var jo:Texture2D;
var Numbers:Texture2D[];
var sd : String[];
var ss : String[];

var dateOrScore : int=1;


function Update(){
	if (Application.platform == RuntimePlatform.Android){ //如果设备为安卓设备 
    	if (Input.GetKeyUp(KeyCode.Escape)){//按下的为返回键            
        	Application.LoadLevel("begin");//回到主菜单
//        	beginEscapeAndMenu.ss=2;//设置标志位，不退出游戏           
}}
    
    var ratioScaleTemp=Screen.height*9/(16*540.0);
	var ratioScaleTempH=Screen.height/960.0;
	var sx1 = (Screen.width-Screen.height*9/16)/2;

	var tt=Input.touches;
	if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Began)
	{
		var tposition=Input.GetTouch(0).position;
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
    
var scrollY=0;
function OnGUI()
{
	var curHeight=Screen.height;
	var curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
	var scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间
	
	GUI.DrawTexture(Rect(0+scaleM,0,curWidth,curHeight),Tex); 
	
	if(	GUI.Button(Rect((50+scaleM),450,180,90),bu1,MyStyle))
	{
		Application.LoadLevel("begin");
	}
	if(GUI.Button(Rect((220+scaleM),450,180,90),bu2,MyStyle))
	{
		Application.LoadLevel("begin");
	}
	
	
}

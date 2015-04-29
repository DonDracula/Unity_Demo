//声明初始化变量
var x : float; var y : float; var z : float;
var k : float; var m : float; var p : float; var n : int;

var spare : GameObject;
var strike : GameObject;
var taizi : GameObject;

var pzTemplete : Rigidbody;
var ballTemplete : Rigidbody;
var pz: Rigidbody[] ;
var ball : Rigidbody;
var downs1:int;
var count : int =0;
var down : boolean=false;
static var tz:boolean=false;
static var pzz : boolean =false;
static var curJu=0;
static var curQiu=0;

function Start()
{
	curJu=0;
	curQiu=0;
	tz=false;//下降台标志
    pz=new Rigidbody[10];//储存刚体瓶子
	for(i=0;i<=n;i++)
	{
		for(var j : int =0;j<i;j++)//初始化瓶子并存入数组
		{
			pz[count++]=Instantiate (pzTemplete, Vector3(x-k*i+2*j*k,4.845032,z-1.5*k*i), pzTemplete.rotation);
		}
	}	
	ball=Instantiate(ballTemplete, Vector3(3.25,5.170333,27.6), ballTemplete.rotation);//初始化保龄球
	var wenli=PlayerPrefs.GetString("wl");
	ball.renderer.material.mainTexture=Resources.Load(wenli,Texture2D);
	Camera.main.transform.position=Vector3(3.296673,12,54);//摄像机位置为1
	TouchtoMove.status=false;//移动标志位为false
}

function Update () 
{
    if(ball.transform.position.y < -50)//发第一球且球落下平台 
    {  
    	curQiu++;
    	if(curQiu>=2)   //进入下一局
    	{
    		curJu++;   //局增加
    		curQiu=0;
    		var count=0;
    		for(i=0;i<=n;i++)
 			{
 				for(var j:int =0;j<i;j++)//初始化瓶子
 				{
 					if(pz[count]!=null) DestroyImmediate(pz[count].gameObject,true);//摧毁旧的瓶子
 					pz[count++]=Instantiate (pzTemplete, Vector3(x-k*i+2*j*k,y,z-1.5*k*i),pzTemplete.rotation);
 				}
	 		}	
    		
    		tz=true;   //升降台启动
    		pzz=true;  //瓶子下降
    	}
    	
    	if(curJu>=10)   //达到10局了
    	{
    		print("完成10局了");
    		return;
    	}
    	
    	downs1=0;//记录击中的瓶子     	     
      	ball.transform.position=Vector3(3.25,5.170333,27.6);//球回到初始位置
      	Camera.main.transform.position=Vector3(3.296673,12,54);//摄像机移到位置2
       	ball.rigidbody.Sleep();//强制保龄球休息一帧
       	TouchtoMove.status=false;
       	for(i=0;i<10;i++) 
       	{   		 
       		if(pz[i]==null) 
       		{ 
       			downs1++;     	//获得击中瓶子的总数		
       		}
       	} 
       	print("下一局："+(curJu+1)+";下一球："+(curQiu+1)+";当前击中："+downs1);
		if(downs1==10)//击倒剩余的瓶子 
		{ 	
			spare1=Instantiate(spare,Vector3(3.296673,9,12), spare.transform.rotation);//spare彩蛋
			Destroy(spare1.gameObject,2); 
			curQiu++;
		}
	}
}

function FixedUpdate()//下降台子移动
{
	var i : int;
	if(taizi.transform.position.y>10)//台子高度大于10
	{
		down=true;//标志位为下降
	}else if(taizi.transform.position.y<5.5)//台子高度小于5.5
	{
		down=false;//标志位为上升
	}
	if(tz)//1局后
	{
		if(down)//下降
		{
			taizi.transform.position.y-=0.05;//每秒下降0.05
		}else//上升
		{
			taizi.transform.position.y+=0.05;//每秒上升0.05
		}
		if(taizi.transform.position.y>10 && !down)//如果台子升到10并且处于上升状态
		{
			tz=false;//台子停止
		}
	}
	if(pzz)//瓶子下降
	{
		for(i=0;i<10;i++)
		{
			if(pz[i]!=null)//如果当前瓶子数组不为空
			{
				pz[i].rigidbody.useGravity=false;//取消瓶子的重力特性
				if(pz[i].rigidbody.transform.position.y>4.9)//如果高度大于4.9
				{
					pz[i].rigidbody.transform.position.y-=0.05;//每秒下降0.05
				}
				if(pz[i].rigidbody.transform.position.y<4.9)//如果高度低于4.9
				{
					pz[i].rigidbody.useGravity=true;//每秒上升0.05
					pzz=false;
				}
			}else//为空进入数组下一位
			{
				continue;
			}	
		}
	}
}












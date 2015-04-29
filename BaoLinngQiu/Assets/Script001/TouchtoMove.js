var mzFlag : boolean;
var startX : float;
var startY : float;
var endX : float;
var endY : float;
var resultX : float;
var resultY : float;
public static var status:boolean;//false 没有发射球  true 球运动中

function Start()//先读取当前模式
{

}
function Update () 
{
	//鼠标模式
    if(Input.GetMouseButtonDown(0))
	{
		if(status)  //false 没有发射球  true 球运动中
	    {
	    	return;
	    }
		if(!mzFlag) 
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    	var hit : RaycastHit;
	    	mzFlag=false;
	        
			if (Physics.Raycast (ray, hit))
			{
	    		if(hit.transform.root.transform==this.transform)	      
	        	{	
	        		mzFlag=true;  //触摸到球
	        		startX=Input.mousePosition.x;
		   			startY=Input.mousePosition.y; 	
	         	}
		 	}      
		}
	}  
 
    if(Input.GetMouseButtonUp(0) && mzFlag)//手指离开屏幕
    {
	    endX=Input.mousePosition.x;//离开屏幕时手指位置
		endY=Input.mousePosition.y;  
	   	resultX=endX-startX;//位置的距离
	   	resultY=endY-startY;
	   	var angle=Mathf.Atan2(resultX,resultY)/2.5;//距离转换为速度
	   	var minV=12;//速度下限和上限
	   	var maxV=28;
	   	var currV=minV+(maxV-minV)*Mathf.Sqrt(resultX*resultX+resultY*resultY)/800.0;//移动速度
		this.transform.position=new Vector3 (this.transform.position.x,this.transform.position.y+0.1,this.transform.position.z);//移动的初始位置
	   	this.rigidbody.velocity=Vector3(-currV*Mathf.Sin(angle)*1.4,0,-currV*Mathf.Cos(angle)*1.4);//进行移动
	   	status=true;//移动标志位		
	   	mzFlag=false;  
    }	
	if(this.transform.position.z<6 && status)//如果球过来某位置
	{
		Camera.main.transform.position=Vector3(3.296673,10,22);//移动摄像机到位置2
	}	
}

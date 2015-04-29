using UnityEngine;
using System.Collections;

public class TouchToMove : MonoBehaviour {
	public bool mzFlag;
	public float startX,startY,endX,endY,resultX,resultY;
	public static bool status;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if(status)  //false 没有发射球  true 球运动中
			{
				return;
			}
			if(!mzFlag) 
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				mzFlag=false;
				
				if (Physics.Raycast (ray, out hit))
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
			float angle=Mathf.Atan2(resultX,resultY)/2.5f;//距离转换为速度
			int minV=12;//速度下限和上限
			int maxV=28;
			float currV=minV+(maxV-minV)*Mathf.Sqrt(resultX*resultX+resultY*resultY)/800.0f;//移动速度
			this.transform.position=new Vector3 (this.transform.position.x,this.transform.position.y+0.1f,this.transform.position.z);//移动的初始位置
			this.rigidbody.velocity=new Vector3(currV*Mathf.Sin(angle)*1.4f,0,currV*Mathf.Cos(angle)*1.4f);//进行移动
			status=true;//移动标志位		
			mzFlag=false;  
		}	
		if(this.transform.position.z>10 && status)//如果球过来某位置
		{
			Camera.main.transform.position=new Vector3(2,1,11);//移动摄像机到位置2
		}	

	}
}

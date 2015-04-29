using UnityEngine;
using System.Collections;
using System;

public class Init : MonoBehaviour {
	public float x,y,z,k,m,p;
	public int n,downs1;
	public GameObject spare;
	public GameObject strike;
	public GameObject taizi;
	private GameObject spare1;

	public Transform beijing;

	public Rigidbody pzTemplete;
	public Rigidbody ballTemplete;
	public Rigidbody[] pz;
	public Rigidbody ball;

	public int count=0;
	public bool down = false;
	public static bool tz =false;
	public static bool pzz =false;
	public static int curJu =0;
	public static int curQiu =0;

	private float time = 0;
	// Use this for initialization
	void Start () {
		curJu=0;
		curQiu=0;
		tz=false;//下降台标志
		pz=new Rigidbody[10];//储存刚体瓶子
		for(int i=0;i<=n;i++)
		{
			for(int j =0;j<i;j++)//初始化瓶子并存入数组
			{
				pz[count++]=(Rigidbody)Instantiate (pzTemplete,new Vector3(x-k*i+2*j*k,0f,z+1.5f*k*i), pzTemplete.rotation);
			}
		}	
		ball=(Rigidbody)Instantiate(ballTemplete, new Vector3(3,-0.85f,-6f), ballTemplete.rotation);//初始化保龄球

		string wenli=PlayerPrefs.GetString("wl");

		//ball.renderer.material.mainTexture =(Texture) Resources.Load("wenli1", typeof(Texture2D));
		ball.renderer.material.mainTexture = Resources.Load(wenli) as Texture;
		Debug.Log("wenliliiiiii="+wenli);
		//ball.renderer.material.SetTexture
		Camera.main.transform.position=new Vector3(3,2.8f,-10);//摄像机位置为1
		TouchToMove.status=false;//移动标志位为false
	}
	
	// Update is called once per frame
	void Update () {
		time +=Time.deltaTime;
		//Debug.Log(time);
		if(ball.transform.position.y < -50 ||time > 15 )//发第一球且球落下平台 
		{  
			curQiu++;
			if(curQiu>=2)   //进入下一局
			{
				curJu++;   //局增加
				curQiu=0;
				int count=0;
				for(int i=0;i<=n;i++)
				{
					for(int j =0;j<i;j++)//初始化瓶子
					{
						if(pz[count]!=null) DestroyImmediate(pz[count].gameObject,true);//摧毁旧的瓶子
						pz[count++]=(Rigidbody)Instantiate (pzTemplete,new Vector3(x-k*i+2*j*k,y,z+1.5f*k*i), pzTemplete.rotation);
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

			time = 0;
			
			downs1=0;//记录击中的瓶子     	     
			ball.transform.position=new Vector3(3,-0.85f,-6f);//球回到初始位置
			Camera.main.transform.position=new Vector3(3,2.8f,-10);//摄像机移到位置2
			ball.rigidbody.Sleep();//强制保龄球休息一帧
			TouchToMove.status=false;
			for(int i=0;i<10;i++) 
			{   		 
				if(pz[i]==null) 
				{ 
					downs1++;     	//获得击中瓶子的总数		
				}
			} 
			print("下一局："+(curJu+1)+";下一球："+(curQiu+1)+";当前击中："+downs1);
			if(downs1==10)//击倒剩余的瓶子 
			{ 	
				spare1=(GameObject)Instantiate(spare,beijing.transform.position, spare.transform.rotation);//spare彩蛋
				Destroy(spare1.gameObject,2); 
				curQiu++;
			}
		}
	}
	void FixedUpdate()//下降台子移动
	{
		int i;
		if(taizi.transform.position.y>5)//台子高度大于5
		{
			down=true;//标志位为下降
		}else if(taizi.transform.position.y<1f)//台子高度小于1
		{
			down=false;//标志位为上升
		}
		if(tz)//1局后
		{
			float posY = 0;
			if(down)//下降
			{
				posY -=0.05f;
				taizi.transform.position=
					new Vector3(taizi.transform.position.x,taizi.transform.position.y+posY,taizi.transform.position.z);//每秒下降0.05
			}else//上升
			{
				posY +=0.05f;
				taizi.transform.position=
					new Vector3(taizi.transform.position.x,taizi.transform.position.y+posY,taizi.transform.position.z);//每秒up0.05
			}
			if(taizi.transform.position.y>5 && !down)//如果台子升到5并且处于上升状态
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
					float pY = 0;
					pz[i].rigidbody.useGravity=false;//取消瓶子的重力特性
					if(pz[i].rigidbody.transform.position.y>0f)//如果高度大于4.9
					{
						pY-=0.05f;
						//每秒下降0.05
						pz[i].rigidbody.transform.position= 
							new Vector3(pz[i].rigidbody.transform.position.x,pz[i].rigidbody.transform.position.y+pY,pz[i].rigidbody.transform.position.z);//每秒下降0.05
					}
					if(pz[i].rigidbody.transform.position.y<0f)//如果高度低于4.9
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

}
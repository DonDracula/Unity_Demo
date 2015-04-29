var y:float;//声明变量
var x:float;
var z:float;

function Start()
{
	y=this.transform.rotation.y;//获取开始时瓶子的x,y,z轴数值
	x=this.transform.rotation.x;
	z=this.transform.rotation.z;
}

function Update () 
{	
	if(Mathf.Abs(this.transform.rotation.y-y)>0.2||
		Mathf.Abs(this.transform.rotation.x-x)>0.2||
		Mathf.Abs(this.transform.rotation.z-z)>0.2)//如果瓶子的x,y,z任一轴读书变换超过0.2则认为瓶子被击倒
	{
		Destroy(this.gameObject,2);//2秒后销毁瓶子
	}
}
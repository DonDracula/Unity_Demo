function Update () 
{
	if(ballzizhuan1.flag1)//选中第一个球，第一个球自转
	{
		transform.position=new Vector3(-1,-7.3,-1.5);
	}
	if(ballzizhuan2.flag2)//选中第二个球，第二个球自转
	{
		transform.position=new Vector3(-1,-7.3,0);
	}
	if(ballzizhuan3.flag3)//选中第三个球，第三个球自转
	{
		transform.position=new Vector3(-1,-7.3,1.5);
	}
	if(ballzizhuan4.flag4)//选中第四个球，第四个球自转
	{
		transform.position=new Vector3(0.6,-7.3,-1.5);
	}
	if(ballzizhuan5.flag5)//选中第五个球，第五个球自转
	{
		transform.position=new Vector3(0.6,-7.3,0);
	}
	if(ballzizhuan6.flag6)//选中第六个球，第六个球自转
	{
		transform.position=new Vector3(0.6,-7.3,1.5);
	}
}
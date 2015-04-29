var flag : boolean ;
function Update () 
{
	if(this.transform.position.y>6.5)
	{
		flag=true;
	}else if(this.transform.position.y<6)
	{
		flag=false;
	}
	
	if(flag)
	{
		this.transform.position.y-=0.12;
	}else 
	{
		this.transform.position.y+=0.12;
	}
	
}

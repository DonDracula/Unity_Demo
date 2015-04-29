static var flag1 : boolean=true;

function Update () 
{	
	if(Input.GetMouseButtonDown(0)) {
   		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit : RaycastHit;
		if (Physics.Raycast (ray, hit))
	    {
            if(hit.transform.root.transform==this.transform)	      
            {	
            	flag1=true;
            	ballzizhuan2.flag2=false;
            	ballzizhuan3.flag3=false;
            	ballzizhuan4.flag4=false;
            	ballzizhuan5.flag5=false;
            	ballzizhuan6.flag6=false;
            	PlayerPrefs.SetString("wl","wenli1");

            }
	    }      	
	}
	if(flag1)
	{
 		this.transform.Rotate(-Time.deltaTime * 500,0,0);
	}else{
		this.transform.Rotate(-Time.deltaTime * 50,0,0);
	}
}
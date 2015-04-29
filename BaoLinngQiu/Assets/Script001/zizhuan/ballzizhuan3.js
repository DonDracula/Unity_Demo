static var flag3 : boolean=false;

function Update () 
{	
	if(Input.GetMouseButtonDown(0)) {
   		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit : RaycastHit;
		if (Physics.Raycast (ray, hit))
	    {
            if(hit.transform.root.transform==this.transform)	      
            {	
            	flag3=true;
            	ballzizhuan1.flag1=false;
            	ballzizhuan2.flag2=false;
            	ballzizhuan4.flag4=false;
            	ballzizhuan5.flag5=false;
            	ballzizhuan6.flag6=false;
            	PlayerPrefs.SetString("wl","wenli3");
            }
	    }      	
	}
	if(flag3)
	{
 		this.transform.Rotate(-Time.deltaTime * 500,0,0);
	}else{
		this.transform.Rotate(-Time.deltaTime * 50,0,0);
	}
}
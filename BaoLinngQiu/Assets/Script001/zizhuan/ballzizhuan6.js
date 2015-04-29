static var flag6 : boolean=false;

function Update () 
{	
	if(Input.GetMouseButtonDown(0)) {
   		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit : RaycastHit;
		if (Physics.Raycast (ray, hit))
	    {
            if(hit.transform.root.transform==this.transform)	      
            {	
            	flag6=true;
            	ballzizhuan1.flag1=false;
            	ballzizhuan2.flag2=false;
            	ballzizhuan3.flag3=false;
            	ballzizhuan4.flag4=false;
            	ballzizhuan5.flag5=false;
            	PlayerPrefs.SetString("wl","wenli6");
            }
	    }      	
	}
	if(flag6)
	{
 		this.transform.Rotate(-Time.deltaTime * 500,0,0);
	}else{
		this.transform.Rotate(-Time.deltaTime * 50,0,0);
	}
}
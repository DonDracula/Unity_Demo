using UnityEngine;
using System.Collections;

public class PlayerHealthy : MonoBehaviour {
	public float maxHealth=100.0f;
	public  float curHealth=100.0f;
	public GameObject blood;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel("start");
		}
	}
	public void addjustCurrentHealth(float hit){
		
		curHealth +=hit;
		if(curHealth<0){
			curHealth=0;
			transform.GetComponent<Animation>().Play("K_die");
			transform.GetComponent<Animation>()["K_die"].speed=3.0f;
			transform.GetComponent<Animation>()["K_die"].wrapMode=WrapMode.ClampForever;
		
			target.GetComponent<Animation>().GetComponent<Animation>().CrossFade("I_laugh");
			transform.FindChild("Illidan").GetComponent<Animation>()["I_laugh"].wrapMode=WrapMode.ClampForever;
			
			Destroy(transform.GetComponent<ThirdPersonController>());
			
		}
		if(curHealth>100){curHealth=100;}
		float cur=curHealth/maxHealth;
		blood.GetComponent<UISlider>().sliderValue=cur;		
	}
	
}

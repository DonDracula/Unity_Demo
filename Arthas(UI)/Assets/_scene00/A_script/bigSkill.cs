using System.Collections;
using UnityEngine;

public class bigSkill : MonoBehaviour {
	public float maxpower=100.0f;
	public  float curpower=0.0f;
	public GameObject power;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addjustCurrentPower(float lose){
		
		curpower +=lose;
		if(curpower<0){
			curpower=0;
		}
		if(curpower>100){curpower=100;}
		float cur=curpower/maxpower;
		Debug.Log(lose);
		power.GetComponent<UISlider>().sliderValue=cur;
		
		
		
	}
}

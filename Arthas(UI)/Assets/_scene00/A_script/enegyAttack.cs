using UnityEngine;
using System.Collections;

public class enegyAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coldDown;
	
	
	// Use this for initialization
	void Start () {
		attackTimer=0;
		coldDown=1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer>0)
			attackTimer-=Time.deltaTime;
		if(attackTimer<0)
			attackTimer=0;
		
			if(attackTimer==0){
				Attack();
				attackTimer=coldDown;
			}
		
	}
	private void Attack(){
		float distance=Vector3.Distance(target.transform.position,transform.position);
		
		Vector3 dir=(target.transform.position-transform.position).normalized;
		float direction=Vector3.Dot(dir,transform.forward);
		if(distance<=10.0f){
			if(direction>0){
				PlayerHealthy eh=(PlayerHealthy)target.GetComponent("PlayerHealthy");
				if(eh.curHealth>0){
					transform.FindChild("Illidan").GetComponent<Animation>().Play("I_attack");
					transform.FindChild("Illidan").GetComponent<Animation>()["I_attack"].speed=3.0f;
				}
				eh.addjustCurrentHealth(-10.0f);
	
		}
			
	}
}
	
}
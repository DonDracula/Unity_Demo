using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	public GameObject target2;
	public float attackTimer;
	public  float attackTimer2;
	public float coldDown;
	
	//public AnimationClip attackAnimation  ;
	// Use this for initialization
	void Start () {
		GetComponent<Animation>().Stop();//禁用Animaton组件中的Play Automatically。
		GetComponent<Animation>()["K_attack"].wrapMode = WrapMode.Clamp;//设置名为idle的动画片段的wrapMode属性为WrapMode.Clamp。

		attackTimer=0;
		coldDown=2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer>0)
			attackTimer-=Time.deltaTime;
		if(attackTimer<0)
			attackTimer=0;
		if(attackTimer2>0)
			attackTimer2-=Time.deltaTime;
		if(attackTimer2<0)
			attackTimer2=0;
		
		bigSkill bs=(bigSkill)transform.GetComponent("bigSkill");
	
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(attackTimer==0){
				
				int num=new System.Random().Next(2);
			//	transform.animation.Play("K_attack");
				if(num==0){
			    		transform.GetComponent<Animation>().CrossFade("K_attack");
						transform.GetComponent<Animation>()["K_attack"].speed=2.0f;
				}
				if(num==1){
				
						transform.GetComponent<Animation>().CrossFade("K_hit");
				}
				bs.addjustCurrentPower(+20.0f);
				Attack(-50);
				attackTimer=coldDown;
			}
		}
		if(Input.GetKeyDown(KeyCode.G))
		{	if(bs.curpower>=50){
				if(attackTimer2==0){
					transform.GetComponent<Animation>().Play("K_big");
					Attack(-200);
					attackTimer2=coldDown;
					bs.addjustCurrentPower(-50);
				}
			}
		}
	}
	private void Attack(float damage){
		float distance=Vector3.Distance(target.transform.position,transform.position);
		
		Vector3 dir=(target.transform.position-transform.position).normalized;
		float direction=Vector3.Dot(dir,transform.forward);
		if(distance<10.0f){
			if(direction>0){
				
//				transform.animation.CrossFade(attackAnimation.name);
				EnemyHealthy eh=(EnemyHealthy)target.GetComponent("EnemyHealthy");
				eh.addjustCurrentHealth(damage);
			}
		}
	}
}

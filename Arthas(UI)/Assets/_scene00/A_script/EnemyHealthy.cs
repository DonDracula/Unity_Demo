using UnityEngine;
using System.Collections;

public class EnemyHealthy : MonoBehaviour {
	public float maxHealth=1000.0f;
	public float curhealth=1000.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject player;
	public GameObject enemySymbol;
	public GameObject enemyBar;
	public void addjustCurrentHealth(float damage){
		curhealth+=damage;
		if(curhealth<=0)
		{
			curhealth=0;
			Destroy(transform.GetComponent<enegyAttack>());
			Destroy(transform.GetComponent<enegyAI>());
			
			transform.FindChild("Illidan").GetComponent<Animation>().CrossFade("I_die");
			transform.FindChild("Illidan").GetComponent<Animation>()["I_die"].wrapMode=WrapMode.ClampForever;
			//transform.FindChild("Illidan").animation.Stop();
			
			
		}
		if(curhealth>1000){
			curhealth=1000;
		}
		enemySymbol.transform.position=new  Vector3(enemySymbol.transform.position.x,player.transform.position.y*18.0f,enemySymbol.transform.position.z);
		enemyBar.transform.position=new  Vector3(enemyBar.transform.position.x,player.transform.position.y*18.0f,enemyBar.transform.position.z);
		float cur=curhealth/maxHealth;
		enemyBar.GetComponent<UISlider>().sliderValue=cur;	
	}
}

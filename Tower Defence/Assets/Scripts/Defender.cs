using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	//target enemy
	Enemy m_targetEnemy;
	//attact distance
	public float m_attackArea = 4.0f;

	//aggressivity
	public int m_power = 1;

	//attact interval
	public float m_attackTimer = 1.0f;

	//attack time
	public float m_timer = 0.0f;

	// Use this for initialization
	void Start () {
		//change this grid to CanNotStand
		GridMap.Instance.m_map[(int)this.transform.position.x,
		                       (int)this.transform.position.z].fieldtype = MapData.FieldTypeID.CanNotStand;
	}
	
	// Update is called once per frame
	void Update () {
		FindEnemy();
		RotateTo();
		Attack();
	}

	//rotate to the enemy
	public void RotateTo()
	{
		if(m_targetEnemy == null)
			return;

		Vector3 current = this.transform.eulerAngles;
		this.transform.LookAt(m_targetEnemy.transform);
		Vector3 target = this.transform.eulerAngles;
		float next = Mathf.MoveTowardsAngle(current.y,target.y,120*Time.deltaTime);
		this.transform.eulerAngles = new Vector3(current.x,next,current.z);
	}

	//search the enemy
	void FindEnemy()
	{
		//clean the enemy
		m_targetEnemy = null;

		//compare the enemy's life value
		int lastlife = 0;

		//iterate all the enemies in the arraylist
		foreach( Enemy enemy in GameManager.Instance.m_EnemyList)
		{
			//ignore enemies whose life is finished
			if(enemy.m_life == 0)
				continue;

			Vector3 pos1 = this.transform.position;
			Vector3 pos2 = enemy.transform.position;

			//distance to the enemy
			float dist = Vector2.Distance(new Vector2(pos1.x,pos1.z),new Vector2(pos2.x,pos2.z));

			//ignore enemy which is out of the attact distance
			if(dist > m_attackArea)
				continue;

			//find the enemy whose life value is the lowest
			if(lastlife == 0|| lastlife > enemy.m_life)
			{
				m_targetEnemy = enemy;

				lastlife= enemy.m_life;
			}

		}
	}

	//attack the enemies
	public void Attack()
	{
		//update the interval time
		m_timer -=Time.deltaTime;

		if(m_targetEnemy == null)
			return;

		if(m_timer > 0)
			return;

		//hit the enemy
		m_targetEnemy.SetDamage(m_power);

		//init the attact interval
		m_timer = m_attackTimer;
	}
}

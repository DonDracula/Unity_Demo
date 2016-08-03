using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//pathnode
	public PathNode m_currentNode;

	//life
	public int m_life = 15;

	//max life value
	public int m_maxLife = 15;

	//moving speed
	public float m_speed =2 ;

	//life bar
	public Transform m_lifeBarObject;
	protected LifeBar m_bar;

	//enemy type 
	public enum TYPE_ID
	{
		GROUND,
		ARI,
	}

	public TYPE_ID m_type = TYPE_ID.GROUND;

	public EnemySpawner m_spawn;

	void Start()
	{
		m_spawn.m_liveEnemy++;

		GameManager.Instance.m_EnemyList.Add(this);

		//create life bar
		Transform obj = (Transform)Instantiate(m_lifeBarObject,this.transform.position,Quaternion.identity);
		m_bar = obj.GetComponent<LifeBar>();
		m_bar.Ini(m_life,m_maxLife,2,0.2f);
	}

	// Update is called once per frame
	void Update () {

		RotateTo();
		MoveTo();
	}

	//turn to next pathnode
	public void RotateTo()
	{
		float current = this.transform.eulerAngles.y;
		this.transform.LookAt(m_currentNode.transform);

		Vector3 target = this.transform.eulerAngles;

		float next = Mathf.MoveTowardsAngle(current,target.y,120*Time.deltaTime);

		this.transform.eulerAngles = new Vector3(0,next,0);
	}

	//move to next pathnode
	public void MoveTo()
	{
		Vector3 pos1 = this.transform.position;
		Vector3 pos2 = m_currentNode.transform.position;

		//distance to the childnode
		float dist = Vector2.Distance(new Vector2(pos1.x,pos1.z),new Vector2(pos2.x,pos2.z));
//		Debug.Log("dist==================================="+dist);
		if(dist < 1.0f)
		{
			if(m_currentNode.m_next == null)
			{
				GameManager.Instance.SetDamage(1);
				Destroy(this.gameObject);

			}
			else
				m_currentNode = m_currentNode.m_next;
		}

			this.transform.Translate(new Vector3(0,0,m_speed*Time.deltaTime));
		m_bar.SetPosition(this.transform.position,4.0f);
	}

	void OnDisable()
	{
		if(m_spawn)
			m_spawn.m_liveEnemy--;

		if(GameManager.Instance)
			GameManager.Instance.m_EnemyList.Remove(this);

		//destory the bar
		if(m_bar)
			Destroy(m_bar.gameObject);
	}

	public void SetDamage(int damage)
	{
		m_life -= damage;
		if(m_life <=0)
		{
		//	GameManager.Instance.m_EnemyList.Remove(this);
			//increase some points when kill an enemy
			GameManager.Instance.SetPoint(2);
			Destroy(this.gameObject);
		}
		else 
			m_bar.UpdateLife(m_life,m_maxLife);
	}
}

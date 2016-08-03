using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//define the enemy tag
	[System.Serializable]
	public class EnemyTable
	{
		public string enemyName = "";
		public Transform enemyPrefab;
	}

	//XML data
	public class SpawnData
	{
		//waves
		public int wave = 1;
		public string enemyname = "";
		public int level =1;
		public float wait = 1.0f;
	}

	//enemy
	public EnemyTable[] m_enemies;
	//start node
	public PathNode m_startNode;

	//save the xml of the enemy turn
	public TextAsset xmldata;

	//save the data read from the xml
	ArrayList m_enemyList;

	//time to the enemy appear
	float m_timer = 0;

	//enemy index which has appeared
	int m_index = 0;

	//amount of the present enemies,turn to next wave after the enmeies were killed this time
	public int m_liveEnemy =0;

	// Use this for initialization
	void Start () {
		//read xml
		ReadXML();

		//get next enemy
		SpawnData data = (SpawnData)m_enemyList[m_index];
		m_timer = data.wait;

	}

	//read xml
	void ReadXML()
	{
		m_enemyList = new ArrayList();

		XMLParser xmlparse = new XMLParser();
		XMLNode node = xmlparse.Parse(xmldata.text);

		XMLNodeList list = node.GetNodeList("ROOT>0>table");
		for(int i =0; i< list.Count; i++)
		{
			string wave = node.GetValue("ROOT>0>table>"+i+">@wave");
			string enemyname = node.GetValue("ROOT>0>table>"+i+ ">@enemyname");
			string level = node.GetValue("ROOT>0>table>"+i+">@level");
			string wait = node.GetValue("ROOT>0>table>"+i+">@wait");

			SpawnData data = new SpawnData();
			data.wave = int.Parse(wave);
			data.enemyname = enemyname;
			data.level = int.Parse(level);
			data.wait = float.Parse(wait);

			m_enemyList.Add(data);
		}
	}
	
	// Update is called once per frame
	void Update () {
		SpawnEnemy();
	}

	void SpawnEnemy()
	{
		//if all the enemies are born
		if(m_index >= m_enemyList.Count)
			return;
		//get next enemy
		SpawnData data = (SpawnData)m_enemyList[m_index];

		//all the enemy should disappear before next wave
		if(GameManager.Instance.m_wave < data.wave && m_liveEnemy > 0)
			return;

		//wait
		m_timer -=Time.deltaTime;
		if(m_timer > 0)
			return;

		if(GameManager.Instance.m_wave < data.wave)
		{
			//increase the wave
			GameManager.Instance.SetWave(data.wave);
		}

		//search the enemies
		Transform enemyprefab = FindEnemy(data.enemyname);


		//create the enemy
		Debug.Log("yyyyyyyyyyyyyyyyyyyyy");
		if(enemyprefab !=null)
		{

			Debug.Log("xxxxxxxxxxxxxxxxxxxxxx");
			Transform trans = (Transform)Instantiate(enemyprefab,this.transform.position,Quaternion.identity);
			Enemy enemy = trans.GetComponent<Enemy>();

			//set the starting node
			enemy.m_currentNode = m_startNode;

			//set the born point
			enemy.m_spawn = this;

			//set the init rotation
			enemy.transform.LookAt(m_startNode.transform);
			float ry = enemy.transform.eulerAngles.y;
			enemy.transform.eulerAngles = new Vector3(0,ry,0);
		}

		//next
		m_index ++;
		if(m_index >= m_enemyList.Count)
			return;

		//get the data of the next enemy
		SpawnData nextdata = (SpawnData)m_enemyList[m_index];

		//the cost time of  create next enemy
		m_timer = data.wait;
	}

	//search the enemy prefab in the enemytable
	Transform FindEnemy(string enemyname)
	{
		foreach(EnemyTable enemy in m_enemies)
		{
			if(enemy.enemyName.CompareTo(enemyname) == 0)
			{
				return enemy.enemyPrefab;
			}
		}
		return null;
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position,"spawner.tif");
	}
}

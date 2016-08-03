using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	//waves are not displayed in the inspector windows
[HideInInspector]
	public int m_wave = 1;

	//life
	public int m_life;

	//point
	public int m_point;

	//text
	GUIText m_txt_wave;
	GUIText m_txt_life;
	GUIText m_txt_point;

	public bool m_debug =false;
	public ArrayList m_PathNodes;

	//an arraylist to save all the enemies
	public ArrayList m_EnemyList = new ArrayList();

	//button
	GUIButton m_button;
	//the ID which is select
	int m_ID;
	//defend prefab
	public Transform m_guardPrefab;

	//colission layer
	public LayerMask m_groundlayer;

	void Awake()
	{
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		m_button = this.transform.FindChild("button_0").GetComponent<GUIButton>();

		//catch the text
		m_txt_wave = this.transform.FindChild("txt_wave").GetComponent<GUIText>();
		m_txt_life = this.transform.FindChild("txt_life").GetComponent<GUIText>();
		m_txt_point = this.transform.FindChild("txt_point").GetComponent<GUIText>();

		//init the word
		m_txt_wave.text = "<color=red>wave</color> "+m_wave;
		m_txt_life.text = "<color=red>life</color> "+m_life;
		m_txt_point.text = "<color=red>point</color> "+m_point;
	}
	
	// Update is called once per frame
	void Update () {
     	//if life is over
		if(m_life <= 0)
			return;

		//press the mouse
		bool press = Input.GetMouseButton(0);

		//loosen the mouse
		bool mouseup = Input.GetMouseButtonUp(0);

		//get the mouse position
		Vector3 mousepos = Input.mousePosition;

		//get mouse moving diatance
		float mx =Input.GetAxis("Mouse X");
		float my =Input.GetAxis("Mouse Y");

		//if the ID is larger than 0,and the mouse has been loosen
		if(m_ID > 0&& mouseup)
		{
			//if the point is less than 5, do nothing
			if(m_point < 5)
			{
				m_ID = 0;

				m_button.SetOnActiv(false);
				return;
			}

			Ray ray = Camera.main.ScreenPointToRay(mousepos);

			//calculate the collison to the ground
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,100,m_groundlayer))
			{
				//get the crash position
				int ix = (int)hit.point.x;
				int iz = (int)hit.point.z;

				if(ix>= GridMap.Instance.MapSizeX || iz >= GridMap.Instance.MapSizeZ || ix<0 ||iz<0)
					return;

				//if the grid can put the defender
				if(GridMap.Instance.m_map[ix,iz].fieldtype == MapData.FieldTypeID.GuardPosition)
				{
					Vector3 pos = new Vector3((int)hit.point.x + 0.5f,0,(int)hit.point.z+0.5f);
					//create the defender
					Instantiate(m_guardPrefab,pos,Quaternion.identity);
					m_ID = 0;

					//the button turn to normol
					m_button.SetOnActiv(false);

					//descrease 5 point
					SetPoint(-5);

				}
			}
		}

		//get the button ID
		int id =m_button.UpdateState(mouseup,Input.mousePosition);
		if(id>0)
		{
			m_ID = id;
			//activitive the button, can create the defender now
			m_button.SetOnActiv(true);
			return;
		}

		//move the camera
		GameCamera.Inst.Control(press,mx,my);
	}

	//update waves
	public void SetWave(int wave)
	{
		m_wave= wave;
		m_txt_wave.text = "<color=red>wave</color> " + m_wave;
	}

	//update life
	public void SetDamage(int damage)
	{
		m_life -= damage;
		m_txt_life.text = "<color=red>life</color> " + m_life;
	}

	//update point
	public void SetPoint(int point)
	{
		m_point += point;
		m_txt_point.text = "<color=red>point</color> " + m_point;
	}

	[ContextMenu("BuildPath")]
	void BuildPath()
	{
		m_PathNodes = new ArrayList();

		GameObject[] objs = GameObject.FindGameObjectsWithTag("pathnode");

		for(int i = 0; i < objs.Length; i++)
		{
			PathNode node = objs[i].GetComponent<PathNode>();

			m_PathNodes.Add(node);
		}
	}

	void OnGUI()
	{
		if (m_life <= 0 || ( m_wave == 10 && m_EnemyList.Count==0))
		{
			if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.5f - 25, 200, 50), "REPLAY"))
				Application.LoadLevel(Application.loadedLevelName);
		}
	}

	void OnDrawGizmos()
	{
		if(!m_debug || m_PathNodes == null)
			return;

		Gizmos.color = Color.blue;

		foreach(PathNode node in m_PathNodes)
		{
			if(node.m_next !=null)
			{
				Gizmos.DrawLine(node.transform.position,node.m_next.transform.position);
			}
		}
	}
}

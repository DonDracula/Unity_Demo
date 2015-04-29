using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public int m_score = 0;
	public static int m_hiscore = 0;
	protected Player m_player;
	public AudioClip m_musicClip;
	public AudioSource m_Audio;

	public GameObject Enemy_Spawn01;
	public GameObject Enemy_Spawn_Boss;

	// Use this for initialization
	void Awake(){
		Instance = this;
	}

	void Start () {
		m_Audio = this.audio;

		GameObject obj = GameObject.FindGameObjectWithTag("Player");
		if(obj != null)
		{
			m_player = obj.GetComponent<Player>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!m_Audio.isPlaying)
		{
			m_Audio.clip = m_musicClip;
			m_Audio.Play();
		}

		if(Time.deltaTime > 0&&Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0;
		}

		if(m_score >200)
		{
			Enemy_Spawn01.SetActive(false);
			Enemy_Spawn_Boss.SetActive(true);
		}
		else if(m_score > 10)
		{
			Enemy_Spawn01.SetActive(true);
		}

	}

	void OnGUI(){
		GUI.color = Color.blue;

		if(Time.timeScale == 0)
		{
			if(GUI.Button(new Rect(Screen.width * 0.5f -50, Screen.height * 0.4f,100,30),"Continue"))
			{
				Time.timeScale = 1;
			}

			if(GUI.Button(new Rect(Screen.width * 0.5f - 50,Screen.height * 0.6f,100,30),"Quit"))
			{
				Application.Quit();
			}
		}

		int life = 0;
		if(m_player !=null)
		{
			life = (int)m_player.m_life;
		}
		else 
		{
			GUI.skin.label.fontSize = 50;

			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label(new Rect(0,Screen.height * 0.2f,Screen.width,60),"Game Over");
			GUI.skin.label.fontSize =20;
			if(GUI.Button(new Rect(Screen.width * 0.5f -50 ,Screen.height * 0.5f,100,30),"Again"))
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
		}

		GUI.skin.label.fontSize = 15;

		GUI.Label(new Rect(5,5,100,30),"Armor : "+life);

		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label(new Rect(0,5,Screen.width,30),"Record : "+m_hiscore);

		GUI.Label(new Rect(0,25,Screen.width,30),"Score : "+m_score);
	}

	public void AddScore(int point){
		m_score += point;

		if(m_hiscore < m_score)
			m_hiscore = m_score;
	}
}

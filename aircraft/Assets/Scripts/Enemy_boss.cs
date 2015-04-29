using UnityEngine;
using System.Collections;

public class Enemy_boss : MonoBehaviour {

	
	public float m_speed = 1;
	public float m_movSpeed = 1;
	public float m_life = 10;
	public Transform m_rocket;
	
	public AudioClip m_shootClip;
	protected AudioSource m_audio;
	public Transform m_explosionFX;
	public int m_point = 10;
	
	protected float m_timer = 1.5f;
	protected Transform m_transform;
	float angle;
	
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();
	}
		protected float m_fireTimer =2;
		protected Transform m_player;
		
		void Awake()
		{
			GameObject obj= GameObject.FindGameObjectWithTag("Player");
			Debug.Log(obj);
			if(obj != null)
			{
				m_player = obj.transform;
			}
		}
		
		protected void UpdateMove()
		{
			
			m_fireTimer -= Time.deltaTime;
			if(m_fireTimer <=0)
			{
				m_fireTimer = 1;
				if(m_player!= null)
				{
					Vector3 relativePos = m_transform.position -  m_player.position;
					Debug.Log(" 1245567"+relativePos);

				Vector3 left = new Vector3(m_transform.position.x-0.4f,m_transform.position.y-0.2f,m_transform.position.z);
				Vector3 right = new Vector3(m_transform.position.x+0.4f,m_transform.position.y-0.2f,m_transform.position.z);
					
				angle =angle_360(m_player.position,m_transform.position);

				m_audio.PlayOneShot(m_shootClip);
				//Instantiate(m_rocket,left,Quaternion.FromToRotation(m_player.position,m_transform.position));
				//Instantiate(m_rocket,right,Quaternion.FromToRotation(m_player.position,m_transform.position));
				Transform obj1 = (Transform)Instantiate(m_rocket,left,Quaternion.identity);
				obj1.eulerAngles = new Vector3(0,0,angle);
				Transform obj2 = (Transform)Instantiate(m_rocket,right,Quaternion.identity);
				obj2.eulerAngles = new Vector3(0,0,angle);
				}
			}
			
			m_transform.Translate(new Vector2(0,-m_speed*Time.deltaTime));
		}

	float angle_360(Vector3 from_, Vector3 to_)
	{
		Vector3 v3 = Vector3.Cross(from_,to_);  
		if(v3.z > 0)
			return Vector3.Angle(from_,to_);  
		else  
			return 360-Vector3.Angle(from_,to_);  
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.CompareTo("PlayerRocket") == 0)
		{
			Rocket rocket = other.GetComponent<Rocket>();
			if(rocket != null)
			{
				m_life -=rocket.m_power;
				
				if(m_life <=0)
				{	
					GameManager.Instance.AddScore(m_point);
					 Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
					Destroy(this.gameObject);
				}
			}
			
		}
		else if(other.tag.CompareTo("Player") == 0)
		{
			
			m_life = 0;
			Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
		else if(other.tag.CompareTo("Bound") == 0)
		{
			m_life =  0;
			Destroy(this.gameObject);
		}
		
		
		
	}
}
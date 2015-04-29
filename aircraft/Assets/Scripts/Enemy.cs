using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();
	}

	protected virtual void UpdateMove()
	{
		m_timer -= Time.deltaTime;
		if(m_timer <=0)
		{
			m_timer = 2.0f;
			m_movSpeed = -m_movSpeed;

			Instantiate(m_rocket,m_transform.position,Quaternion.identity);
			m_audio.PlayOneShot(m_shootClip);
		}
		
		m_transform.Translate(new Vector2(m_movSpeed,-m_speed*Time.deltaTime));
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

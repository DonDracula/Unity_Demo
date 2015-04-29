using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	protected Transform m_transform;
	public float m_speed = 1;
	public float m_rocketRate = 0;
	public float m_life =3;

	public AudioClip m_shootClip;
	protected AudioSource m_audio;
	public Transform m_explosionFX;

	public Transform m_rocket;
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
	

		float movey = 0;
		float movex = 0;

		if(Input.GetKey(KeyCode.W))
		{
			movey += m_speed * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.S))
		{
			movey -= m_speed * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.A))
		{
			movex -= m_speed * Time.deltaTime;
		}

		if(Input.GetKey(KeyCode.D))
		{
			movex += m_speed * Time.deltaTime;
		}

		m_rocketRate -=Time.deltaTime;
		if(m_rocketRate < 0)
		{
			m_rocketRate = 0.1f;

			if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))
			{
				Instantiate(m_rocket,m_transform.position,m_transform.rotation);

				m_audio.PlayOneShot(m_shootClip);
			}
		}
			
		this.m_transform.Translate(new Vector2(movex,movey));
	}

	void OnTriggerEnter (Collider  other)
	{
		if(other.tag.CompareTo("PlayerRocket")!=0)
		{
			m_life -= 1;
			if(m_life <= 0)
			{
				Instantiate(m_explosionFX,m_transform.position,Quaternion.identity);
				Destroy(this.gameObject);

			}
		}
	}
}

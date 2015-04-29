using UnityEngine;
using System.Collections;

public class Enemy02 :Enemy {

	protected float m_fireTimer =2;
	protected Transform m_player;
	float angle;

	void Awake()
	{
		GameObject obj= GameObject.FindGameObjectWithTag("Player");
		Debug.Log(obj);
		if(obj != null)
		{
			m_player = obj.transform;
		}
	}

	protected override void UpdateMove()
	{

		m_fireTimer -= Time.deltaTime;
		if(m_fireTimer <=0)
		{
			m_fireTimer = 1;
			if(m_player!= null)
			{
				Vector3 relativePos = m_transform.position -  m_player.position;
				Debug.Log(" 1245567"+relativePos);

				//angle =angle_360(m_transform.position,m_player.position);
				angle =angle_360(m_player.position,m_transform.position);

				m_audio.PlayOneShot(m_shootClip);
			//	Instantiate(m_rocket,m_transform.up,Quaternion.LookRotation(relativePos,Vector3.forward));
			//	Instantiate(m_rocket,m_transform.position,Quaternion.FromToRotation(m_transform.position,m_player.position));
				Transform obj = (Transform)Instantiate(m_rocket,m_transform.position,Quaternion.identity);
				obj.eulerAngles = new Vector3(0,0,angle);
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
}

using UnityEngine;
using System.Collections;

public class pzAudio : MonoBehaviour {

	void OnCollisionEnter (Collision collisionInfo)//如果发生碰撞 
	{
		if(PlayerPrefs.GetInt("set2")==1)//如果音效开启
		{
			print("kkkk");
			audio.Play();//播放音效
		}
	}
}

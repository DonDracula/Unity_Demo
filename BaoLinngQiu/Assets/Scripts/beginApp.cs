using UnityEngine;
using System.Collections;

public class beginApp : MonoBehaviour {
	public int playFlag=1;
	// Use this for initialization
	void Start () {
		playFlag=PlayerPrefs.GetInt("set1");//取得上一次设置的声音设置
		if(playFlag==1)
		{
			audio.Play();
		}
	}
	

	void Awake()
	{
		//设置该游戏对象在加载其他level时不销毁  这里使得全局音乐成为可能
		DontDestroyOnLoad (transform.gameObject);
	}
	void Update()
	{
		playFlag=PlayerPrefs.GetInt("set1");
		if(playFlag==0)
		{
			audio.Pause();
		}
	}
}

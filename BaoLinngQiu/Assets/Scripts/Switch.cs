using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public Texture backTexture;//背景图片
	public Texture ChooseYourSceneTexture;
	public Texture ChooseYourBallTexture;
	public GUIStyle MyStyle;//绘制样式
	public Texture PlayNowTexture;//开始游戏按钮图片
	public Texture LeaderBoardTexture;
	public Texture SettingsTexture;//设置按钮图片
	public Texture StatisticsTexture;//统计按钮图片
	//纹理图片                 
	private Texture wenliTexture; private Texture wenli1Texture; private Texture wenli2Texture;
	private Texture wenli3Texture; private Texture wenli4Texture;
	public AudioSource beijingyinyue;//背景音乐
	public Rigidbody ball;//刚体球
	static int set3=0;
	// Use this for initialization
	void Start () {
		set3=PlayerPrefs.GetInt("set3");
	}
	
	// Update is called once per frame
	void OnGUI () {
	
		int curHeight=Screen.height;
		float curWidth=Screen.height*shezhi.cellWidth/shezhi.cellHeight;
		float scaleM=(Screen.width-curWidth)/2;  //求得显示的边界空间

		if (GUI.Button(new Rect((40+scaleM),500,60,60),PlayNowTexture,MyStyle))//按钮纹理和样式
		{
			if(set3==1)//如果游戏模式为触控模式则加载触控模式游戏场景
			{
				Application.LoadLevel("ball");
			}else
			{
//				Application.LoadLevel("ball1");
			}
			Destroy(this);//销毁节约资源
		}
		if (GUI.Button(new Rect((120+scaleM),500,60,60),SettingsTexture,MyStyle))//按钮纹理和样式
		{
			Application.LoadLevel("settings");//点击设置按钮进入设置场景
			Destroy(this);//销毁节约资源
		}
		if (GUI.Button(new Rect((200+scaleM),500,60,60),StatisticsTexture,MyStyle))//按钮纹理和样式
		{
			Application.LoadLevel("records");//点击设统计钮进入统计场景
			Destroy(this);//销毁节约资源
		}
		if (GUI.Button(new Rect((280+scaleM),500,60,60),LeaderBoardTexture,MyStyle))//按钮纹理和样式
		{
			Application.LoadLevel("help"); //点击帮助按钮进入帮助场景	
			Destroy(this);//销毁节约资源
		} 
	}
}

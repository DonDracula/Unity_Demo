using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

	//present life
	public float m_currentLife = 1.0f;

	//max life
	public float m_maxLife = 1.0f;

	internal Transform m_transform;

	//horizontal scale bar
	float m_hscale =1.0f;

	//vertical scale the bar
	float m_vscale = 1.0f;

	Mesh m_mesh;
	Transform m_cameraTransform;

	//a vector2 to save UV
	Vector2[] m_Uvs;
	//initialization 
	public void Ini(float currentLife,float maxlife,float hscale, float vscale)
	{
		m_transform = this.transform;
		m_cameraTransform = Camera.main.transform;

		m_hscale = hscale;
		m_vscale = vscale;
		m_transform.localScale = new Vector3(hscale,vscale,1.0f);

		//get the mesh component
		m_mesh = (Mesh)this.GetComponent<MeshFilter>().mesh;

		//get the mesh points
		Vector3[] vertices = m_mesh.vertices;

		//get all the UV
		m_Uvs = new Vector2[vertices.Length];
		for(int i =0; i<vertices.Length; i++)
		{
			m_Uvs[i] = m_mesh.uv[i];
		}

		//update the life bar
		UpdateLife(currentLife,maxlife);
	}

 	//move the lifebar UV
	void Pad(float value)
	{
		float left = (1.0f - value)/2+0.01f;
		float right = 0.5f + (1.0f -value)/2-0.01f;

		//0== lower left,1==lower right,2==upper right,3==upper left
		m_Uvs[0]= new Vector2(left,0.0f);
		m_Uvs[3] = new Vector2(left,1.0f);

		m_Uvs[1] = new Vector2(right,0.0f);
		m_Uvs[2] = new Vector2(right,1.0f);

		m_mesh.uv = m_Uvs;
	}
	
	// Update the Uv according to the life value
	public void UpdateLife (float currentlife,float maxlife)
	{
		if(m_maxLife == 0)
			return;
		m_currentLife = currentlife;
		m_maxLife = maxlife;
		this.Pad(currentlife/maxlife);

		m_transform.localScale = new Vector3(m_hscale,m_vscale,1.0f);
	}

	//regulate the position and rotation of the life bar
	public void SetPosition(Vector3 position, float yoffset)
	{
		//get the enemy's position
		Vector3 vec = position;
		//upper shift
		vec.y += yoffset;
		m_transform.position = vec;

		//keep the life bar towards to the camera
		Vector3 rot = new Vector3();
		rot.y = m_cameraTransform.eulerAngles.y;
		rot.x = m_cameraTransform.eulerAngles.x;
		m_transform.eulerAngles = rot;
	}
}

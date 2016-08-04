using UnityEngine;
using System.Collections;

public class CarRotate : MonoBehaviour {
	
	private GameObject ScreenCarType;
	
		Vector3 StartPosition;  
		Vector3 previousPosition;  
		Vector3 offset;  
		Vector3 finalOffset;  
		Vector3 eulerAngle;  

		int direction; 
		
		bool isSlide;  
		float angle;  

	 bool turn;
		
		void Start()  
		{  
			ScreenCarType = this.GetComponent<GameManager>().SeletedCarInScene;
			//camera = GameObject.Find("Main Camera");
		//	screenCarType_name = this.GetComponent<SmoothLookAt>().target.name;
		
//			target = GameObject.FindGameObjectWithTag(screenCarType_name);
		}  
		
		
		void Update()  
		{  
			ScreenCarType = this.GetComponent<GameManager>().SeletedCarInScene;
			if (Input.GetMouseButtonDown(0))  
			{  
				StartPosition = Input.mousePosition;  
				previousPosition = Input.mousePosition;  
			}  
			if (Input.GetMouseButton(0))  
			{  
				offset = Input.mousePosition - previousPosition;  
				previousPosition = Input.mousePosition;  
			if(offset.x<0)
			{
				turn = true;
				ScreenCarType.transform.Rotate(Vector3.up, offset.magnitude/2, Space.World); 
			}
			else if(offset.x>0)
			{
				turn = false;
				ScreenCarType.transform.Rotate(Vector3.up, -1*offset.magnitude/2, Space.World);
			}

			//围绕世界坐标原点，每秒20度物体自旋
		//	transform.RotateAround (center, Vector3.up, Vector3.Cross(offset, Vector3.forward).normalized);
				
				
				
			}  
			if (Input.GetMouseButtonUp(0))  
			{  
				finalOffset = Input.mousePosition - StartPosition;  
				isSlide = true;  

				if( finalOffset.x >0)
					direction = -1;
				else
					direction = 1;

				angle = finalOffset.magnitude;  
				
				
			}  
			if (isSlide)  
			{  
				//if(turn = true)
				ScreenCarType.transform.Rotate(Vector3.up, direction*angle * 1* Time.deltaTime, Space.World);  
				//else
					//transform.Rotate(Vector3.up, -1*angle * 2 * Time.deltaTime, Space.World);  
			//transform.RotateAround (center, Vector3.up, Vector3.Cross(finalOffset, Vector3.forward).normalized);
				if (angle > 0)  
				{  
					angle -= 5;  
				}  

				else
				{
					angle = 0;  
				}
			} 

		}  
	}  
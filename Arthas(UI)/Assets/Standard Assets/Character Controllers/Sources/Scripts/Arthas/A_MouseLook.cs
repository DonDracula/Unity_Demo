    using UnityEngine;
    using System.Collections;

    [AddComponentMenu("Camera-Control/Mouse Look")]
    public class A_MouseLook : MonoBehaviour {

            public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
            public RotationAxes axes = RotationAxes.MouseXAndY;
            public float sensitivityX = 15F;
            public float sensitivityY = 15F;

            public float minimumX = -360F;
            public float maximumX = 360F;

            public float minimumY = -85F;
            public float maximumY = 4F;

            public float rotationY = 0F;
           
            public GameObject target;
           
            public float theDistance = -10f;
            public float MaxDistance = -10f;
            public float ScrollKeySpeed = 100.0f;
            void Update ()
            {
                 target = GameObject.Find("3rd Person Controller");
                     // 滚轮设置 相机与人物的距离.  
                 if(Input.GetAxis("Mouse ScrollWheel") != 0)
                 {
                      theDistance = theDistance + Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ScrollKeySpeed;      
                 }
                 // 鼠标中间滚动得到的值是不确定的,不会正好就是0,或 -10,当大于0时就设距离为0,小于MaxDistance就设置为MaxDistance
                 if(theDistance>0)
                      theDistance = 0;
                 if(theDistance < MaxDistance)
                      theDistance = MaxDistance;
                    if(Input.GetMouseButton(1))
                    {
                            transform.position = target.transform.position;
                            if (axes == RotationAxes.MouseXAndY)
                            {
                                    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                                   
                                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                                    rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
                                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                            }
                            else if (axes == RotationAxes.MouseX)
                            {
                                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                            }
                            else if (axes == RotationAxes.MouseY)
                            {
									//transform.Rotate(0, 0, Input.GetAxis("Mouse Y")*sensitivityY);
                                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                                    rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
                                    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                            }
		              SetDistance();
                    }
                    else
                {
                    		transform.position = target.transform.position;
                           	SetDistance();
                }
            }
           
            void Start ()
            {
                    if (GetComponent<Rigidbody>())
                    {
                            GetComponent<Rigidbody>().freezeRotation = true;
                            transform.position = target.transform.position;
                    }
            }
           
            //设置相机与人物之间的距离
            void SetDistance()
            {
            	transform.Translate(Vector3.forward * theDistance);
				//transform.Translate(Vector3.down * theDistance);
				//transform.Trandslate(Vector3.);
            }
    }
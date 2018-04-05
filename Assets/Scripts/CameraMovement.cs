using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject cam;
	public Camera c;
	public float u = 0.33f;
	void Start(){
		 c = GetComponent<Camera>();
	}

	void Update(){
		//Res:640x480
		double x1 = Screen.width * 0.8;//512
		double x2 = Screen.width * 0.2;//128
		double y1 = Screen.height * 0.8;//384
		double y2 = Screen.height * 0.2;//96
		Vector3 m = Input.mousePosition;
		if(m.x <= x2){
			//cam.transform.position.x += 1;
			//Debug.Log("X Case-" + m.x + "less than" + x2 + "more than" + x1);
		//	cam.transform.LookAt(c.ScreenToWorldPoint(new Vector3(m.x,m.y,c.nearClipPlane)),Vector3.up);
			Transform t = cam.transform;
			float x = t.position.x;
			float y = t.position.y;
			t.SetPositionAndRotation(new Vector3(x-u,y,-1),Quaternion.identity);
		}
		if(m.x >= x1){
			Transform t = cam.transform;
			float x = t.position.x;
			float y = t.position.y;
			t.SetPositionAndRotation(new Vector3(x+u,y,-1),Quaternion.identity);
		}
		if (m.y <= y2) {
		//	//cam.transform.position.y += 1;
			//Debug.Log("Y Case-" + m.y + "less than" + y2 + "more than" + y1);
		//	cam.transform.LookAt(c.ScreenToWorldPoint(new Vector3(m.x,m.y,c.nearClipPlane)),Vector3.up);
			Transform t = cam.transform;
			float x = t.position.x;
			float y = t.position.y;
			t.SetPositionAndRotation(new Vector3(x,y-u,-1),Quaternion.identity);
		}
		if(m.y >= y1){
			Transform t = cam.transform;
			float x = t.position.x;
			float y = t.position.y;
			t.SetPositionAndRotation(new Vector3(x,y+u,-1),Quaternion.identity);
		}

	}
}

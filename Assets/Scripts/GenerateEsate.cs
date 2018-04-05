using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEsate : MonoBehaviour {
	public GameObject startPoint;
	public int offsetX = 0;
	public int offsetY = 5;
	public int flatCount = 5;
	public float gap = 1;
	public GameObject cloneObj;
	// Use this for initialization
	void Start () {
		for (int i = 1; i <= flatCount; i++) {
			float x = startPoint.transform.position.x + i * offsetX; //+ (i - 1) * gap;
			float y = startPoint.transform.position.y + i * offsetY + i * gap;
			Instantiate (cloneObj,new Vector3(x,y,0),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

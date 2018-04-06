using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {
	public GameObject panel;
	public Camera c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0)){
		//	Vector3 mp = c.ScreenToWorldPoint (Input.mousePosition);
		//	RectTransform r = panel.GetComponent<RectTransform> ();
		//	if(r.)
		//}
	}

	void enable(){
		panel.activeInHierarchy = true;
	}
		
}

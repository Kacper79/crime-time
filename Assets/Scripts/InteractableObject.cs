using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	public bool b = false;
	public GameObject panel;

	public void OnMouseDown(){
		if(b == false){
			GeneratePanelForBuilding (gameObject);
			DisplayPanel.enable(panel);
			b = true;
		}else{
			DisplayPanel.disable(panel);
			b = false;
		}

	}
	void GeneratePanelForBuilding(GameObject building){
		DisplayPanel.GeneratePanelForBuilding (building,panel);
		//panel.GetComponent<RectTransform> ().SetPositionAndRotation (building.GetComponent<RectTransform> ().position,Quaternion.identity);
		//building.GetComponent<RectTransform> ().SetPositionAndRotation (new Vector3(),Quaternion.identity);
	}
		
}

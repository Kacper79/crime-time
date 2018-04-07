using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
	public bool b = false;
	public static GameObject panel;

	public void OnPointerClick(){
		if(b == false){
			DisplayPanel.enable(panel);
			b = true;
		}else{
			DisplayPanel.disable(panel);
			b = false;
		}

	}
}

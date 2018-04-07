using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {

	public static void enable(GameObject panel){
		panel.SetActive (true);
	}
	public static void disable(GameObject panel){
		panel.SetActive (false);
	}
		
}

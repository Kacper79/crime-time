using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClose : MonoBehaviour {

	public GameObject closedObject;

	public void Close(){
		closedObject.SetActive (false);
	}
}

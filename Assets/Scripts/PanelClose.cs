using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClose : MonoBehaviour {

	public GameObject closedObject;
	Animation anim;
	public bool animating;

	public void Start(){
		anim = closedObject.GetComponent <Animation> ();
	}

	public void Close(){
		StartCoroutine (CloseAnimation ());
	}

	IEnumerator CloseAnimation(){
		animating = true;
		anim.Play ("panelTransition");
		yield return new WaitForSeconds(1);
		closedObject.SetActive (false);
		closedObject.GetComponent <RectTransform>().localScale = new Vector3(0.25f,0.25f,1f);
		animating = false;
		StopCoroutine (CloseAnimation ());
		yield return null;
	}
}

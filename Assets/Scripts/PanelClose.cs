using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelClose : MonoBehaviour
{

	public GameObject closedObject;
	Animation anim;
	public bool animating;
	Vector3 lastScale;


	public void Start()
	{
		//anim = closedObject.GetComponent<Animation>();
		//lastScale = closedObject.GetComponent<RectTransform>().localScale;
	}

	public void Close()
	{
		//StartCoroutine(CloseAnimation());
		Debug.Log("Close 1");
		Manager.Instance.state = GameState.Game;
		//UiManager.Instance.currentBuilding.GetComponent<InteractableObject>().b = false;
		UiManager.Instance.currentBuilding = null;
		closedObject.SetActive(false);
		Debug.Log("Close 2");


	}

	IEnumerator CloseAnimation()
	{
		animating = true;
		anim.Play("panelTransition");
		yield return new WaitForSeconds(1);
		closedObject.SetActive(false);
		closedObject.GetComponent<RectTransform>().localScale = lastScale;
		animating = false;
		StopCoroutine(CloseAnimation());
		yield return null;
	}
}

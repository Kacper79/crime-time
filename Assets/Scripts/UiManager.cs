using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour {

	FlatMechanics Building;
	public GameObject flatUI;

	public static UiManager Instance;

	void Start () {
		Instance = this;
	}
	
	
}
public enum BuildingType
{
	Flat,
	Bank
}

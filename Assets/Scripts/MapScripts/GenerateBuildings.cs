using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuildings : MonoBehaviour {

	public GameObject[] upBuildings;
	public GameObject[] sideBuildings;
	public float gap;
	public GameObject flat;
	public int flatRows;
	void Start () {
		//generate the top buildings
		for(int i = 0;i<upBuildings.Length;i++){
			Instantiate (upBuildings[i],new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+gap*(i+1),gameObject.transform.position.z),Quaternion.identity);
		}
		//generate the side buildings
		for(int i = 0;i<sideBuildings.Length;i++){
			Instantiate (sideBuildings[i],new Vector3(gameObject.transform.position.x+gap*(i+1),gameObject.transform.position.y,gameObject.transform.position.z),Quaternion.identity);
		}
		//generate internal flats
		for(int a = 1;a<=flatRows;a++){
			for(int i = 1;i<=sideBuildings.Length;i++){
				Instantiate (flat,new Vector3(gameObject.transform.position.x+gap*i,gameObject.transform.position.y+gap*a,gameObject.transform.position.z),Quaternion.identity);
			}
		}

	}
	

	void Update () {
		
	}
}

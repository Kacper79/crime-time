using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

	GameObject map;
	public int size;
	int mapSize;
	public GameObject road;
	public GameObject roadCross;
	public GameObject roadThree;
	public GameObject roadCorner;
	Vector3 origin;

	int hospitals;
	GameObject hospital;
	int banks;
	GameObject bank;
	int policeStations;
	GameObject police;
	int firefighters;
	GameObject fireStation;
	int hotels;
	GameObject hotel;
	int mails;
	GameObject mailPost;
	int mines;
	GameObject mine;
	int graveyards;
	GameObject grave;
	int farms;
	GameObject farm;

	int spots;


	void Start () {
		createRoads ();
		spots = size * 12 - 4;

	}
	
	void generateFour(int currentY){
		Instantiate (road,origin+ new Vector3(0,currentY,0),Quaternion.identity);
		Instantiate (road,origin+ new Vector3(size+1,currentY,0),Quaternion.identity);
		Instantiate (road,origin+ new Vector3(size*2+2,currentY,0),Quaternion.identity);
		Instantiate (road,origin+ new Vector3(size*3+3,currentY,0),Quaternion.identity);
	}

	void generateRow(int currentY){
		for(int i=0;i<mapSize;i++){
			if(i !=0 && i != mapSize-1 && i != size+1 && i != size*2+2){
				GameObject roadTransform = Instantiate (road,origin + new Vector3(i,currentY,0),Quaternion.identity) as GameObject;
				roadTransform.transform.Rotate (0,0,90);
			}
		}
	}

	void createRoads(){
		mapSize = size*3+4;
		Debug.Log (mapSize);
		map = gameObject;
		map.transform.localScale = new Vector3 (mapSize/2, mapSize/2,1);
		origin = transform.position - new Vector3 (mapSize / 2, mapSize / 2, 0);

		for(int i = 0; i < mapSize;i++){
			if(i == 0 || i == size+1 || i == size*2+2 || i == size*3+3){
				generateRow (i);
			}else{
				generateFour (i);
			}
		}
		GameObject roadTemp = Instantiate (roadCorner,origin,Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,-90);
		roadTemp = Instantiate (roadCorner,origin + new Vector3(mapSize-1,0,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,0);
		roadTemp = Instantiate (roadCorner,origin + new Vector3(mapSize-1,mapSize-1,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,90);
		roadTemp = Instantiate (roadCorner,origin + new Vector3(0,mapSize-1,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,180);

		Instantiate (roadCross,origin + new Vector3(size+1,size+1,0),Quaternion.identity);
		Instantiate (roadCross,origin + new Vector3(size*2+2,size+1,0),Quaternion.identity);
		Instantiate (roadCross,origin + new Vector3(size+1,size*2+2,0),Quaternion.identity);
		Instantiate (roadCross,origin + new Vector3(size*2+2,size*2+2,0),Quaternion.identity);

		roadTemp = Instantiate (roadThree,origin+ new Vector3(size+1,0,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,-90);
		roadTemp = Instantiate (roadThree,origin+ new Vector3(size*2+2,0,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,-90);

		roadTemp = Instantiate (roadThree,origin+ new Vector3(0,size+1,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,180);
		roadTemp = Instantiate (roadThree,origin+ new Vector3(0,size*2+2,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,180);

		Instantiate (roadThree,origin+ new Vector3(size*3+3,size+1,0),Quaternion.identity);
		Instantiate (roadThree,origin+ new Vector3(size*3+3,size*2+2,0),Quaternion.identity);

		roadTemp = Instantiate (roadThree,origin+ new Vector3(size+1,size*3+3,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,90);
		roadTemp = Instantiate (roadThree,origin+ new Vector3(size*2+2,size*3+3,0),Quaternion.identity) as GameObject;
		roadTemp.transform.Rotate (0,0,90);
	}
}

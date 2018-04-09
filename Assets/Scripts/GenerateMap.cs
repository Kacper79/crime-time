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

	public int hospitals;
	public GameObject hospital;

	public int banks;
	public GameObject bank;

	public int policeStations;
	public GameObject police;

	public int firefighters;
	public GameObject fireStation;

	public int hotels;
	public GameObject hotel;

	public int mails;
	public GameObject mailPost;

	public int mines;
	public GameObject mine;

	public int graveyards;
	public GameObject grave;

	public int farms;
	public GameObject farm;

	public GameObject flat;

	public int spots;


	void Start () {
		createRoads ();
		spots = size * 12 - 4;
		GenerateCorner (origin+new Vector3(size*2+3,size*2+3,0),1,1);
		GenerateCorner (origin+new Vector3(size*2+3,size,0),1,-1);
		GenerateCorner (origin+new Vector3(size,size*2+3,0),-1,1);
		GenerateCorner (origin+new Vector3(size,size,0),-1,-1);
		GenerateMiddle (origin + new Vector3(size*2+3,size+2,0),0,1,1,1);
		GenerateMiddle (origin + new Vector3(size*2+1,size*2+3,0),-1,0,1,1);
		//GenerateMiddle (origin + new Vector3(size,size*2+1,0),0,-1);
		//GenerateMiddle (origin + new Vector3(size*2+1,size,0),-1,0);
	}

	GameObject selectBuilding(){
		while(true){
			int a = UnityEngine.Random.Range (1,9);
			if(a == 1 && hospitals>0){
				hospitals--;
				return hospital;
			}else if(a == 2 && banks>0){
				banks--;
				return bank;
			}else if(a == 3 && policeStations>0){
				policeStations--;
				return police;
			}else if(a == 4 && firefighters>0){
				firefighters--;
				return fireStation;
			}else if(a == 5 && hotels>0){
				hotels--;
				return hotel;
			}else if(a == 6 && mails>0){
				mails--;
				return mailPost;
			}else if(a == 7 && mines>0){
				mines--;
				return mine;
			}else if(a == 8 && graveyards>0){
				graveyards--;
				return grave;
			}else if(a == 9 && farms>0){
				farms--;
				return farm;
			}
		}
	}

	void GenerateMiddle(Vector3 buildingOrigin, int modifierX, int modifierY,int flatX, int flatY){
		for(int i = 0;i<size;i++){
			Instantiate (selectBuilding (),buildingOrigin+new Vector3(i*modifierX,i*modifierY,0),Quaternion.identity);

		}

		/*for(int a = 1;a<size;a++){
			for(int i = 1;i<=size;i++){
				Instantiate (flat,buildingOrigin+new Vector3(a*flatX,i*flatY,0),Quaternion.identity);
			}

		}*/
		for(int i= 0;i<size;i++){
				for(int a = 1;a<size;a++){
					Instantiate (flat,buildingOrigin+ new Vector3(a*flatX,i*flatY,0),Quaternion.identity);
				}
			
		}
	}

	void GenerateCorner(Vector3 buildingOrigin, int modifierX, int modifierY){
		for(int i= 0;i<size;i++){
			Instantiate (selectBuilding(),buildingOrigin+new Vector3 (i*modifierX,0,0),Quaternion.identity);
			if(i>0){
				for(int a = 1;a<size;a++){
					Instantiate (flat,buildingOrigin+ new Vector3(a*modifierX,i*modifierY,0),Quaternion.identity);
				}
			}
		}
		for(int i= 1;i<size;i++){
			Instantiate (selectBuilding(),buildingOrigin+new Vector3 (0,i*modifierY,0),Quaternion.identity);
		}
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

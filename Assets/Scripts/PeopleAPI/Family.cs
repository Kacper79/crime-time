using System;
using System.Collections.Generic;
using UnityEngine;
public class Family : MonoBehaviour
{
	public Dictionary<int,KeyValuePair<int,People>> generations;
	public PeopleCreator creator;
	public System.Random random = new System.Random();
	public int[] keyCount;
	public void GenerateFamily(){
		//Generate 1st Generation- 4 main persons
		People grandmotherof = creator.GeneratePersonalInfo();
		People grandfatherof = creator.GeneratePersonalInfo();
		People grandmotherom = creator.GeneratePersonalInfo();
        People grandfatherom = creator.GeneratePersonalInfo();
		People mother = creator.GeneratePersonalInfo();
		People father = creator.GeneratePersonalInfo();
		People son = creator.GeneratePersonalInfo();
		People daughter = creator.GeneratePersonalInfo();
		grandmotherom.gender = 1;
		grandmotherof.gender = 1;
		grandfatherom.gender = 0;
		grandfatherof.gender = 0;
		father.gender = 0;
		mother.gender = 1;
		son.gender = 0;
		daughter.gender = 1;
		int tempID = 0;
        //Some kind of loop wou
		generations[1] = new KeyValuePair<int,People>(tempID,grandfatherof);
		grandfatherof.whoInFamilyGeneration = tempID;
		tempID++;
		generations[1] = new KeyValuePair<int, People>(tempID, grandmotherof);
		grandmotherof.whoInFamilyGeneration = tempID;
        tempID++;
		generations[1] = new KeyValuePair<int, People>(tempID, grandfatherom);
		grandfatherom.whoInFamilyGeneration = tempID;
        tempID++;
		generations[1] = new KeyValuePair<int, People>(tempID, grandmotherom);
		grandmotherom.whoInFamilyGeneration = tempID;
		keyCount[1] = tempID;
		tempID = 0;
		generations[2] = new KeyValuePair<int, People>(tempID, father);
		father.whoInFamilyGeneration = tempID;
        tempID++;
		generations[2] = new KeyValuePair<int, People>(tempID, mother);
		mother.whoInFamilyGeneration = tempID;
		keyCount[2] = tempID;
		tempID = 0;
		generations[3] = new KeyValuePair<int, People>(tempID, son);
		son.whoInFamilyGeneration = tempID;
        tempID++;
		generations[3] = new KeyValuePair<int, People>(tempID, daughter);
		daughter.whoInFamilyGeneration = tempID;
		keyCount[3] = tempID;
		//Generate more people if family is wealthy;
	}
	public void ExecuteTestament(People deadperson){
		
		if(generations.ContainsValue(new KeyValuePair<int,People>(deadperson.whoInFamilyGeneration, deadperson))){
			People[] takers = new People[4];
			int tempID = 0;

		}
		//if(thirdGeneration.Contains(deadperson)){
		//	People[] takers = new People[4];
		//	int tmpID = 0;
		//	for (int i = 0; i < secondGeneration.Capacity;i++){
		//		if (secondGeneration[i].wasCriminalAlready == false)
  //              {
		//			takers[tmpID] = secondGeneration[i];
  //                  tmpID++;
  //              }
		//	}
		//	if(tmpID==0){
		//		for (int i=0;i < firstGeneration.Capacity;i++){
		//			if(firstGeneration[i].wasCriminalAlready == false){
		//				takers[tmpID] = firstGeneration[i];
  //                      tmpID++;
		//			}
		//		}
		//	}
		//	if(tmpID==0){
		//		//Money goes to country;
		//	}
		//	float percent = 1 / takers.Length;
  //          //Konkretne przelewy
		//}
		//if(secondGeneration.Contains(deadperson)){
		//	People[] takers = new People[4];
  //          int tmpID = 0;
		//	for (int i = 0; i < firstGeneration.Capacity; i++)
  //          {
  //              if (firstGeneration[i].wasCriminalAlready == false)
  //              {
  //                  takers[tmpID] = firstGeneration[i];
  //                  tmpID++;
  //              }
  //          }
		//}
		//if(firstGeneration.Contains(deadperson)){
		//	People[] takers = new People[4];
  //          int tmpID = 0;
  //          for (int i = 1; i < firstGeneration.Capacity; i++)
  //          {
  //              if (firstGeneration[i].wasCriminalAlready == false)
  //              {
  //                  takers[tmpID] = firstGeneration[i];
  //                  tmpID++;
  //              }
  //          }
		//}
	}
}


using System;
using System.Collections.Generic;
using UnityEngine;
public class Family : MonoBehaviour
{
	public List<PeopleRegister> firstGeneration;
	public List<PeopleRegister> secondGeneration;
	public List<PeopleRegister> thirdGeneration;
	public PeopleCreator creator;
	public System.Random random = new System.Random();
	public void GenerateFamily(){
		//Generate 1st Generation- 4 main persons
		PeopleRegister grandmotherof = creator.GeneratePersonalInfo();
		PeopleRegister grandfatherof = creator.GeneratePersonalInfo();
		PeopleRegister grandmotherom = creator.GeneratePersonalInfo();
        PeopleRegister grandfatherom = creator.GeneratePersonalInfo();
		PeopleRegister mother = creator.GeneratePersonalInfo();
		PeopleRegister father = creator.GeneratePersonalInfo();
		PeopleRegister son = creator.GeneratePersonalInfo();
		PeopleRegister daughter = creator.GeneratePersonalInfo();
		grandmotherom.gender = 1;
		grandmotherof.gender = 1;
		grandfatherom.gender = 0;
		grandfatherof.gender = 0;
		father.gender = 0;
		mother.gender = 1;
		son.gender = 0;
		daughter.gender = 1;
		firstGeneration.Add(grandmotherom);
		firstGeneration.Add(grandmotherof);
		firstGeneration.Add(grandfatherof);
		firstGeneration.Add(grandfatherom);
		secondGeneration.Add(mother);
		secondGeneration.Add(father);
		thirdGeneration.Add(son);
		thirdGeneration.Add(daughter);
		//Generate more people if family is wealthy;
	}
	public void ExecuteTestament(PeopleRegister deadperson){
		if(thirdGeneration.Contains(deadperson)){
			PeopleRegister[] takers = new PeopleRegister[4];
			int tmpID = 0;
			for (int i = 0; i < secondGeneration.Capacity;i++){
				if (secondGeneration[i].wasCriminalAlready == false)
                {
					takers[tmpID] = secondGeneration[i];
                    tmpID++;
                }
			}
			if(tmpID==0){
				for (int i=0;i < firstGeneration.Capacity;i++){
					if(firstGeneration[i].wasCriminalAlready == false){
						takers[tmpID] = firstGeneration[i];
                        tmpID++;
					}
				}
			}
			if(tmpID==0){
				//Money goes to country;
			}
			float percent = 1 / takers.Length;
            //Konkretne przelewy
		}
		if(secondGeneration.Contains(deadperson)){
			PeopleRegister[] takers = new PeopleRegister[4];
            int tmpID = 0;
			for (int i = 0; i < firstGeneration.Capacity; i++)
            {
                if (firstGeneration[i].wasCriminalAlready == false)
                {
                    takers[tmpID] = firstGeneration[i];
                    tmpID++;
                }
            }
		}
		if(firstGeneration.Contains(deadperson)){
			PeopleRegister[] takers = new PeopleRegister[4];
            int tmpID = 0;
            for (int i = 1; i < firstGeneration.Capacity; i++)
            {
                if (firstGeneration[i].wasCriminalAlready == false)
                {
                    takers[tmpID] = firstGeneration[i];
                    tmpID++;
                }
            }
		}
	}
}


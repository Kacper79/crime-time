using System;
using System.Collections.Generic;
using UnityEngine;
public class Family : MonoBehaviour
{
	public List<People> firstGeneration;
	public List<People> secondGeneration;
	public List<People> thirdGeneration;
	public PeopleCreator creator;
	public System.Random random = new System.Random();
	public int[] keyCount;
	public Family continuationFamily;
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
		//Some kind of loop wou
		firstGeneration.Add(grandmotherof);
		firstGeneration.Add(grandfatherof);
		firstGeneration.Add(grandmotherom);
		firstGeneration.Add(grandfatherom);
		secondGeneration.Add(father);
		secondGeneration.Add(mother);
		thirdGeneration.Add(son);
		thirdGeneration.Add(daughter);
		//Generate more people if family is wealthy;
	}
	public void ExecuteTestament(People deadperson){
		People[] tmpl = new People[4];
		int tmpi = 0;
		if(firstGeneration.Contains(deadperson)){
			foreach(People p in secondGeneration){
				if(p.wasCriminalAlready==false){
					tmpl[tmpi] = p;
					tmpi++;
				}
			}
			if(tmpl[0] == null){
				foreach (People p1 in thirdGeneration)
                {
                    if (p1.wasCriminalAlready == false)
                    {
                        tmpl[tmpi] = p1;
                        tmpi++;
                    }
                }
				if (tmpl[0] == null)
                {
                    foreach (People p in firstGeneration)
                    {
                        if (p.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p;
                            tmpi++;
                        }
                    }
                    if (tmpl[0] == null)
                    {
                        //Transfer money to country
                    }
                }
			}

		}
		if(secondGeneration.Contains(deadperson)){
			foreach (People p in thirdGeneration)
            {
                if (p.wasCriminalAlready == false)
                {
                    tmpl[tmpi] = p;
                    tmpi++;
                }
				if(tmpl[0] == null){
					foreach (People p1 in secondGeneration)
                    {
                        if (p1.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p1;
                            tmpi++;
                        }
                    }
					if(tmpl[0] == null){
						foreach (People p2 in firstGeneration)
                        {
                            if (p2.wasCriminalAlready == false)
                            {
                                tmpl[tmpi] = p2;
                                tmpi++;
                            }
                        }
						if(tmpl[0] == null){
							//Transfer money to country
						}
					}
				}
            }
			if(thirdGeneration.Contains(deadperson)){
                    foreach (People p in thirdGeneration)
                    {
                        if (p.wasCriminalAlready == false)
                        {
                            tmpl[tmpi] = p;
                            tmpi++;
                        }
                    }
                    if (tmpl[0] == null)
                    {
					foreach (People p1 in secondGeneration)
                        {
                            if (p1.wasCriminalAlready == false)
                            {
                                tmpl[tmpi] = p1;
                                tmpi++;
                            }
                        }
					    if(tmpl[0] == null){
						    foreach(People p2 in firstGeneration){
							    if(p2.wasCriminalAlready==false){
								    tmpl[tmpi] = p2;
								    tmpi++;
							    }
						    }
						    if(tmpl[0] == null){
							    //Transfer money to country
						    }
					    }
                    }
                
			}
		}
		float percent = 1/tmpl.Length;
        //Transfer money and the assets to new owners

	}
}


﻿using System;
using UnityEngine;
public class WorkCreator : MonoBehaviour{

	public void foundBuisness(Person owner,String name,WorkType workType){//And Asset - HQ
		//Check if person have criminal history - decline/accept request
		if(owner.policecriminalhistory.Count==0){
			Work work = new Work(owner, workType,name);
		}
        //else Arrest/Decline
        
	}
}
 


using System;
using UnityEngine;
public class WorkCreator : MonoBehaviour{

	public void foundBuisness(People owner,String name,WorkType workType){//And Asset - HQ
		//Check if person have criminal history - decline/accept request
		if(owner.policecriminalhistory.Count==0){
			Work work = new Work(owner, workType);
            work.name = name;
		}
        //else Arrest/Decline
        
	}
}
 


using System.Collections.Generic;
using UnityEngine;
public class Work : MonoBehaviour{
	public List<People> workers;
	public People owner;
	public int incomeToWorkers;
	public WorkType type;
	public string name;
	public Work(People owner,WorkType type){
		this.owner = owner;
		this.type = type;
	}

	public void EmployPeople(People worker,int payment){
		workers.Add(worker);
		incomeToWorkers += payment;
	}
    
}
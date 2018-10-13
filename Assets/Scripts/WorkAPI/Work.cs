using System.Collections.Generic;
using UnityEngine;
public class Work : MonoBehaviour{
	public List<Person> workers;
	public Person owner;
	public int incomeToWorkers;
    public int[] monthPayment;
	public WorkType type;
	public string orgname;
	public Work(Person owner,WorkType type,string orgname){
		this.owner = owner;
		this.type = type;
		this.orgname = orgname;
	}

	public void EmployPerson(Person worker,int payment){
		workers.Add(worker);
		incomeToWorkers += payment;
	}
    
}
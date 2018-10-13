using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

	public static PlayerManager Instance;
	public List<WebJob> jobs;
	public int APRLimit = 2;
	public Dictionary<int,Action> actions;
	public int tempID = -1;
	public List<GameObject> playerassets;
    public Person player;
	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}
	public void AddAsset(GameObject asset){
		playerassets.Add(asset);
	}
	public void AddJob(WebJob job)
	{
		jobs.Add(job); 

	}

	public void RemoveJob(WebJob job)
	{
		//foreach (WebJob webjob in jobs)
		//{
		//if (webjob.id == job.id)
		//{
		jobs.Remove(job);
	}
	public void AddAction(Action a){
		actions.Add(a.id,a);
	}
	public void RemoveAction(Action a)
    {
        actions.Remove(a.id);
    }
	public Action GetAction(int id){
		Action action = actions[id];
		return action;
	}
	//}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFlat_Rent : Action
{
	public GameObject flat;
	public WebJob webJob;
	public int income;
	public bool sbPur = false;
	public AFlat_Rent(GameObject flat,WebJob webJob,int income){
		this.flat = flat;
		this.webJob = webJob;
		this.income = income;

	}

	public override bool checkd()
	{
		
		bool response;
		if (webJob.price >= Manager.Instance.cash)
		{

			if (PlayerManager.Instance.APRLimit != 0)
			{
				Manager.Instance.increaseCash(income);
				response = true;
			}
			else
			{
				response = false;
			}
		}
		else
		{
			response = false;
		}
		return response;
	}
    
	//public override void checki()
	//{
    //    throw new System.NotImplementedException();
	//}

	public override void done()
	{
		PlayerManager.Instance.APRLimit--;
		webJob.done = true;
	}

	public override void finish()
	{
		PlayerManager.Instance.RemoveJob(webJob);
	}
}

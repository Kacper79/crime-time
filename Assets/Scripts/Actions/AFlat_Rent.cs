using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFlat_Rent : Action
{
	public GameObject flat;
	public WebJob webJob;
	public int income;
	public int hoteldays;
	public int clientOpinion;
	public string bname;

	public static int priceUnit = 0;
	public static int dayIncreaseVal = 0;

	//public bool sbPur = false;
	public AFlat_Rent(GameObject flat,WebJob webJob){
		this.flat = flat;
		this.webJob = webJob;
		income = webJob.price;

	}

	public override bool checkd()
	{
		
		bool response;
		if (PlayerManager.Instance.APRLimit != 0)
        {
            Manager.Instance.increaseCash(income);
            response = true;
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

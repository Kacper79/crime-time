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
	//public string bname;
	public bool random = false;

	public static int priceUnit = 0;
	public static int dayIncreaseVal = 0;

	//public bool sbPur = false;
	public AFlat_Rent(GameObject flat,WebJob webJob){
		this.flat = flat;
		this.webJob = webJob;
		income = webJob.price;

	}
	public AFlat_Rent(WebJob webJob){
		this.webJob = webJob;
		random = true;
	}
	public override bool checkd()
	{
		
		bool response = false;
		if (PlayerManager.Instance.APRLimit != 0)
        {
			if(!random){
				FlatMechanics fmek = flat.GetComponent<FlatMechanics>();
				if(fmek.owned==true){
					if(fmek.roomNA<fmek.size*8){
						response = true;
						Manager.Instance.increaseCash(income);
					}
				}
			}else{
				List<GameObject> propositions = new List<GameObject>();
				foreach(GameObject g in PlayerManager.Instance.playerassets){
					if(g.GetComponent("FlatMechanics") as FlatMechanics != null){
						propositions.Add(g);
					}
				}
				GameObject target = null;
				for (int i = 0; i < propositions.Count;i++){
					target = propositions[i];
					if(target.GetComponent<FlatMechanics>().roomNA<target.GetComponent<FlatMechanics>().size*8){
						response = true;
						Manager.Instance.increaseCash(income);
						break;
					}
				}

			}
            //Manager.Instance.increaseCash(income);
            //response = true;
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

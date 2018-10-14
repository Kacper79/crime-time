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
	public bool payWithTax = false;

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
				if(fmek.owner==PlayerManager.Instance.player){
					if(fmek.roomNA<fmek.size*8){
						response = true;
                        //Manager.Instance.increaseCash(income);
                        //Check witch account
                        int stI = 0;
                        for(int i =0;i< webJob.client.bankAccounts.Length;i++)
                        {
                            if (webJob.client.bankAccounts[i].accountBlocked == true) {
                                stI++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        int stJ = 0;
                        for (int i = 0; i < fmek.owner.bankAccounts.Length; i++)
                        {
                            if (fmek.owner.bankAccounts[i].accountBlocked == true)
                            {
                                stJ++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        webJob.client.bankAccounts[stI].TransferMoneyWithoutTaxes(fmek.owner.bankAccounts[stJ], "AFR MTRANSFER FROM " + webJob.client.ID + " TO " + PlayerManager.Instance.player, webJob.price);
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
                        //Manager.Instance.increaseCash(income);
                        //Check which account
                        int stI = 0;
                        for (int j = 0; j < webJob.client.bankAccounts.Length; j++)
                        {
                            if (webJob.client.bankAccounts[j].accountBlocked == true)
                            {
                                stI++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        int stJ = 0;
                        for (int k = 0; i < target.GetComponent<FlatMechanics>().owner.bankAccounts.Length; k++)
                        {
                            if (target.GetComponent<FlatMechanics>().owner.bankAccounts[k].accountBlocked == true)
                            {
                                stJ++;
                            }
                            else
                            {
                                break;
                            }

                        }
                        webJob.client.bankAccounts[stI].TransferMoneyWithoutTaxes(target.GetComponent<FlatMechanics>().owner.bankAccounts[stJ],"AFR MTRANSFER FROM "+webJob.client.ID+" TO "+PlayerManager.Instance.player,webJob.price);
						break;
					}
				}

			}
            //Manager.Instance.increaseCash(income);
            //response = true;
        }
		return response;
	}
    
	

	public override void done()
	{
		PlayerManager.Instance.APRLimit--;
		webJob.done = true;
	}

	public override void finish()
	{
		PlayerManager.Instance.RemoveJob(webJob);
		PlayerManager.Instance.RemoveAction(this);
	}
}

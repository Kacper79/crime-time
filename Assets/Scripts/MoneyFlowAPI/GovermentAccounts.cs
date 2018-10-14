using System;
using UnityEngine;
public class GovermentAccounts : MonoBehaviour
{
	public static GovermentAccounts Instance;
	public BankAccount govAccount;
    public AssetAccount assetAccount;
	public void Start(){
		if(Instance==null){
			Instance = this;
		}else if(Instance != this){
			Destroy(gameObject);
		}
	}


}


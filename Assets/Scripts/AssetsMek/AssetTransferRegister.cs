
using System.Collections.Generic;
using UnityEngine;
public class AssetTransferRegister : MonoBehaviour{
	public List<AssetAccount> assetAccounts = new List<AssetAccount>();
	public List<AssetTransferHistory> transfers = new List<AssetTransferHistory>();
	public int tempID = -1;

	public static AssetTransferRegister Instance;

	public void Start(){
		if(Instance==null){
			Instance = this;
		}else if(Instance != this){
			Destroy(gameObject);
		}
	}

	public int GenerateTransactionID(){
		tempID++;
		return tempID;
	}
}



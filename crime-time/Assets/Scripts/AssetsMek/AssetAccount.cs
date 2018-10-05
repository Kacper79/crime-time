using System.Collections.Generic;
using UnityEngine;
public class AssetAccount : MonoBehaviour{
	public People owner;
	public bool haveAccess;
	public int value;
	public List<Asset> assets = new List<Asset>();
	public List<AssetTransferHistory> transferHistories = new List<AssetTransferHistory>();
	public List<Crime> crimes = new List<Crime>();

	public AssetAccount(People owner){
		this.owner = owner;
	}

	public void TransferAssetWithoutTax(AssetAccount client,int price,Asset asset){
		if(asset.owner == this.owner){
			//check if we have money
			AssetTransferHistory transferHistory = new AssetTransferHistory()
			{
				sender = this,
				reciver = client,
				money = price
				//ID = 	
			};

		}
	}
}



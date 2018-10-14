using System.Collections.Generic;
using UnityEngine;
public class AssetAccount : MonoBehaviour{
	public Person owner;
	public bool haveAccess;
	public int value;
	public List<Asset> assets = new List<Asset>();
	public List<AssetTransferHistory> transferHistories = new List<AssetTransferHistory>();
	public List<Law> crimes = new List<Law>();

	public AssetAccount(){
        AssetTransferRegister.Instance.assetAccounts.Add(this);
	}

	public void TransferAssetWithoutTax(AssetAccount client,BankAccount cba,BankAccount sba,int price,Asset asset){
        if (cba.money >= price && cba.accountBlocked == false && haveAccess)
        {
            if (asset.owner == this.owner)
            {
                MoneyTransferHistory history = new MoneyTransferHistory
                {
                    sender = sba,
                    reciver = cba,
                    title = "ATRANSFER MTRANSFER FROM " + sba.owner.ID + " TO " + cba.owner.ID,
                    money = price,
                    ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
                    tax = 0,
                    taxPayed = true
                };
                sba.bankStatements.Add(history);
                cba.bankStatements.Add(history);
                AssetTransferTaxLaw law = new AssetTransferTaxLaw();
                AssetTransferHistory transferHistory = new AssetTransferHistory()
                {
                    sender = this,
                    reciver = client,
                    money = price,
                    ID = AssetTransferRegister.Instance.GenerateTransactionID(),
                    asset = asset
                };
                transferHistory.tax = law.CalculateTaxes(transferHistory.asset);
                transferHistory.taxPayed = false;
                MoneyTransferRegister.Instance.transfers.Add(history);
                law.isVioleted = true;
                crimes.Add(law);
                transferHistories.Add(transferHistory);
                client.transferHistories.Add(transferHistory);
                AssetTransferRegister.Instance.transfers.Add(transferHistory);
                asset.owner = client.owner;
                sba.money += price;
                cba.money -= price;
            }

        }
        else
        {
            return;
        }

		
	}
    public void TransferAssetWithTax(AssetAccount client, BankAccount cba, BankAccount sba, int price, Asset asset)
    {
        AssetTransferTaxLaw law = new AssetTransferTaxLaw();
        int tax = law.CalculateTaxes(asset);
        if (price+tax >= cba.money && cba.accountBlocked == false && haveAccess)
        {
            if (asset.owner == this.owner)
            {
                MoneyTransferHistory history = new MoneyTransferHistory
                {
                    sender = sba,
                    reciver = cba,
                    title = "ATRANSFER MTRANSFER FROM " + sba.owner.ID + " TO " + cba.owner.ID,
                    money = price,
                    ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
                    tax = 0,
                    taxPayed = true
                };
                sba.bankStatements.Add(history);
                cba.bankStatements.Add(history);
                MoneyTransferHistory thistory = new MoneyTransferHistory
                {
                    sender = sba,
                    reciver = GovermentAccounts.Instance.govAccount,
                    money = price,
                    ID = MoneyTransferRegister.Instance.GenerateTransactionID()
                };
                AssetTransferHistory transferHistory = new AssetTransferHistory()
                {
                    sender = this,
                    reciver = client,
                    money = price,
                    ID = AssetTransferRegister.Instance.GenerateTransactionID(),
                    asset = asset
                };
                transferHistory.tax = tax;
                transferHistory.taxPayed = true;
                thistory.title = "ATT MTRANSFER" + thistory.ID + " FROM ATRANSFER " + transferHistory.ID + "FROM PERSON " + owner.ID;
                MoneyTransferRegister.Instance.transfers.Add(history);
                MoneyTransferRegister.Instance.transfers.Add(thistory);
                law.isVioleted = false;
                transferHistories.Add(transferHistory);
                client.transferHistories.Add(transferHistory);
                AssetTransferRegister.Instance.transfers.Add(transferHistory);
                asset.owner = client.owner;
                sba.money += price;
                cba.money -= price;
            }

        }
        else
        {
            return;
        }


    }
}



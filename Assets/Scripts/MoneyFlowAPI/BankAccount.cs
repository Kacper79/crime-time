using System;
using UnityEngine;
using System.Collections.Generic;
public class BankAccount : MonoBehaviour
{
	//public Bank located;
	public List<MoneyTransferHistory> bankStatements;
	public bool accountBlocked;
	public int money;
	public List<Law> crimes = new List<Law>();
	public Person owner;
    
	public BankAccount(){
		MoneyTransferRegister.Instance.bankAccounts.Add(this);
	}

	public void TransferMoneyWithoutTaxes(BankAccount recieve,String reason,int money){
		if (this.money >= money && this.accountBlocked==false)
        {
            this.money -= money;
		}else{
			return;
		}
		MoneyTransferHistory history = new MoneyTransferHistory
		{
			sender = this,
			reciver = recieve,
			title = reason,
			money = money,
			ID = MoneyTransferRegister.Instance.GenerateTransactionID()
		};
		bankStatements.Add(history);
        recieve.bankStatements.Add(history);
        MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
		history.tax = law.CalculateTaxes(history);
		history.taxPayed = false;
		MoneyTransferRegister.Instance.transfers.Add(history);
		law.isVioleted = true;
		crimes.Add(law);
        this.money -= money;
        recieve.money += money;
	}
    public void PayAssetMaintanceTax(Asset asset)
    {
        AssetMaintainceTaxLaw law = new AssetMaintainceTaxLaw();
        int tax = law.percent * asset.value;
        if (money >= tax && accountBlocked==false)
        {
            MoneyTransferHistory history = new MoneyTransferHistory
            {
                sender = this,
                reciver = GovermentAccounts.Instance.govAccount,
                ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
                money = tax,
                tax = tax,
                taxPayed = true

            };
            history.title = "AMT MTRANSFER " + history.ID + " FOR ASSET " + asset.name + " FROM PERSON " + owner.ID;
            bankStatements.Add(history);
            history.reciver.bankStatements.Add(history);
            MoneyTransferRegister.Instance.transfers.Add(history);
            law.isVioleted = false;
            money -= tax;
            history.reciver.money += tax;
        }
        else
        {
            return;
        }
    }
    public void TransferMoneyTaxFree(BankAccount recieve, String reason,int money)
    {

       
            MoneyTransferHistory history = new MoneyTransferHistory
            {
                sender = this,
                reciver = recieve,
                ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
                money = money,
                tax = 0,
                taxPayed = true

            };
            history.title = reason;
            bankStatements.Add(history);
            history.reciver.bankStatements.Add(history);
            MoneyTransferRegister.Instance.transfers.Add(history);
            //law.isVioleted = false;
            this.money -= money;
            history.reciver.money += money;
        
    }
    public void TransferMoneyWithTaxes(BankAccount recieve, String reason, int money)
    {
		MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
        int tax = law.CalculateTaxes(money);
        if(money+tax<=this.money && this.accountBlocked == false)
        {
            MoneyTransferHistory history = new MoneyTransferHistory
            {
                sender = this,
                reciver = recieve,
                title = reason,
                money = money,
                ID = MoneyTransferRegister.Instance.GenerateTransactionID()
            };
            history.tax = tax;
            history.taxPayed = true;

            MoneyTransferHistory taxHistory = new MoneyTransferHistory
            {
                sender = this,
                reciver = GovermentAccounts.Instance.govAccount,
                ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
                money = history.tax
            };
            taxHistory.title = "MTT MTRANSFER " + taxHistory.ID + " FROM MTRANSFER " + history.ID + " FROM PERSON " + owner.ID;
            bankStatements.Add(history);
            bankStatements.Add(taxHistory);
            recieve.bankStatements.Add(history);
            MoneyTransferRegister.Instance.transfers.Add(history);
            MoneyTransferRegister.Instance.transfers.Add(taxHistory);
            law.isVioleted = false;
            this.money -= (money + tax);
            recieve.money += (money+tax);
        }

	
        else
        {
            return;
        }
        
    }
}


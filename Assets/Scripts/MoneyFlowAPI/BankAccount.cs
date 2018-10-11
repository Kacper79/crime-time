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
		if (this.money >= money)
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
		MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
		history.tax = CalculateTaxes(history,law);
		history.taxPayed = false;
		MoneyTransferRegister.Instance.transfers.Add(history);
		law.isVioleted = true;
		crimes.Add(law);
	}
	public void TransferMoneyWithTaxes(BankAccount recieve, String reason, int money)
    {
		MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
        MoneyTransferHistory history = new MoneyTransferHistory
        {
            sender = this,
            reciver = recieve,
            title = reason,
            money = money,
            ID = MoneyTransferRegister.Instance.GenerateTransactionID()
        };
		history.tax = CalculateTaxes(history, law);
		if (this.money >= (money+history.tax))
        {
			this.money -= (money+history.tax);
			history.taxPayed = true;
			MoneyTransferHistory taxHistory = new MoneyTransferHistory
			{
				sender = this,
				reciver = GovermentAccounts.Instance.transferTaxAccount,
				ID = MoneyTransferRegister.Instance.GenerateTransactionID(),
				money = history.tax
			};
			taxHistory.title = "MTT MTRANSFER " + taxHistory.ID + " FROM MTRANSFER "+ history.ID+" FROM PERSON " + owner.ID;
			bankStatements.Add(history);
			bankStatements.Add(taxHistory);
            MoneyTransferRegister.Instance.transfers.Add(history);
			law.isVioleted = false;
        }
        else
        {
            return;
        }
        
    }
	public int CalculateTaxes(MoneyTransferHistory history,MoneyTransferTaxLaw law){
		return (int)law.percent * history.money;
	}
}


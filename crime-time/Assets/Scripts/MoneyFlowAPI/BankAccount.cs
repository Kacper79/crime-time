using System;
using UnityEngine;
using System.Collections.Generic;
public class BankAccount : MonoBehaviour
{
	//public Bank located;
	public List<TransferHistory> bankStatements;
	public bool accountBlocked;
	public int money;
	public List<Crime> crimes = new List<Crime>();
	public People owner;
    
	public BankAccount(){
		TransferRegister.Instance.bankAccounts.Add(this);
	}

	public void TransferMoneyWithoutTaxes(BankAccount recieve,String reason,int money){
		if (this.money >= money)
        {
            this.money -= money;
		}else{
			return;
		}
		TransferHistory history = new TransferHistory
		{
			sender = this,
			reciver = recieve,
			title = reason,
			money = money,
			ID = TransferRegister.Instance.GenerateTransactionID()
		};
		bankStatements.Add(history);
		MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
		history.tax = CalculateTaxes(history,law);
		history.taxPayed = false;
		TransferRegister.Instance.transfers.Add(history);
		law.isVioleted = true;
		Crime crime = new Crime(law,false);
		crimes.Add(crime);
	}
	public void TransferMoneyWithTaxes(BankAccount recieve, String reason, int money)
    {
		MoneyTransferTaxLaw law = new MoneyTransferTaxLaw();
        TransferHistory history = new TransferHistory
        {
            sender = this,
            reciver = recieve,
            title = reason,
            money = money,
            ID = TransferRegister.Instance.GenerateTransactionID()
        };
		history.tax = CalculateTaxes(history, law);
		if (this.money >= (money+history.tax))
        {
			this.money -= (money+history.tax);
			history.taxPayed = true;
			TransferHistory taxHistory = new TransferHistory
			{
				sender = this,
				reciver = GovermentAccounts.Instance.transferTaxAccount,
				ID = TransferRegister.Instance.GenerateTransactionID(),
				money = history.tax
			};
			taxHistory.title = "MTT MTRANSFER " + taxHistory.ID + " FROM MTRANSFER "+ history.ID+" FROM PERSON " + owner.ID;
			bankStatements.Add(history);
			bankStatements.Add(taxHistory);
            TransferRegister.Instance.transfers.Add(history);
			law.isVioleted = false;
        }
        else
        {
            return;
        }
        
    }
	public int CalculateTaxes(TransferHistory history,MoneyTransferTaxLaw law){
		return (int)law.percent * history.money;
	}
}


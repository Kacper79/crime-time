using System;
using UnityEngine;
using System.Collections.Generic;
public class BankAccount : MonoBehaviour
{
	//public Bank located;
	public List<TransferHistory> bankStatements;
	public bool accountBlocked;
	public int money;
	public List<Law> laws = new List<Law>();
    
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
		laws.Add(law);
		history.tax = CalculateTaxes(history,law);
		history.taxPayed = false;
		TransferRegister.Instance.transfers.Add(history);
	}
	public int CalculateTaxes(TransferHistory history,MoneyTransferTaxLaw law){
		return (int)law.percent * history.money;
	}
}


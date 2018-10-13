using System;
using UnityEngine;
public class MoneyTransferTaxLaw : Law
{
	public BankAccount govermentBankAccount;
	public float percent;
    public int CalculateTaxes(MoneyTransferHistory history)
    {
        return (int)this.percent * history.money;
    }
    public int CalculateTaxes(int money)
    {
        return (int)this.percent * money;
    }
}


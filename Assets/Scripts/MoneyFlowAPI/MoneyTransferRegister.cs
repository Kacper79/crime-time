
using System.Collections.Generic;
using UnityEngine;
public class MoneyTransferRegister : MonoBehaviour{
	public List<BankAccount> bankAccounts = new List<BankAccount>();
	public List<MoneyTransferHistory> transfers = new List<MoneyTransferHistory>();
	public int tempID = -1;

	public static MoneyTransferRegister Instance;

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



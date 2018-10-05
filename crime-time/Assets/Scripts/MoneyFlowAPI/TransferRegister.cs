
using System.Collections.Generic;
using UnityEngine;
public class TransferRegister : MonoBehaviour{
	public List<BankAccount> bankAccounts = new List<BankAccount>();
	public List<TransferHistory> transfers = new List<TransferHistory>();
	public int tempID = -1;

	public static TransferRegister Instance;

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



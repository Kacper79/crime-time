using System.Collections.Generic;
using UnityEngine;
public class WorkRegister : MonoBehaviour{
	public static WorkRegister Instance;
	public List<Work> organizations;

	public WorkRegister(){
		if(Instance== null){
			Instance = this;
		}else if(Instance != this){
			Destroy(gameObject);
		}
	}

}


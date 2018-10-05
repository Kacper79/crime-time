using System.Collections.Generic;
using UnityEngine;
public class AssetRegister : MonoBehaviour{
	public static AssetRegister Instance;
	public List<Asset> assets = new List<Asset>();

	public AssetRegister(){
		if(Instance==null){
			Instance = this;
		}else if(Instance != this){
			Destroy(gameObject);
		}
	}

}
  


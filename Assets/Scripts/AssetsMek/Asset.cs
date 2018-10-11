using System;
using UnityEngine;

public class Asset : MonoBehaviour{
	public Person owner;
	public String aname;
	public int value;

	public Asset(){		
		AssetRegister.Instance.assets.Add(this);
	}
    
}  
   


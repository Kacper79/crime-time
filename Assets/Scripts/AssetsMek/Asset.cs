using System;
using UnityEngine;

public class Asset : MonoBehaviour{
	public Person owner;
	public string aname;
	public int value;
    public bool isMonument;
    public int monumentMultiplier = 20;
    public AssetMek mek;
	public Asset(){		
		AssetRegister.Instance.assets.Add(this);
	}
    
}  
   


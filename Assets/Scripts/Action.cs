using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour {
	public bool isdone = false;
	public int id;

	//public abstract void checki();
	public abstract bool checkd();
	public abstract void done();
	public abstract void finish();
	public int getID(){
		return id;
	}
	public void setID(int id){
		this.id = id;
	}

}

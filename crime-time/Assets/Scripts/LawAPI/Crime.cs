using System;
using UnityEngine;
public class Crime : MonoBehaviour
{
	public Law brokenLaw;
	public bool noticed;
	//public PoliceStation reaserchingStation;
	public bool sentenced;
	public People judge;
	public short hardness = 0;//75% Insider(1) 50% bad made(2) 25% Normal(3) //10%-5% Anomized(4) //0% well hidden(5)  

	public Crime(Law law,bool noticed){
		this.brokenLaw = law;
		this.noticed = noticed;
	}

	public void ReportCrimeDiscovery(){
		this.noticed = true;
	}
}


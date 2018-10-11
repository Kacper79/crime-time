using System;
using UnityEngine;
public abstract class Law : MonoBehaviour
{
	public bool broken;
	public bool isVioleted;
    public bool noticed;
    //public PoliceStation reaserchingStation;
    public bool sentenced;
    public Person judge;
    public short hardness = 0;

}




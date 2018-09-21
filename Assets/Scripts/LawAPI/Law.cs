using System;
using UnityEngine;
public abstract class Law : MonoBehaviour
{
	public bool broken;
	public bool isVioleted;
	public abstract void CheckViolation();


}




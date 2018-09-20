using System;
using System.Collections.Generic;
using UnityEngine;
public class PeopleRegister : MonoBehaviour
{
	public static Dictionary<int, People> register;
    
	public void Add(People people){
		register.Add(people.ID, people);
	}
	public void Remove(People people){
		register.Remove(people.ID);
	}
} 


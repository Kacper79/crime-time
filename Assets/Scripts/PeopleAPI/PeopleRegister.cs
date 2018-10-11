using System;
using System.Collections.Generic;
using UnityEngine;
public class PeopleRegister : MonoBehaviour
{
	public static Dictionary<int, Person> register;

	public void AddPeople(Person people){
		register.Add(people.ID, people);
	}
	public void RemovePeople(Person people){
		register.Remove(people.ID);
	}
} 


using System;
using System.IO;
using UnityEngine;

public class PeopleCreator : MonoBehaviour
{
	public string[] allposibblenames;
	public System.Random random;
	public int tempID = 0;
	public void Start(){
		allposibblenames = GetNamesFromFile("Assets/Configs/identities.cfg");
		random = new System.Random(); 
	}
    //Genrate basic info - Name,Birthdate,Age,IQ,EQ,ID
	public PeopleRegister GeneratePersonalInfo(){
		PeopleRegister register = new PeopleRegister();
		int nowi = new DateTime().Year;
		register.age = random.Next(15, 40);
		register.age=nowi - register.age;
		String pn = GenerateName();
		register.IQ = random.Next(1, 100);
		register.EQ = random.Next(0,250);
		register.ID = tempID++;
		return register;
	} 
    
	public string[] GetNamesFromFile(string path)
    {
        StreamReader reader = new StreamReader(path);
        string[] lines = new string[200];
        for (int i = 0; i < 200; i++)
        {
            lines[i] = reader.ReadLine();
        }
        reader.Close();
        return lines;
    }

	public string GenerateName()
	{
		return allposibblenames[random.Next(0, 199)];
	}
}


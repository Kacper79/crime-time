using System;
using System.IO;
using UnityEngine;

public class PeopleCreator : MonoBehaviour
{
	public string[] allposibblenames;
	public System.Random random; 
	public void Start(){
		allposibblenames = GetNamesFromFile("Assets/Configs/identities.cfg");
		random = new System.Random(); 
	}
    //Genrate basic info - Name,Birthdate,Age,IQ,EQ,ID
	public void GeneratePersonalInfo(){
		int nowi = 2018;
		DateTime current = new DateTime(nowi);
		int age = random.Next(15, 40);
		int bd = nowi - age;
		String pn = GenerateName();
		int IQ = random.Next(1, 100);
		int EQ = random.Next(0,250);
		int ID = random.Next(0,Manager.Instance.maxnumberofcitizens);
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


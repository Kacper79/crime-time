using System;
using System.IO;
using UnityEngine;

public class PeopleCreator
{
	public string[] allposibblenames;
	public System.Random random = new System.Random();
    
	public void GeneratePeople(){
		
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


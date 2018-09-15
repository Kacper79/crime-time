using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
//namespace AssemblyCSharp.Assets.Scripts.PeopleAPI

public class PeopleRegister : MonoBehaviour
{
	public String pname;//Name along with the surname of this person
	public int birthDate;//Personal data worth to sell;
	public bool wasCriminalAlready;//If not price may be exotic be to much or not to many;
	public int age;//Age increases intrest lowers requirements increases along with the price;
	public string[] hiddenData;//It works if you spy someone to sell data about this person;
	public bool revenge;//If the reason person commit crimes is a revange he will probably pay more
	public bool crimelord;//if he is a crimelord the pricing will be higher("with honour");
	public int revangeStreak;//how many orders will be led by revange;
	//public Product[] shoplist//shop list - person will with high % buy products from that list;
	public Dictionary<int, Action> totalcriminalhistory;//Total history of crimes of this person;
	public Dictionary<int, Action> policecriminalhistory;//History of crimes sentected by police;
	//public Car[] carlist;//List of person cars;
	//public Building[] assets;//List of assets;
	public int monthlyIncomes;//Income of person;
	public string[] wishlisto;//List of person liked buildings etc...
	public string[] objectlist;
	System.Random random = new System.Random();
    //Called in each round
	public void GenerateOrder(){
		//Choosing the crime type        
        
		JobType jt = (JobType)random.Next(1,2);
		int count = Manager.Instance.numberofbuildingsonthemap;
        //Cheking if it's FRH
		if(jt == JobType.Flat_RentHouse){
			
			//Choose if it's a random or specyfic flat
			int o = random.Next(0, count);
			if(o!=0){
				
			}else{//its random
				  //Find object on the scene matching the name.
				  //Feed the 1st arg
				  //Chosing the income
				int income = AFlat_Rent.priceUnit * random.Next(1,8);
				//Choosing hoteldays count
				int hoteldays = random.Next(1, 7);
				income *= hoteldays;
			}
		}
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
		return objectlist[random.Next(0, 199)];

    }
 }


using System;
using UnityEngine;
using System.Collections.Generic;
//namespace AssemblyCSharp.Assets.Scripts.PeopleAPI

public class PeopleRegister : MonoBehaviour
{
	public String pname;//Name along with the surname of this person
	public int birthDate;//Personal data worth to sell;
	public bool wasCriminalAlready;//If not price may be exotic be to much or not to many;
	public int age;//Age increases intrest lowers requirements increases along with the price;
	public String[] hiddenData;//It works if you spy someone to sell data about this person;
	public bool revenge;//If the reason person commit crimes is a revange he will probably pay more
	public bool crimelord;//if he is a crimelord the pricing will be higher("with honour");
	public int revangeStreak;//how many orders will be led by revange;
	//public Product[] shoplist//shop list - person will with high % buy products from that list;
	public Dictionary<int, Action> totalcriminalhistory;//Total history of crimes of this person;
	public Dictionary<int, Action> policecriminalhistory;//History of crimes sentected by police;
	//public Car[] carlist;//List of person cars;
	//public Building[] assets;//List of assets;
	public int monthlyIncomes;//Income of person;
	public String[] wishlisto;//List of person liked buildings etc...

    //Called in each round
	public void GenerateOrder(){
		//Choosing the crime type
		System.Random random = new System.Random();
		JobType jt = (JobType)random.Next(1,2);
        //Adjusting random FRH order values
		if(jt == JobType.Flat_RentHouse){
			//Choose if it's a random or specyfic flat
			int o = random.Next(0, 2048);
			if(o!=0){
				
			}else{//its random
				
			}
		}
	}
 }


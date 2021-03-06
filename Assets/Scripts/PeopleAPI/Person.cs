﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
//namespace AssemblyCSharp.Assets.Scripts.API

public class Person : MonoBehaviour
{
	public String pname;//Name along with the surname of this person
	public int birthDate;//Personal data worth to sell;
	public bool wasCriminalAlready;//If not price may be exotic be to much or not to many;
	public int age;//Age increases intrest lowers requirements increases along with the price;
	public string[] hiddenData;//It works if you spy someone to sell data about this person;
	public bool revenge;//If the reason person commit crimes is a revange he will probably pay more
	public int crimelord;//if he is a crimelord the pricing will be higher("with honour");
	public int revangeStreak;//how many orders will be led by revange;
	public int IQ;
	public int EQ;
	public int ID;
	//public Product[] shoplist//shop list - person will with high % buy products from that list;
	public Dictionary<int, Law> totalcriminalhistory;//Total history of crimes of this person;
	public Dictionary<int, Law> policecriminalhistory;//History of crimes sentected by police;
	//public Car[] carlist;//List of person cars;
	//public Building[] assets;//List of assets;
	public int monthlyIncomes;//Income of person;
	public string[] wishlisto;//List of person liked buildings etc...
	public string[] objectlist;
	public bool isDead;
	public int gender;// 0 - Male 1 - Female
	public BankAccount[] bankAccounts;
    public AssetAccount assetAccount;
    public bool wasAbused;//If (s)he was (s)he might wanna revenge on him/her
    public Testament testament;
    public Family Family;
	System.Random random = new System.Random();
    
	public void GenerateOrder(){
		//Choosing the crime type        
        
		JobType jt = (JobType)random.Next(1,2);
        //Cheking if it's FRH
		if(jt == JobType.Flat_RentHouse){
			
			//Choose if it's a random or specyfic flat
			int o = random.Next(0, wishlisto.Length-1);
			if(o!=0){
				float income = AFlat_Rent.priceUnit * random.Next(1, 8);
                //Choosing hoteldays count
                int vhoteldays = random.Next(1, 7);
                income *= vhoteldays;
                if (revenge == true)
                {
                    //income = (int)(income * 1.5f);
                    income = (int)(income * (EQ / IQ) * revangeStreak);
                }
                else
                {
                    income = (int)(income * (EQ / IQ));
                }
                if (crimelord != 0)
                {
                    income = (int)(income * crimelord * 1.5f);
                }
                income = (int)(income * (1 / ((age - 15) / 25))) / 10;
                if (!wasCriminalAlready)
                {
                    income = (int)(income * (random.Next(0, 8) / 4));
                }
                else
                {
                    income = (int)(income * totalcriminalhistory.Keys.Count / 4 * (crimelord + 1));
                }
				income = (int)(income * (gameObject.GetComponent<FlatMechanics>().equipment * 1.5f));
				WebJob webJob = new WebJob
				{
					clientName = this.pname,
					price = (int)income,
					taken = false,
					done = false,
					Jobtype = JobType.Flat_RentHouse
				};
				AFlat_Rent action = new AFlat_Rent(webJob)
				{
					hoteldays = vhoteldays,
					crimeduration = vhoteldays,
					random = true
				};
                PlayerManager.Instance.AddJob(webJob);
                PlayerManager.Instance.AddAction(action);
			}
			else{//its random
				  //Find object on the scene matching the name.
				  //Feed the 1st arg
				GameObject goo = GameObject.Find(wishlisto[o]);
				  //Chosing the income
				float income = AFlat_Rent.priceUnit * random.Next(1,8);
				//Choosing hoteldays count
				int vhoteldays = random.Next(1, 7);
				income *= vhoteldays;
				if(revenge == true){
					//income = (int)(income * 1.5f);
					income = (int)(income * (EQ / IQ) * revangeStreak);
				}else{
					income = (int)(income * (EQ / IQ));
				}
				if(crimelord!=0){
					income = (int)(income * crimelord * 1.5f);
				}
				income = (int)(income * (1/((age - 15) / 25)))/10;
				if(!wasCriminalAlready){
					income = (int)(income * (random.Next(0, 8) / 4));
				}else{
					income = (int)(income * totalcriminalhistory.Keys.Count / 4 * (crimelord+1));               
				}
				WebJob webJob = new WebJob
				{
					clientName = this.pname,
					price = (int)income,
					taken = false,
					done = false,
					Jobtype = JobType.Flat_RentHouse
				};
				AFlat_Rent action = new AFlat_Rent(goo, webJob)
				{
					hoteldays = vhoteldays,
					crimeduration = vhoteldays,
					random = false
				};
				//webjob.ConstructUI();
				//webhob.SetActive();
				PlayerManager.Instance.AddAction(action);
				PlayerManager.Instance.AddJob(webJob);
			}
		}
	}
	     
 }


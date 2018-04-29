using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebJob : MonoBehaviour {

    // Use this for initialization
    string clientName;
    bool done;
    public enum JOB_TYPE { Criminal_house,Rent_house};

    public JOB_TYPE Jobtype { get; set; }
    public int price;

    public void ConstructUI()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebJob : MonoBehaviour {

    // Use this for initialization
    public string clientName;
    public bool done;
    public enum JOB_TYPE { Criminal_house,Rent_house};

    public JOB_TYPE Jobtype { get; set; }
    public int price;

    public GameObject proto;

    public void ConstructUI()
    {
       GameObject g= Instantiate(proto);
       Text[] textes= g.GetComponentsInChildren<Text>();
        textes[0].text = clientName;
        textes[1].text = Jobtype.ToString();
        textes[2].text = price.ToString();
    }
}

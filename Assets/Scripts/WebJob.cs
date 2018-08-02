using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< HEAD
using System.IO;
using TMPro;
=======
using TMPro;
using TMPro.EditorUtilities;
>>>>>>> a5c2d22aafeba827135b9ea123077bf0bc9c9504

public class WebJob : MonoBehaviour
{

<<<<<<< HEAD
    // Use this for initialization
    public string clientName;
    public bool done;
    public enum JOB_TYPE {Flat_RentHouse};

    public JOB_TYPE Jobtype { get; set; }
    public int price;
    public int minPriceFRH = 1000;
    public int maxPriceFRH = 2000;
    public float priceMultiplayer = 2.5f;
    public GameObject proto;
    public int orderCount = 5;
    public bool firstActive = false;
    public int jobNumber = 0;//1 - FRH
    public string[] names;
    public GameObject cp;
    public void Start()
    {
         names = GetNamesFromFile("Assets/Configs/identities.cfg");
         
    }
    public void ConstructRentHouseOrder()
    {
        
        for (int i = 1;i < orderCount + 1; i++) {
            System.Random r = new System.Random();
            RectTransform parent = cp.GetComponent<RectTransform>();
            GameObject g = Instantiate(proto,new Vector3(proto.transform.position.x,proto.transform.position.y-(i*44.8f),0),Quaternion.identity,parent);
            
            g.name = proto.name + i;
            TextMeshProUGUI[] textes = g.GetComponentsInChildren<TextMeshProUGUI>();

            textes[0].text = names[r.Next(0,200-i)];
            textes[1].text = "Order:<b>"+JOB_TYPE.Flat_RentHouse.ToString()+"</b>";
            System.Random r2 = new System.Random();
            price = (int)System.Math.Ceiling(r2.Next(minPriceFRH, maxPriceFRH) *priceMultiplayer *UiManager.Instance.currentBuilding.GetComponent<FlatMechanics>().equipment);
            textes[2].text = "PRICE:"+price.ToString()+"$";
        }
        
    }
    public string[] GetNamesFromFile(string path)
    {
        StreamReader reader = new StreamReader(path);
        string[] lines = new string[200];
        for(int i = 0; i < 200; i++)
        {
            lines[i] = reader.ReadLine();
        }
        reader.Close();
        return lines;
    }
    public void Update()
    {
        if(firstActive == true)
        {
           if (jobNumber == 1)
            {
                ConstructRentHouseOrder();
                firstActive = false;
            }
            
        }
    }
    public void setFirstActive(bool state)
    {
        firstActive = state;
    }
    public void setJobID(int ID)
    {
        jobNumber = ID;
    }
=======
	// Use this for initialization
	public string clientName;
	public bool done;


	public JOB_TYPE Jobtype;
	public int price;

	public GameObject panel;

	void Start()
	{
		Debug.Log("Start");
		panel = gameObject;
		ConstructUI();
	}

	public void ConstructUI()
	{
		TMP_Text[] texts = panel.GetComponentsInChildren<TMP_Text>();

		//GameObject g = Instantiate(proto);

		//Text[] texts = panel.GetComponentsInChildren<Text>();
		texts[0].text = clientName;
		texts[1].text = Jobtype.ToString();
		texts[2].text = price.ToString();
	}
>>>>>>> a5c2d22aafeba827135b9ea123077bf0bc9c9504
}
public enum JOB_TYPE
{
	Criminal_house,
	Rent_house
}
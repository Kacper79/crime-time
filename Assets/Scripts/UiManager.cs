using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{

    FlatMechanics Building;
    public GameObject flatUI;
    public TextMeshProUGUI[] FlatTexts;
    public GameObject currentBuilding;
    public static UiManager Instance;
    public GameObject moneyDisplay;
    public bool onceOpened = false;
    //public PanelClose flatClose;

    void Start()
    {
        Instance = this;
        FlatTexts = flatUI.GetComponentsInChildren<TextMeshProUGUI>();

        //FlatTexts [4].text = "Upgrade Size";
        //FlatTexts [5].text = "Upgrade Equipment";
        //FlatTexts [6].text = "Rent Criminal";
    }

    public void SetFlatValues()
    {
        FlatTexts[3].text = "<#FF0000>S</color>IZE <b>" + currentBuilding.GetComponent<FlatMechanics>().size + "</b>";
        FlatTexts[1].text = "<#FF0000>Q</color>UALITY <b> " + currentBuilding.GetComponent<FlatMechanics>().equipment + "</b>"; 
        FlatMechanics f = currentBuilding.GetComponent<FlatMechanics>();
        if(f.act == false)
        {
            FlatTexts[5].text = "<#FF0000><b>A</color></b>ct of ownership <b>F</b>";
        }
        else
        {
            FlatTexts[5].text = "<#FF0000><b>A</color></b>ct of ownership <b>T</b>";
        }
        int sp = 0;
        int ep = 0;
        if (f.size == 1) { sp = f.s2uc; }
        if (f.size == 2) { sp = f.s3uc; }
        if (f.size == 3) { sp = f.s4uc; }
        if (f.size == 4) { sp = f.s5uc; }
        if (f.size == 5) { sp = 0; }
        if (f.equipment == 0) { ep = f.e1uc; }
        if (f.equipment == 1) { ep = f.e2uc; }
        if (f.equipment == 2) { ep = f.e3uc; }
        if (f.equipment == 3) { ep = f.e4uc; }
        if (f.equipment == 4) { ep = f.e5uc; }
        if (f.equipment == 5) { ep = 0; }
        FlatTexts[7].text = "<#6FB00B>Quality improvment price " + ep+ "$\nSize improvemnt price " + sp + "$\nAct price " + f.apc + "$</color>";
        FlatTexts[9].text = "<#FF0000>O</color>CUPPIED <b>"+f.occupied+"/"+f.maxOccupied+"</b>";
        //FlatTexts [3].text = "Occupied:" + currentBuilding.GetComponent <FlatMechanics> ().isTaken;
    }

    void Update()
    {
        if (currentBuilding != null && currentBuilding.GetComponent<Building>().type == BuildingType.Flat)
        {
            FlatTexts[3].text = "<#FF0000>S</color>IZE <b>" + currentBuilding.GetComponent<FlatMechanics>().size + "</b>";
            FlatTexts[1].text = "<#FF0000>Q</color>UALITY <b> " + currentBuilding.GetComponent<FlatMechanics>().equipment + "</b>";
            FlatMechanics f = currentBuilding.GetComponent<FlatMechanics>();
            if (f.act == false)
            {
                FlatTexts[5].text = "<#FF0000><b>A</color></b>ct of ownership <b>F</b>";
            }
            else
            {
                FlatTexts[5].text = "<#FF0000><b>A</color></b>ct of ownership <b>T</b>";
            }
            int sp = 0;
            int ep = 0;
            int ap = 0;
            if (f.size == 1) { sp = f.s2uc; }
            if (f.size == 2) { sp = f.s3uc; }
            if (f.size == 3) { sp = f.s4uc; }
            if (f.size == 4) { sp = f.s5uc; }
            if (f.size == 5) { sp = 0; }
            if (f.equipment == 0) { ep = f.e1uc; }
            if (f.equipment == 1) { ep = f.e2uc; }
            if (f.equipment == 2) { ep = f.e3uc; }
            if (f.equipment == 3) { ep = f.e4uc; }
            if (f.equipment == 4) { ep = f.e5uc; }
            if (f.equipment == 5) { ep = 0; }
            if(f.act == false)
            {
                ap = f.apc;
            }
            else
            {
                ap = 0;
            }
            FlatTexts[7].text = "<#6FB00B>Quality improvment price " + ep + "$\nSize improvemnt price " + sp + "$\nAct price " + ap + "$</color>";
            FlatTexts[9].text = "<#FF0000>O</color>CUPPIED <b>" + f.occupied + "/" + f.maxOccupied + "</b>";
            //FlatTexts [3].text = "Occupied: " + currentBuilding.GetComponent <FlatMechanics> ().isTaken;
        }
    }

    public void setOnceOpened(bool state)
    {
        onceOpened = state;
    }
    public bool isOnceOpened()
    {
        return onceOpened;
    }
}
public enum BuildingType
{
	Flat,
	Bank
}

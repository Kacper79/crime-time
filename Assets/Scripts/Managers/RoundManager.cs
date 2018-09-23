using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public int roundNumber = 0;
    public bool once = false;
    public GameObject contentPanel;

	public void NextRound()
    {
        roundNumber++;
        //contentPanel.GetComponent<WebJob>().ConstructRentHouseOrder(6);// Generate new orders in next round
        Debug.Log("Next Round");
    }
    public void Start()
    {
        once = true;
    }
    public void Update()
    {
        if(once == true)
        {
            NextRound();
            once = false;
        }
        
    }

}

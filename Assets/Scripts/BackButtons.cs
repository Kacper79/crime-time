using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtons : MonoBehaviour {
    public int type = 0;

    public void Start()
    {
        string name = gameObject.name;
        if (name.Contains("Team"))
        {
            type = 0;
        }
        if (name.Contains("Economy"))
        {
            type = 1;
        }
        if (name.Contains("Web"))
        {
            type = 2;
        }
    }
    
    public void OnMouseDown()
    {
        if(type == 0)
        {
            Debug.Log("Team button closed");
        }
        if(type == 1)
        {

        }
        if(type == 3)
        {

        }
    }
}

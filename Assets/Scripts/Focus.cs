using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour {

    public int state = 0;//0-Game 1-Web

    public void setState(int state)
    {
        this.state = state;
    }

}

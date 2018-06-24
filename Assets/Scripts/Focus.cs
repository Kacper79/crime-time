using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour {

    public int state = 0;//0-Game 1-BigPanels 2 D1 3 D2

    public void setState(int state)
    {
        this.state = state;
    }
    public int getState()
    {
        return state;
    }

}

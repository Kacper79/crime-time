using System;
using UnityEngine;
public class GovermentPerson : MonoBehaviour
{
    public static GovermentPerson Instance;
    public Person confiscatePerson;
    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}



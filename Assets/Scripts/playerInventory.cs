using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots; 
    public static playerInventory instance;

    private void Awake()
    {
        instance = this;
    }
}
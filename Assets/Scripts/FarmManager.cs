using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public CropItem selectCrop;
    public bool isPlanting = false;

    public void SelectDeselectCrop(CropItem newCrop)
    {
        if(selectCrop == newCrop)
        {
            Debug.Log("Deseleccionado: " + newCrop.crop.plantName);
            selectCrop = null;
            isPlanting = false;        
        }
        else
        {
            selectCrop = newCrop;
            isPlanting = true;
            Debug.Log("Seleccionado: " + newCrop.crop.plantName);
        }
    }
}

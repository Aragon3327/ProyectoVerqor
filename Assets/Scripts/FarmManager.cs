using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public CropItem selectCrop;
    public bool isPlanting = false;

    public Sprite selectImg;
    public Sprite deselectImg;
    CrecimientoParalelo Crop;
    public AgriculturaBtn agri;
    public AdicionalesBtn adicionales;

    

    public void SelectDeselectCrop(CropItem newCrop)
    {
        if(selectCrop == newCrop)
        {
            Debug.Log("Deseleccionado: " + newCrop.crop.plantName);
            selectCrop.btnImage.sprite = selectImg;
            selectCrop.btnText.text = "Seleccionar";
            selectCrop.btnText.alignment = TextAlignmentOptions.Center;
            selectCrop = null;
            isPlanting = false;        
        }
        else
        {
            if (selectCrop != null)
            {
                selectCrop.btnImage.sprite = selectImg;
                selectCrop.btnText.text = "Seleccionar";
                selectCrop.btnText.alignment = TextAlignmentOptions.Center;

                Crop = GameObject.Find(selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

                Crop.fertilizanteSelec = false;
                Crop.insecticidaSelec = false;
                Crop.abonoSelec = false;
                Crop.agriRegenerativa = false;
                Crop.agriTradicional = false;
                agri.desactivarAgri();
                adicionales.desactivarOpciones();
            }

            selectCrop = newCrop;

            selectCrop.btnImage.sprite = deselectImg;
            selectCrop.btnText.text = "Cancelar";
            selectCrop.btnText.alignment = TextAlignmentOptions.Bottom;

            isPlanting = true;
            Debug.Log("Seleccionado: " + newCrop.crop.plantName);
        }
    }
}

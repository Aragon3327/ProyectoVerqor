using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgriculturaBtn : MonoBehaviour
{
    CrecimientoParalelo selectedCrop;
    FarmManager fm;

    public Button[] btnsAgri;
    public Sprite selectImg;
    public Sprite deselectImg;

    public GameObject notificacion;


    // Start is called before the first frame update
    void Start()
    {
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();
    }

    public void OnClickAgriRegenerativa()
    {
        if (fm.selectCrop != null)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.agriRegenerativa)
            {
                // Deseleccionar el otro tipo de agricultura
                if (selectedCrop.agriTradicional)
                {
                    selectedCrop.agriTradicional = false;
                    btnsAgri[1].GetComponent<Image>().sprite = deselectImg;
                }

                selectedCrop.agriRegenerativa = true;
                btnsAgri[0].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.agriRegenerativa = false;
                btnsAgri[0].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else
        {
            // Mostrar panel que no tiene cultivo seleccionado
            notificacion.SetActive(true);
        }
    }

    public void OnClickAgriTradicional()
    {
        if (fm.selectCrop != null)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.agriTradicional)
            {
                // Deseleccionar el otro tipo de agricultura
                if (selectedCrop.agriRegenerativa)
                {
                    selectedCrop.agriRegenerativa = false;
                    btnsAgri[0].GetComponent<Image>().sprite = deselectImg;
                }
                selectedCrop.agriTradicional = true;
                btnsAgri[1].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.agriTradicional = false;
                btnsAgri[1].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else
        {
            // Mostrar panel que no tiene cultivo seleccionado
            notificacion.SetActive(true);
        }
    }

    public void desactivarAgri()
    {
        btnsAgri[0].GetComponent<Image>().sprite = deselectImg;
        btnsAgri[1].GetComponent<Image>().sprite = deselectImg;
    }
}

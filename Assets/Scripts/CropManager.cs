using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CropManager : MonoBehaviour
{
    public SpriteRenderer plant;

    FarmManager fm;

    public GameObject menu;
    private CrecimientoParalelo CropObj;

    public AdicionalesBtn adicionales;
    public AgriculturaBtn agri;

    public GameObject[] notificacion;

    public Proximity salir;

    

    // Start is called before the first frame update
    void Start()
    {
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();
    }


    // Plantar cultivos si no hay nada plantado
    public void OnClickPlantar()
    {
        bool hasItem = false;
        int ItemPos = 0;

        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.isFull[i])
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().item)
                {
                    if (playerInventory.instance.slots[i].GetComponent<Item>().item.nombre == fm.selectCrop.crop.plantName)
                    {
                        hasItem = true;
                        ItemPos = i;
                        break;
                    }
                }
            }
        }

        if (fm.isPlanting && hasItem)
        {
            // Plantar(fm.selectCrop.crop);
            CropObj = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
            CropObj.Plantar(fm.selectCrop.crop, true);
            fm.SelectDeselectCrop(fm.selectCrop);

            if (CropObj.fertilizanteSelec)
            {
                adicionales.DesactivarFertilizante();
            }
            if (CropObj.abonoSelec)
            {
                adicionales.DesactivarAbono();
            }
            if (CropObj.insecticidaSelec)
            {
                adicionales.DesactivarInsecticida();
            }

            agri.desactivarAgri();

            playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
            playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
            playerInventory.instance.isFull[ItemPos] = false;

            foreach (var btnAdicional in adicionales.btnsAdicionales)
            {
                btnAdicional.GetComponent<Image>().sprite = adicionales.deselectImg;
            }

            menu.SetActive(false); // Desactivar menu
        }
        else if (!hasItem)
        {
            desactivarOpciones();
            notificacion[0].SetActive(true);
            fm.SelectDeselectCrop(fm.selectCrop);
        }
    }

    // Cosechar cultivos si ha terminado de crecer
    public void OnClickCosechar()
    {
        CropObj = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

        if (CropObj.isPlanted && fm.selectCrop.crop)
        {
            if (CropObj.plantStage == CropObj.selectedCrop.plantStages.Length - 1)
            {
                for (int i = 0; i < playerInventory.instance.slots.Length; i++)
                {
                    if (!playerInventory.instance.isFull[i])
                    {

                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = CropObj.selectedCrop.itemVenta;

                        if (CropObj.abonoSelec)
                        {
                            CropObj.selectedCrop.itemVenta.abono = true;
                            playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.precioAbono += 100;
                        }

                        if (CropObj.agriRegenerativa)
                        {
                            CropObj.selectedCrop.itemVenta.regenerativa = true;
                            playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.precioReg += 200;
                        }

                        CropObj.Cosechar(false);
                        CropObj.fertilizanteSelec = false;
                        CropObj.abonoSelec = false;
                        CropObj.insecticidaSelec = false;

                        CropObj.agriRegenerativa = false;
                        CropObj.agriTradicional = false;

                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                        fm.SelectDeselectCrop(fm.selectCrop);
                        menu.SetActive(false); // Desactivar menu
                        break;
                    }
                    else if (i == playerInventory.instance.slots.Length - 1)
                    {
                        // Mostrar panel que no tiene espacio en el inventario
                        notificacion[1].SetActive(true);
                    }
                }
            }
        }
        else
        {
            // Mostrar panel que no tiene cultivo que cosechar
            notificacion[2].SetActive(true);
        }
    }

    void desactivarOpciones()
    {
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();

        if (fm.selectCrop != null)
        {
            CropObj = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            CropObj.fertilizanteSelec = false;
            CropObj.abonoSelec = false;
            CropObj.insecticidaSelec = false;

            adicionales.btnsAdicionales[0].GetComponent<Image>().sprite = adicionales.deselectImg;
            adicionales.btnsAdicionales[1].GetComponent<Image>().sprite = adicionales.deselectImg;
            adicionales.btnsAdicionales[2].GetComponent<Image>().sprite = adicionales.deselectImg;

            agri.desactivarAgri();

            fm.SelectDeselectCrop(fm.selectCrop);
        }
    }

}
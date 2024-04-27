using System.Collections;
using System.Collections.Generic;
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

        for (int i = 0; i < playerInventory.instance.slots.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i].GetComponent<Item>().item){
                    if(playerInventory.instance.slots[i].GetComponent<Item>().item.nombre == fm.selectCrop.crop.plantName){
                        hasItem = true;
                        ItemPos = i;
                        break;
                    }
                }
            }
        }

        if(fm.isPlanting && hasItem)
        {
            if (adicionales.fertilizanteSelec)
            {
                adicionales.DesactivarFertilizante();
            }

            // Plantar(fm.selectCrop.crop);
            CropObj = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
            CropObj.Plantar(fm.selectCrop.crop,true);
            fm.SelectDeselectCrop(fm.selectCrop);

            playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
            playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
            playerInventory.instance.isFull[ItemPos] = false;
            menu.SetActive(false); // Desactivar menu
        }
    }

    // Cosechar cultivos si ha terminado de crecer
    public void OnClickCosechar()
    {
        CropObj = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
        
        if (CropObj.isPlanted && fm.selectCrop.crop)
        {
            if(CropObj.plantStage == CropObj.selectedCrop.plantStages.Length - 1)
            {   
                CropObj.Cosechar(false);
                
                for(int i = 0;i < playerInventory.instance.slots.Length;i++){
                    if(!playerInventory.instance.isFull[i]){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = CropObj.selectedCrop.itemVenta;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                        fm.SelectDeselectCrop(fm.selectCrop);
                        menu.SetActive(false); // Desactivar menu
                        break;
                    }
                }
            }            
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdicionalesBtn : MonoBehaviour
{
    public bool hasItem = false;

    public bool selected = false;

    CrecimientoParalelo selectedCrop;
    FarmManager fm;


    public Button[] btnsAdicionales;
    public Sprite selectImg;
    public Sprite deselectImg;

    public GameObject[] notificacion;


    // Start is called before the first frame update
    void Start()
    {
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();
    }

    public void OnClickFertilizante()
    {
        // Check if the player has the item in their inventory
        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.isFull[i])
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta)
                {
                    if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Fertilizante")
                    {
                        hasItem = true;
                        break;
                    }
                    else
                    {
                        hasItem = false;
                    }
                }
            }
        }

        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();

        /* if (hasItem)
        {
            if (!selected)
            {
                selected = true;
                btnsAdicionales[0].GetComponent<Image>().sprite = selectImg;

                if (fm.selectCrop == null)
                {
                    fm = GameObject.Find("Canvas").GetComponent<FarmManager>();
                    selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
                    selectedCrop.fertilizanteSelec = selected;
                }
            }
            else
            {
                selected = false;
                btnsAdicionales[0].GetComponent<Image>().sprite = deselectImg;

                if (fm.selectCrop != null)
                {
                    selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
                    selectedCrop.fertilizanteSelec = selected;
                }
            }
        }
        else
        {
            // Show a message to the player
            // Debug.Log("No tienes Fertilizante en tu inventario");
            notificacion[0].SetActive(true);
        } */


        /* if (hasItem)
        {
            if (fm.selectCrop != null)
            {
                selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

                if (!selectedCrop.fertilizanteSelec)
                {
                    selectedCrop.fertilizanteSelec = true;
                    btnsAdicionales[0].GetComponent<Image>().sprite = selectImg;
                }
                else
                {
                    selectedCrop.fertilizanteSelec = false;
                    btnsAdicionales[0].GetComponent<Image>().sprite = deselectImg;
                }
            }
            else if (fm.selectCrop == null)
            {
                // Mostrar panel que no tiene cultivo seleccionado
                notificacion[1].SetActive(true);
            }
        }
        else if (!hasItem)
        {
            if (fm.selectCrop == null)
            {
                // Show a message to the player
                // Debug.Log("No tienes Fertilizante en tu inventario");
                notificacion[0].SetActive(true);
            }
            else
            {
                // Mostrar panel que no tiene cultivo seleccionado
                notificacion[1].SetActive(true);
            }

            // Mostrar panel que no tiene fertilizante
            notificacion[0].SetActive(true);
        } */

        if (fm.selectCrop != null && hasItem)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.fertilizanteSelec)
            {
                selectedCrop.fertilizanteSelec = true;
                btnsAdicionales[0].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.fertilizanteSelec = false;
                btnsAdicionales[0].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else if (fm.selectCrop != null && !hasItem)
        {
            // Mostrar que no tiene item
            notificacion[0].SetActive(true);
        }
        else if (fm.selectCrop == null && hasItem)
        {
            // Mostrar que no tiene cultivo seleccionado
            notificacion[1].SetActive(true);
        }
        else
        {
            // Mostrar que no tiene cultivo seleccionado y no tiene item
            notificacion[0].SetActive(true);
        }


        /* if (fm.selectCrop != null && hasItem)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.fertilizanteSelec)
            {
                selectedCrop.fertilizanteSelec = true;
                btnsAdicionales[0].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.fertilizanteSelec = false;
                btnsAdicionales[0].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else if (fm.selectCrop == null && !hasItem)
        {
            // Show a message to the player
            // Debug.Log("No tienes Fertilizante en tu inventario");
            notificacion[1].SetActive(true);
        }
        else
        {
            // Mostrar panel que no tiene fertilizante
            notificacion[0].SetActive(true);
        } */
    }

    public void OnClickAbono()
    {
        // Check if the player has the item in their inventory
        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.isFull[i])
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta)
                {
                    if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Abono")
                    {
                        hasItem = true;
                        break;
                    }
                    else
                    {
                        hasItem = false;
                    }
                }
            }
        }

        if (fm.selectCrop != null && hasItem)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.abonoSelec)
            {
                selectedCrop.abonoSelec = true;
                btnsAdicionales[1].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.abonoSelec = false;
                btnsAdicionales[1].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else if (fm.selectCrop != null && !hasItem)
        {
            // Mostrar que no tiene item
            notificacion[0].SetActive(true);
        }
        else if (fm.selectCrop == null && hasItem)
        {
            // Mostrar que no tiene cultivo seleccionado
            notificacion[1].SetActive(true);
        }
        else
        {
            // Mostrar que no tiene cultivo seleccionado y no tiene item
            notificacion[0].SetActive(true);
        }

    }

    public void OnClickInsecticida()
    {
        // Check if the player has the item in their inventory
        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.isFull[i])
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta)
                {
                    if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Insecticida")
                    {
                        hasItem = true;
                        break;
                    }
                    else{
                        hasItem = false;
                    }
                }
            }
        }

        if (fm.selectCrop != null && hasItem)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();

            if (!selectedCrop.insecticidaSelec)
            {
                selectedCrop.insecticidaSelec = true;
                btnsAdicionales[2].GetComponent<Image>().sprite = selectImg;
            }
            else
            {
                selectedCrop.insecticidaSelec = false;
                btnsAdicionales[2].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else if (fm.selectCrop != null && !hasItem)
        {
            // Mostrar que no tiene item
            notificacion[0].SetActive(true);
        }
        else if (fm.selectCrop == null && hasItem)
        {
            // Mostrar que no tiene cultivo seleccionado
            notificacion[1].SetActive(true);
        }
        else
        {
            // Mostrar que no tiene cultivo seleccionado y no tiene item
            notificacion[0].SetActive(true);
        }
    }

    public void DesactivarFertilizante()
    {
        // fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Fertilizante");

        hasItem = false;
        playerInventory.instance.slots[ItemPos].GetComponent<Item>().itemVenta = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;

    }

    public void DesactivarAbono()
    {
        // fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Abono");
        
        hasItem = false;
        playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;

    }

    public void DesactivarInsecticida()
    {
        // fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Insecticida");

        hasItem = false;
        playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;
    }

    public void desactivarOpciones()
    {
        foreach (var btnAdicional in btnsAdicionales)
        {
            btnAdicional.GetComponent<Image>().sprite = deselectImg;
        }
    }

    int FindItemPosition(string itemName)
    {
        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.isFull[i])
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta)
                {
                    if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == itemName)
                    {
                        return i;
                    }
                }
            }
        }
        return 0;
    }
}

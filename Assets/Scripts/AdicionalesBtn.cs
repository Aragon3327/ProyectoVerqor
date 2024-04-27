using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdicionalesBtn : MonoBehaviour
{
    public bool fertilizanteSelec = false;
    public bool abonoSelec = false;
    public bool insecticidaSelec = false;


    public Button[] btnsAdicionales;
    public Sprite selectImg;
    public Sprite deselectImg;

    public GameObject notificacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickFertilizante(){
        // Check if the player has the item in their inventory
        bool hasItem = false;

        // tiempoCrecimientoOriginal = crecimiento.timer;

        for (int i = 0; i < playerInventory.instance.slots.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta){
                    if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Fertilizante"){
                        hasItem = true;
                        break;
                    }
                }
            }
        }

        if (hasItem)
        {
            if (!fertilizanteSelec){
                fertilizanteSelec = true;
                btnsAdicionales[0].GetComponent<Image>().sprite = selectImg;
            }
            else{
                fertilizanteSelec = false;
                btnsAdicionales[0].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else{
            // Show a message to the player
            Debug.Log("No tienes Fertilizante en tu inventario");
            notificacion.SetActive(true);
        }
    }

    public void OnClickAbono()
    {
        // Check if the player has the item in their inventory
        bool hasItem = false;

        // tiempoCrecimientoOriginal = crecimiento.timer;

        for (int i = 0; i < playerInventory.instance.slots.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta){
                    if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Abono"){
                        hasItem = true;
                        break;
                    }
                }
            }
        }

        if (hasItem)
        {
            if (!abonoSelec){
                abonoSelec = true;
                btnsAdicionales[1].GetComponent<Image>().sprite = selectImg;
            }
            else{
                abonoSelec = false;
                btnsAdicionales[1].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else{
            // Show a message to the player
            Debug.Log("No tienes Abono en tu inventario");
            notificacion.SetActive(true);
        }

    }

    public void OnClickPesticida()
    {
        // Check if the player has the item in their inventory
        bool hasItem = false;

        // tiempoCrecimientoOriginal = crecimiento.timer;

        for (int i = 0; i < playerInventory.instance.slots.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta){
                    if(playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == "Insecticida"){
                        hasItem = true;
                        break;
                    }
                }
            }
        }

        if (hasItem)
        {
            if (!insecticidaSelec){
                insecticidaSelec = true;
                btnsAdicionales[2].GetComponent<Image>().sprite = selectImg;
            }
            else{
                insecticidaSelec = false;
                btnsAdicionales[2].GetComponent<Image>().sprite = deselectImg;
            }
        }
        else{
            // Show a message to the player
            Debug.Log("No tienes Pesticida en tu inventario");
            notificacion.SetActive(true);
        }
    }

    /* public void OnDeselectFertilizante(){
        crecimiento.timer = tiempoCrecimientoOriginal;
    } */

    public void DesactivarFertilizante()
    {
        fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Fertilizante");

        playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;
        
    }

    public void DesactivarAbono()
    {
        // fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Abono");

        playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;
        
    }

    public void DesactivarPesticida()
    {
        // fertilizanteSelec = false;
        // crecimiento.timer = timerOriginal;

        int ItemPos = FindItemPosition("Pesticida");

        playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
        playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
        playerInventory.instance.isFull[ItemPos] = false;
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

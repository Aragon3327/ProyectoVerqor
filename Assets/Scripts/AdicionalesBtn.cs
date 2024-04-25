using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionalesBtn : MonoBehaviour
{
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
        int ItemPos = 0;

        for (int i = 0; i < playerInventory.instance.slots.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i].GetComponent<Item>().item){
                    if(playerInventory.instance.slots[i].GetComponent<Item>().item.nombre == "Fertilizante"){
                        hasItem = true;
                        ItemPos = i;
                        break;
                    }
                }
            }
        }

        if (hasItem){
            // Use the item
            // playerInventory.instance.slots[ItemPos].GetComponent<Item>().item = null;
            // playerInventory.instance.slots[ItemPos].GetComponent<Image>().enabled = false;
            // playerInventory.instance.isFull[ItemPos] = false;
            // menu.SetActive(false); // Desactivar menu
        }
        else{
            // Show a message to the player
            Debug.Log("No tienes Fertilizante en tu inventario");
        }
    }

    public void OnClickAbono(){

    }

    public void OnClickPesticida(){

    }
}

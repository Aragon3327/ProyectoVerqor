using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Microsoft.Unity.VisualStudio.Editor;

public class TiendButton : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemTiendaObjt item;

    public void btnAccion(){
        gameObject.GetComponent<TiendButton>().OnTiendaButtonClick();
    }

    public void OnTiendaButtonClick(){

        if(playerStats.instance.ganancia >= item.precio){
            for(int i = 0; i < playerInventory.instance.slots.Length;i++){
                if(!playerInventory.instance.isFull[i]){
                    playerInventory.instance.slots[i].GetComponent<Item>().item = item;
                    playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                    playerInventory.instance.isFull[i] = true;
                    playerStats.instance.ganancia -= item.precio;
                    break;
                }
            }
        }

    }

}

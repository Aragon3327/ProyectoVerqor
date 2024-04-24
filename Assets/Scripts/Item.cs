using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemTiendaObjt item;
    public ItemVenta itemVenta;

    public void UpdateItem(){
        this.gameObject.GetComponent<Image>().sprite = item.sprite;
        this.gameObject.GetComponent<Image>().enabled = true;
    }

    public void UpdateVenta(){
        this.gameObject.GetComponent<Image>().sprite = itemVenta.sprite;
        this.gameObject.GetComponent<Image>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CosechaBtn : MonoBehaviour
{
    public ItemVenta itemV;
    private TMP_Text precioText;

    private void Awake()
    {
        precioText = transform.GetChild(0).GetComponent<TMP_Text>();
        precioText.text = "$" + itemV.precioInc.ToString();
    }

    public void vendeCosecha()
    {
        for (int i = 0; i < playerInventory.instance.slots.Length; i++)
        {
            if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta)
            {
                if (playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.nombre == itemV.nombre)
                {
                    playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = null;
                    playerInventory.instance.slots[i].GetComponent<Image>().enabled = false;
                    playerStats.instance.ganancia += itemV.precioInc;
                }
            }
        }
    }
}

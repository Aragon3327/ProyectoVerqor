using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VentaBtn : MonoBehaviour
{
    public ItemVenta itemV;
    private TMP_Text precioText;


    private void Awake()
    {
        precioText = transform.GetChild(0).GetComponent<TMP_Text>();
        precioText.text = "$" + itemV.precioInicial.ToString();
    }

    void Update()
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

                    // playerStats.instance.ganancia += itemV.precioInc;

                    if (!itemV.abono && !itemV.regenerativa)
                    {
                        playerStats.instance.ganancia += itemV.precioInc;
                    }
                    else if (itemV.abono || itemV.regenerativa)
                    {
                        
                        playerStats.instance.ganancia += itemV.precioInc;
                        
                        if (itemV.abono)
                        {
                            playerStats.instance.ganancia += itemV.precioAbono;
                            
                            itemV.precioAbono = 0;
                            itemV.abono = false;
                        }

                        if (itemV.regenerativa)
                        {
                            playerStats.instance.ganancia += itemV.precioReg;
                            
                            itemV.precioReg = 0;
                            itemV.regenerativa = false;
                        }
                    }

                    playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = null;
                    playerInventory.instance.slots[i].GetComponent<Image>().enabled = false;
                    playerInventory.instance.isFull[i] = false;
                }
            }
        }
    }

}
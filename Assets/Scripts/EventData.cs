using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventData : ScriptableObject
{
    public string eventName;  // Talvez no sea necesario
    public Sprite eventTypeImg;
    public string descripcion;
    public Sprite eventoImg;
    public int cantidad;


    public string eventType;
    public string seguroAplicable;
    public float ganancia;
    public float perdida;
    public float perdidaSeguro;

    public void ApplyEvent(HUDScript seguro)
    {
        if (eventType == "Bueno"){
            ApplyGoodEvent();
        }
        else if (eventType == "Malo"){
            ApplyBadEvent(seguro);
        }
    }

    public void ApplyGoodEvent()
    {
        cantidad = (int)(playerStats.instance.ganancia * ganancia);
        playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * ganancia);
    }

    public void ApplyBadEvent(HUDScript seguro)
    {
        if(seguroAplicable == "Banco" && seguro.seguroBancoUsado)
        {    
            cantidad = (int)(playerStats.instance.ganancia * perdidaSeguro);
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * perdidaSeguro);
            //descripcion += " - Default Text for Banco"; Anda agregando cada rato y no lo se quitarlos :/
        }
        else if(seguroAplicable == "Coyote" && seguro.seguroCoyoteUsado)
        {
            cantidad = (int)(playerStats.instance.ganancia * perdidaSeguro);
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * perdidaSeguro);
            // descripcion += " - Default Text for Coyote";
        }
        else if(seguroAplicable == "Verqor" && seguro.seguroVerqorUsado)
        {
            cantidad = (int)(playerStats.instance.ganancia * perdidaSeguro);
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * perdidaSeguro);
            // descripcion += " - Default Text for Verqor";
        }
        else
        {
            cantidad = (int)(playerStats.instance.ganancia * perdida);
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * perdida);
        }
    }
}
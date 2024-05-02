using System;
using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject panelEvento;
    public TMPro.TextMeshProUGUI[] eventos;
    public GameObject[] tipoEvento;
    public HUDScript seguro;
    public WeatherSystem clima;

    //public playerStats ganancia;


    void Start()
    {
        Invoke("DisableEvents", 3f);
    }

    public void ChangeEvent()
    {
        int randomEvent = UnityEngine.Random.Range(0, eventos.Length);
        
        //panelEvento.SetActive(true);

        //eventos[randomEvent].gameObject.SetActive(true);

        // Si tiene seguro Coyote se desactiva el evento de asalto
        if (randomEvent == 0){
            //Agrega el 10% de la ganancia
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.1);
        }
        else if (randomEvent == 1)
        {
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.2);
        }
        else if (randomEvent == 2)
        {
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.05);
        }
        else if (randomEvent == 3)
        {
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.07);
        }
        else if (randomEvent == 4)
        {
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.08);
        }
        else if (randomEvent == 5)
        {
            playerStats.instance.ganancia += (int)(playerStats.instance.ganancia * 0.13);
        }
        else if (randomEvent == 6)
        {
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.12);
        }
        else if (randomEvent == 7)
        {
            if(clima.currentWeather != WeatherSystem.WeatherType.inundacion){
                if(seguro.seguroVerqorUsado)
                {
                    playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.02);
                }
                else
                {
                    playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.2);
                }
            }
            else{
                randomEvent = 10;
                Debug.Log("Evento de incendio desactivado por evento de inundación");
            }
        }
        else if (randomEvent == 8)
        {
            if(seguro.seguroCoyoteUsado)
            {
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.05);
            }
            else
            {
                playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.2);
            }
        }
        else if (randomEvent == 9)
        {
            if(seguro.seguroBancoUsado)
            {
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.03);
            }
            else
            {
                playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.07);
            }
        }
        else if (randomEvent == 10)
        {
            if(seguro.seguroBancoUsado)
            {
            playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.01);
            }
            else
            {
                playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.05);
            }
        }
        else if (randomEvent == 11)
        {
            if(clima.currentWeather != WeatherSystem.WeatherType.sequia){
                if(seguro.seguroVerqorUsado)
                {
                    playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.02);
                }
                else
                {
                    playerStats.instance.ganancia -= (int)(playerStats.instance.ganancia * 0.2);
                }
            }
            else{
                randomEvent = 7;
                Debug.Log("Evento de Helada desactivado por evento de inundación");
            }
        }
        


        /*if (seguro.seguroCoyoteUsado && randomEvent == 8)
        {
            panelEvento.SetActive(false);
        }
        // Si tiene seguro Tradicional se desactiva el evento de incendio y helada
        else if(seguro.seguroUsado && (randomEvent == 7 || randomEvent == 11))
        {
            panelEvento.SetActive(false);
        }
        else if(seguro.seguroBancoUsado && (randomEvent == 9 || randomEvent == 10))
        {
            panelEvento.SetActive(false);
        }*/
        panelEvento.SetActive(true);
        eventos[randomEvent].gameObject.SetActive(true);
        if (randomEvent >= 0 && randomEvent <= 5)
        {
            tipoEvento[0].SetActive(true);
        }
        else if (randomEvent >= 6 && randomEvent <= 11)
        {
            tipoEvento[1].SetActive(true);
        }
        Invoke("DisableEvents", 3f);       

        
    }

    void DisableEvents()
    {
        panelEvento.SetActive(false);

        foreach (var tipo in tipoEvento)
        {
            tipo.SetActive(false);
        }

        foreach (var evento in eventos)
        {
            evento.gameObject.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class WeatherSystem : MonoBehaviour
{
    public UnityEngine.UI.Image sol;
    public UnityEngine.UI.Image lluvia;    
    public UnityEngine.UI.Image nube;
    //Declarar una variable para una animacion de lluvia
    public GameObject AnimRain;
    public UnityEngine.UI.Image oscuro;
    public UnityEngine.UI.Image claro;

    public static WeatherSystem instance;

    public enum WeatherType
    {
        sequia,
        inundacion,
        buenClima,
    }
    public WeatherType currentWeather;

    /* void Start()
    {
        //llamar a la funcion ChangeWeather cada 10 segundos
        //InvokeRepeating("ChangeWeather", 0, 10);
        //ChangeWeather();
    } */

    private void Awake()
    {
        instance = this;
    }

    public void ChangeWeather()
    {
        int randomWeather = UnityEngine.Random.Range(0, 3);
        currentWeather = (WeatherType)randomWeather;
        sol.enabled = false;
        lluvia.enabled = false;
        nube.enabled = false;
        oscuro.enabled = false;
        claro.enabled = false;
        //No se muestra en la pantalla la animacion de lluvia
        AnimRain.SetActive(false);


        switch (currentWeather)
        {
            case WeatherType.sequia:
                // imprimir en consola el clima actual
                // Debug.Log("El clima es soleado");
                sol.enabled = true;
                break;
            case WeatherType.inundacion:
                // Debug.Log("El clima es lluvioso");
                lluvia.enabled = true;
                oscuro.enabled = true;
                AnimRain.SetActive(true);
                break;
            case WeatherType.buenClima:
                // Debug.Log("El clima es nublado");
                nube.enabled = true;
                claro.enabled = true;
                break;
        }
    }
}

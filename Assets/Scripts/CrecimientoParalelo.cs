using System;
using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;

public class CrecimientoParalelo : MonoBehaviour
{

    public bool isPlanted = false;
    public SpriteRenderer plant;
    
    public int plantStage = 0;
    public float timer;

    public bool fertilizanteSelec = false;
    public bool abonoSelec = false;
    public bool insecticidaSelec = false;

    public bool agriRegenerativa = false;
    public bool agriTradicional = false;

    public CropObject selectedCrop;

    public WeatherSystem clima;
    

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            
            if (timer < 0 && plantStage < selectedCrop.plantStages.Length - 1)
            {
                timer = selectedCrop.timeBtwStages;

                timeByWeather();                

                if (fertilizanteSelec)
                {
                    // Restar tiempo de cosecha
                    timer /= 2;
                }

                if (agriTradicional)
                {
                    // Aumentar tiempo de cosecha
                    timer += 5;
                }

                plantStage++;
                ActualizarPlanta();                
            }
        }
    }
    
    public void Plantar(CropObject newCrop,bool isPlanted)
    {
        selectedCrop = newCrop;
        plant = selectedCrop.plantRender;
        this.isPlanted = isPlanted;        
        plantStage = 0;
        ActualizarPlanta();
        plant.enabled = true;
        timer = selectedCrop.timeBtwStages;

        timeByWeather();

        if (fertilizanteSelec)
        {
            // Restar tiempo de cosecha
            timer /= 2;            
        }

        if (agriTradicional)
        {
            // Aumentar tiempo de cosecha
            timer += 5;
        }

    }

    public void Cosechar(bool isPlanted)
    {
        this.isPlanted = isPlanted;
        plant.enabled = false;

    }
    void ActualizarPlanta()
    {
        plant.sprite = selectedCrop.plantStages[plantStage];
    }

    void timeByWeather()
    {
        if (clima.currentWeather == WeatherSystem.WeatherType.sequia)
        {
            // Reducir el tiempo entre etapas de crecimiento
            // timer = selectedCrop.timeSlowed;
            timer = selectedCrop.timeBtwStages * 2;

        }
        else if (clima.currentWeather == WeatherSystem.WeatherType.inundacion)
        {
            // Aumentar el tiempo entre etapas de crecimiento
            // timer = selectedCrop.timeSpeedUp;
            timer = selectedCrop.timeBtwStages / 4;
        }
        else
        {
            timer = selectedCrop.timeBtwStages;
        }
    }

}

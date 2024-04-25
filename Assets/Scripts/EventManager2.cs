using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager2 : MonoBehaviour
{
    public GameObject[] eventosPrefabs;
    public Transform eventPanelParent;
    public HUDScript seguro;
    public WeatherSystem clima;
    private EventData eventData;


    // Start is called before the first frame update
    void Start()
    {
        // Invoke("DisableEvents", 3f);
    }

    public void ChangeEvent()
    {
        // Selecciona un evento aleatorio
        int randomEventIndex = Random.Range(0, eventosPrefabs.Length);
        // int randomEventIndex = 8;
        GameObject randomPrefab = eventosPrefabs[randomEventIndex];

        eventPanelParent.gameObject.SetActive(true);       

        // Si el clima es inundacion y el evento es un Incendio, cambiar a evento de DanioHogar
        if(clima.currentWeather == WeatherSystem.WeatherType.inundacion && randomEventIndex == 7)
        {

            eventData = eventosPrefabs[10].GetComponent<EventPanel>().evento;
            
            eventosPrefabs[10].SetActive(true);
        }
        // Si el clima es sequia y el evento es una Helada, cambiar a evento de Incendio
        else if (clima.currentWeather == WeatherSystem.WeatherType.sequia && randomEventIndex == 11)
        {
            eventData = eventosPrefabs[7].GetComponent<EventPanel>().evento;
            
            eventosPrefabs[7].SetActive(true);
        }
        else
        {
            eventData = randomPrefab.GetComponent<EventPanel>().evento;
            eventosPrefabs[randomEventIndex].SetActive(true);
        }

        eventData.ApplyEvent(seguro);

        Time.timeScale = 0;

        // Invoke("DisableEvents", 3f);
    }

    public void OnClickEntendido()
    {
        Time.timeScale = 1;

        eventPanelParent.gameObject.SetActive(false);
        
        // Desactivar todas los eventosPrefabs
        foreach (GameObject evento in eventosPrefabs)
        {
            evento.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proximity : MonoBehaviour
{
    private bool isPlayerInRange;
    [SerializeField] private GameObject MenuCart;

    // public GameObject panelCultivo;

    // public GameObject panelAdicionales;

    public GameObject[] notificacion;

    FarmManager fm;
    CrecimientoParalelo selectedCrop;

    void Update()
    {        
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!MenuCart.activeSelf)
            {
                MenuCart.SetActive(true);
                // panelCultivo.SetActive(true);
            }
            else
            {
                // MenuCart.SetActive(false);
                OnSalirbuttonClicked();
            }
        }

    }
    //activar signo de E
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    //desactivar signo de E

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            if (MenuCart.activeSelf)
            {
                // MenuCart.SetActive(false); // Cerrar el menú si el jugador sale del rango mientras está abierto
                // panelAdicionales.SetActive(false);
                
                OnSalirbuttonClicked();
            }
        }
    }

    /* public void OnClickSiguiente()
    {
        panelCultivo.SetActive(false);
        panelAdicionales.SetActive(true);
    } */
    public void OnSalirbuttonClicked()
    {
        MenuCart.SetActive(false);
        // panelAdicionales.SetActive(false);
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();

        if(fm.selectCrop != null)
        {
            selectedCrop = GameObject.Find(fm.selectCrop.crop.plantName).GetComponent<CrecimientoParalelo>();
            selectedCrop.fertilizanteSelec = false;

            fm.selectCrop = null;
            fm.isPlanting = false;
        }
    }

    public void OnClickEntendido()
    {
        foreach (GameObject notificacion in notificacion)
        {
            notificacion.SetActive(false);
        }
    }
}

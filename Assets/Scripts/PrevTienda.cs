using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSalirT : MonoBehaviour
{
    private bool isPlayerInRange;
    [SerializeField] private GameObject tiendaObject;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!tiendaObject.activeSelf){
                tiendaObject.SetActive(true);
            } else{
                tiendaObject.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            if (tiendaObject.activeSelf)
            {
                tiendaObject.SetActive(false);
            }
        }
    }


    public void OnSalirbuttonClicked()
    {
        tiendaObject.SetActive(false);
    }
}
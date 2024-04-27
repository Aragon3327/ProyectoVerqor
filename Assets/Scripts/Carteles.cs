using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proximity : MonoBehaviour
{
    private bool isPlayerInRange;
    [SerializeField] private GameObject MenuCart;

    public GameObject notificacion;

    void Update()
    {        
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!MenuCart.activeSelf)
            {
                MenuCart.SetActive(true);
            }
            else
            {
                MenuCart.SetActive(false);
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
                MenuCart.SetActive(false); // Cerrar el menú si el jugador sale del rango mientras está abierto
            }
        }
    }
    public void OnSalirbuttonClicked()
    {
        MenuCart.SetActive(false);
    }

    public void OnClickEntendido()
    {
        notificacion.SetActive(false);
    }
}

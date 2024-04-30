using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausado : MonoBehaviour
{
    //Referecia al panel de pausa
    public GameObject panelPausa;

    public bool estaPausado = false;

    //Funcion para pausar el juego
    public void Pausar()
    {
        //Cambiar el estado del juego
        estaPausado = !estaPausado;
        //Activar o desactivar el panel de pausa
        panelPausa.SetActive(estaPausado);
        //Detener o reanudar las actualizaciones del juego
        Time.timeScale = (estaPausado) ? 0 : 1;
    }



}

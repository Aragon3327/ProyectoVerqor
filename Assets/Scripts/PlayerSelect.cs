using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    public CinemachineVirtualCamera Vcamera;
    public Guardado guardado;

    private void Awake(){
        if(PlayerPrefs.GetString("GeneroUsuario") == "H"){
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Vcamera.Follow = this.gameObject.transform.GetChild(0);
            // guardado.jugador = this.gameObject.transform.GetChild(0).gameObject;
        }else{
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Vcamera.Follow = this.gameObject.transform.GetChild(1);
            // guardado.jugador = this.gameObject.transform.GetChild(1).gameObject;
        }
    }
}

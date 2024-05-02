using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GetPartida : MonoBehaviour
{
    public TMP_Text InicioBtn;

    public CargaPartida partida;

    private void Awake(){
        partida = GameObject.Find("Partida").GetComponent<CargaPartida>();
        if(partida != null){
            InicioBtn.SetText("Continuar");
        }
    }

    public void CambioEscena(){
        if(partida != null){
            SceneManager.LoadScene("Modificado");
        }else{
            SceneManager.LoadScene("Story");
        }
    }

}

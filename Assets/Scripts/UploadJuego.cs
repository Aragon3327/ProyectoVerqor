using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UploadJuego : MonoBehaviour
{

    private struct Estadisticas{
        public string idUsuario;
        public int TotalGanado;
        public string Prestador;
        public int Adeudo;
        public int Desastres;
        public int Fortuna;
    }
    public void EnviarJson(){
        //Enviar el Json al servidor
        StartCoroutine(EnviarRecibirJson());
    }

    private IEnumerator EnviarRecibirJson(){

        Estadisticas datos;

        datos.idUsuario = PlayerPrefs.GetString("IdUsuario");
        datos.TotalGanado = playerStats.instance.ganancia - playerStats.instance.deuda;
        datos.Prestador = HUDScript.instance.financiamiento;
        // datos.Cultivos = 
        datos.Adeudo = playerStats.instance.deuda;
        datos.Desastres = EventManager2.instance.desastres;
        datos.Fortuna = EventManager2.instance.fortunas;

        string datosJSON = JsonUtility.ToJson(datos); 
        print("JSON enviado: " + datosJSON);

        UnityWebRequest request = UnityWebRequest.Post("http://44.221.109.63:8080/unity/registroJuego", datosJSON, "application/json");
        yield return request.SendWebRequest();

    }
}

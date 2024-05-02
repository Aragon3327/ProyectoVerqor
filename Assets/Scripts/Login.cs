using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; //Para usar unityWebRequest
using TMPro; //Para usar TextMeshPro

public class Login : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField ifNumber;
    [SerializeField]
    public TMP_InputField ifPassword;
    public GameObject ErrorText;

    public GameObject LoginPanel;
    public GameObject ChoosePanel;

    public GameObject Partida;


    private struct Usuario{
        public string number;
        public string password;
    }

    public void EnviarJson(){
        //Enviar el Json al servidor
        StartCoroutine(EnviarRecibirJson());
    }

    private IEnumerator EnviarRecibirJson(){
        Usuario datos;
        datos.number = ifNumber.text;
        datos.password = ifPassword.text;

        string datosJSON = JsonUtility.ToJson(datos); 
        print("JSON enviado: " + datosJSON);

        UnityWebRequest request = UnityWebRequest.Post("http://44.221.109.63:8080/unity/login", datosJSON, "application/json");
        yield return request.SendWebRequest();

        Debug.Log(request.result);

        if (request.result == UnityWebRequest.Result.Success) {
            string respuesta = request.downloadHandler.text;
            if(respuesta.Contains("time")){    
                Debug.Log("Respuesta: " + respuesta);
                CargaPartida.instance.UpdatePartida(respuesta);
                DontDestroyOnLoad(Partida);
            }else{
                PlayerPrefs.SetString("IdUsuario",respuesta);
            }
            ChoosePanel.SetActive(true);
            LoginPanel.SetActive(false);
        }
        else
        {
            ErrorText.SetActive(true);
        }   
    }

}

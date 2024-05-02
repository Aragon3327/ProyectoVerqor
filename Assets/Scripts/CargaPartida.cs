using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Purchasing.MiniJSON;

public class CargaPartida : MonoBehaviour
{
    public PartidaData partidaData = new PartidaData();
    private struct Inventario{
        public string uno;
        public string dos;
        public string tres;
        public string cuatro;
        public string cinco;
        public string seis;
        public string siete;
        public string ocho;
        public string nueve;
    }
    
    [SerializeField]
    public struct PartidaData{
        public string IdUsuario;
        public float time;
        public string finan;
        public string seg1;
        public string seg2;
        public int deuda;
        public int dinero;
        public string cult;
        public string aditivos;
        public int ciclo;
        public string inventario;
    }

    public static CargaPartida instance;

    private void Awake(){
        instance = this;
    }

    public void UpdatePartida(string json){
        partidaData = JsonUtility.FromJson<PartidaData>(json);
        PlayerPrefs.SetString("IdUsuario",partidaData.IdUsuario);
    }

}

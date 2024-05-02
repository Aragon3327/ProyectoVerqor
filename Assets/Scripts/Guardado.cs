using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Guardado : MonoBehaviour
{
    public GameObject[] cultivos;
    public GameObject jugador;
    private struct PartidaUsuario{
        public string id;
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

    private struct Cultivos
    {
        public int C;
        public int M;
        public int J;
        public int Cb;
        public int L;
        public int Z;

        public override string ToString()
    {
        return "{"+$"C:{C}, M:{M}, J:{J}, Cb:{Cb}, L:{L}, Z:{Z}"+"}";
    }

    }

    private struct Aditivos
    {
        public string C;
        public string M;
        public string J;
        public string Cb;
        public string L;
        public string Z;

        public override string ToString()
    {
        return "{"+$"C:{C}, M:{M}, J:{J}, Cb:{Cb}, L:{L}, Z:{Z}"+"}";
    }

    }

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

    public void EnviarJson(){
        //Enviar el Json al servidor
        StartCoroutine(EnviarJSON());
    }

    private IEnumerator EnviarJSON(){
        
        Cultivos cultivosPartida = new Cultivos();
        Aditivos aditivosPartida = new Aditivos();
        Inventario inventarioPartida = new Inventario();

        PartidaUsuario datos;
        datos.id = PlayerPrefs.GetString("IdUsuario");
        datos.time = HUDScript.instance.tiempoCiclo;
        datos.finan = HUDScript.instance.financiamiento;
        datos.seg1 = HUDScript.instance.seguro1;
        datos.seg2 = HUDScript.instance.seguro2;
        datos.deuda = playerStats.instance.deuda;
        datos.dinero = playerStats.instance.ganancia;

        for(int i = 0; i < cultivos.Length;i++){
            CrecimientoParalelo cultivo = cultivos[i].GetComponent<CrecimientoParalelo>();
            if(cultivos[i].name == "Chile"){
                if(cultivo.isPlanted){cultivosPartida.C = cultivo.plantStage;}
                else{cultivosPartida.C = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.C = result;
            }
            if(cultivos[i].name == "Maiz"){
                if(cultivo.isPlanted){cultivosPartida.M = cultivo.plantStage;}
                else{cultivosPartida.M = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.M = result;
            }
            if(cultivos[i].name == "Jitomate"){
                if(cultivo.isPlanted){cultivosPartida.J = cultivo.plantStage;}
                else{cultivosPartida.J = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.J = result;
            }
            if(cultivos[i].name == "Cebada"){
                if(cultivo.isPlanted){cultivosPartida.Cb = cultivo.plantStage;}
                else{cultivosPartida.Cb = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.Cb = result;
            }
            if(cultivos[i].name == "Lechuga"){
                if(cultivo.isPlanted){cultivosPartida.L = cultivo.plantStage;}
                else{cultivosPartida.L = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.L = result;
            }
            if(cultivos[i].name == "Zanahoria"){
                if(cultivo.isPlanted){cultivosPartida.Z = cultivo.plantStage;}
                else{cultivosPartida.Z = -1;}
                string result = "";
                if(cultivo.fertilizanteSelec){result+="F";}
                if(cultivo.abonoSelec){result+="A";}
                if(cultivo.insecticidaSelec){result+="I";}
                if(cultivo.agriRegenerativa){result+="R";}
                if(cultivo.fertilizanteSelec){result+="T";}
                aditivosPartida.Z = result;
            }
        }

        datos.cult = JsonUtility.ToJson(cultivosPartida);
        datos.aditivos = JsonUtility.ToJson(aditivosPartida);
        datos.ciclo = HUDScript.instance.numCiclos;

        for(int i = 0; i < playerInventory.instance.isFull.Length;i++){
            if(playerInventory.instance.isFull[i]){
                if(playerInventory.instance.slots[i]){
                    Item item = playerInventory.instance.slots[i].GetComponent<Item>();
                    if(item.itemVenta){
                        string resultado = "V";
                        resultado += item.itemVenta.nombre;
                        if(item.itemVenta.abono){resultado+="Abono";}
                        if(item.itemVenta.regenerativa){resultado+="Regenerativa";}
                        if(item.itemVenta.insecticida){resultado+="Insecticida";}
                        switch(i){
                            case 0:
                                inventarioPartida.uno = resultado;
                                break;
                            case 1:
                                inventarioPartida.dos = resultado;
                                break;
                            case 2:
                                inventarioPartida.tres = resultado;
                                break;
                            case 3:
                                inventarioPartida.cuatro = resultado;
                                break;
                            case 4:
                                inventarioPartida.cinco = resultado;
                                break;
                            case 5:
                                inventarioPartida.seis = resultado;
                                break;
                            case 6:
                                inventarioPartida.siete = resultado;
                                break;
                            case 7:
                                inventarioPartida.ocho = resultado;
                                break;
                            case 8:
                                inventarioPartida.nueve = resultado;
                                break;
                        }

                    }else{
                        string resultado = "";
                        resultado += item.item.nombre;
                        switch(i){
                            case 0:
                                inventarioPartida.uno = resultado;
                                break;
                            case 1:
                                inventarioPartida.dos = resultado;
                                break;
                            case 2:
                                inventarioPartida.tres = resultado;
                                break;
                            case 3:
                                inventarioPartida.cuatro = resultado;
                                break;
                            case 4:
                                inventarioPartida.cinco = resultado;
                                break;
                            case 5:
                                inventarioPartida.seis = resultado;
                                break;
                            case 6:
                                inventarioPartida.siete = resultado;
                                break;
                            case 7:
                                inventarioPartida.ocho = resultado;
                                break;
                            case 8:
                                inventarioPartida.nueve = resultado;
                                break;
                        }
                    }
                }
            }
        }
        
        datos.inventario = JsonUtility.ToJson(inventarioPartida);

        string datosJSON = JsonUtility.ToJson(datos); 
        print("JSON enviado: " + datosJSON);

        UnityWebRequest request = UnityWebRequest.Post("http://44.221.109.63:8080/unity/guardado", datosJSON, "application/json");
        yield return request.SendWebRequest();

    }
    
}

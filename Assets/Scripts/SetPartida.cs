using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPartida : MonoBehaviour
{

    public ItemVenta VJitomate;
    public ItemVenta VChile;
    public ItemVenta VMaiz;
    public ItemVenta VCebada;
    public ItemVenta VLechuga;
    public ItemVenta VZanahoria;
    public ItemVenta VAbono;
    public ItemVenta VFertilizante;
    public ItemVenta VInsecticida;

    public ItemTiendaObjt TJitomate;
    public ItemTiendaObjt TChile;
    public ItemTiendaObjt TMaiz;
    public ItemTiendaObjt TCebada;
    public ItemTiendaObjt TLechuga;
    public ItemTiendaObjt TZanahoria;

    public CropObject chile;
    public CropObject maiz;
    public CropObject jitomate;
    public CropObject cebada;
    public CropObject lechuga;
    public CropObject zanahoria;

    public Cultivos cultivosPartida = new Cultivos();
    public Aditivos aditivosPartida = new Aditivos();
    public Inventario inventarioPartida = new Inventario();
    public struct Cultivos
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

    public struct Aditivos
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

    public struct Inventario {
    public string uno;
    public string dos;
    public string tres;
    public string cuatro;
    public string cinco;
    public string seis;
    public string siete;
    public string ocho;
    public string nueve;

    public string this[int index] {
        get {
            switch (index) {
                case 0: return uno;
                case 1: return dos;
                case 2: return tres;
                case 3: return cuatro;
                case 4: return cinco;
                case 5: return seis;
                case 6: return siete;
                case 7: return ocho;
                case 8: return nueve;
                default: return "";
            }
        }
        set {
            switch (index) {
                case 0: uno = value; break;
                case 1: dos = value; break;
                case 2: tres = value; break;
                case 3: cuatro = value; break;
                case 4: cinco = value; break;
                case 5: seis = value; break;
                case 6: siete = value; break;
                case 7: ocho = value; break;
                case 8: nueve = value; break;
            }
        }
    }
}

    public CargaPartida partida;
    public GameObject[] cultivos;

    public GameObject Ver;
    public GameObject Coy;
    public GameObject Ban;

    private void Awake(){
        partida = GameObject.Find("Partida").GetComponent<CargaPartida>();
        if(partida != null){
            playerStats.instance.deuda = partida.partidaData.deuda;
            playerStats.instance.ganancia = partida.partidaData.dinero;
            HUDScript.instance.tiempoCiclo = partida.partidaData.time;
            Debug.Log("Financiamiento "+partida.partidaData.finan);
            switch(partida.partidaData.finan){
                case "Verqor":
                    HUDScript.instance.Ver.enabled = true;
                    HUDScript.instance.financiamiento ="Verqor";
                    HUDScript.instance.prestamoUsado = true;
                    break;
                case "Banco":
                    HUDScript.instance.Ban.enabled = true;
                    HUDScript.instance.financiamiento ="Banco";
                    HUDScript.instance.prestamoUsado = true;
                    break;
                case "Coyote":
                    HUDScript.instance.Coy.enabled = true;
                    HUDScript.instance.financiamiento ="Coyote";
                    HUDScript.instance.prestamoUsado = true;
                    break;
            }

            switch(partida.partidaData.seg1){
                case "Verqor":
                    HUDScript.instance.seguroVerqorUsado = true;
                    Ver.SetActive(true);
                    break;
                case "Banco":
                    HUDScript.instance.seguroBancoUsado = true;
                    Ban.SetActive(true);
                    break;
                case "Coyote":
                    HUDScript.instance.seguroCoyoteUsado = true;
                    Coy.SetActive(true);
                    break;
            }
            switch(partida.partidaData.seg2){
                case "Verqor":
                    HUDScript.instance.seguroVerqorUsado = true;
                    Ver.SetActive(true);
                    break;
                case "Banco":
                    HUDScript.instance.seguroBancoUsado = true;
                    Ban.SetActive(true);
                    break;
                case "Coyote":
                    HUDScript.instance.seguroCoyoteUsado = true;
                    Coy.SetActive(true);
                    break;
            }

            cultivosPartida = JsonUtility.FromJson<Cultivos>(partida.partidaData.cult);
            aditivosPartida = JsonUtility.FromJson<Aditivos>(partida.partidaData.aditivos);

            foreach(GameObject cultivo in cultivos){

                if(cultivo.name == "Jitomate"){
                    if(cultivosPartida.J >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.J;
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = jitomate;
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = jitomate.plantStages[cultivosPartida.J];
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = jitomate.timeBtwStages;
                    }
                    if(aditivosPartida.J.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = jitomate.timeBtwStages/2;
                    }
                    if(aditivosPartida.J.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.J.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.J.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.J.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = jitomate.timeBtwStages+5;
                    }
                }
                if(cultivo.name == "Chile"){
                    if(cultivosPartida.C >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = chile;
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = chile.plantStages[cultivosPartida.C];
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.C;
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = chile.timeBtwStages;
                    }
                    if(aditivosPartida.C.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = chile.timeBtwStages/2;
                    }
                    if(aditivosPartida.C.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.C.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.C.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.C.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = chile.timeBtwStages+5;
                    }
                }
                if(cultivo.name == "Maiz"){
                    if(cultivosPartida.M >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.M;
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = maiz;
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = maiz.plantStages[cultivosPartida.M];
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = maiz.timeBtwStages;
                    }
                    if(aditivosPartida.M.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = maiz.timeBtwStages/2;
                    }
                    if(aditivosPartida.M.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.M.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.M.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.M.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = maiz.timeBtwStages+5;
                    }
                }
                if(cultivo.name == "Cebada"){
                    if(cultivosPartida.Cb >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.Cb;
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = cebada;
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = cebada.plantStages[cultivosPartida.Cb];
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = cebada.timeBtwStages;
                    }
                    if(aditivosPartida.Cb.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = cebada.timeBtwStages/2;
                    }
                    if(aditivosPartida.Cb.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.Cb.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.Cb.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.Cb.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = cebada.timeBtwStages+5;
                    }
                }
                if(cultivo.name == "Lechuga"){
                    if(cultivosPartida.L >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = lechuga.plantStages[cultivosPartida.L];
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.L;
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = lechuga;
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = lechuga.timeBtwStages;
                    }
                    if(aditivosPartida.L.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = lechuga.timeBtwStages/2;
                    }
                    if(aditivosPartida.L.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.L.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.L.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.L.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = lechuga.timeBtwStages+5;    
                    }
                }
                if(cultivo.name == "Zanahoria"){
                    if(cultivosPartida.Z >= 0){
                        cultivo.GetComponent<CrecimientoParalelo>().plantStage = cultivosPartida.Z;
                        cultivo.GetComponent<CrecimientoParalelo>().isPlanted = true;
                        cultivo.GetComponent<CrecimientoParalelo>().plant = cultivo.GetComponent<SpriteRenderer>();
                        cultivo.GetComponent<CrecimientoParalelo>().plant.sprite = zanahoria.plantStages[cultivosPartida.Z];
                        cultivo.GetComponent<CrecimientoParalelo>().selectedCrop = zanahoria;
                        cultivo.GetComponent<CrecimientoParalelo>().plant.enabled = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = zanahoria.timeBtwStages;
                    }
                    if(aditivosPartida.Z.Contains("F")){
                        cultivo.GetComponent<CrecimientoParalelo>().fertilizanteSelec = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = zanahoria.timeBtwStages/2;
                    }
                    if(aditivosPartida.Z.Contains("A")){cultivo.GetComponent<CrecimientoParalelo>().abonoSelec = true;}
                    if(aditivosPartida.Z.Contains("I")){cultivo.GetComponent<CrecimientoParalelo>().insecticidaSelec = true;}
                    if(aditivosPartida.Z.Contains("R")){cultivo.GetComponent<CrecimientoParalelo>().agriRegenerativa = true;}
                    if(aditivosPartida.Z.Contains("T")){
                        cultivo.GetComponent<CrecimientoParalelo>().agriTradicional = true;
                        cultivo.GetComponent<CrecimientoParalelo>().timer = zanahoria.timeBtwStages+5;
                    }
                }

            }

            inventarioPartida = JsonUtility.FromJson<Inventario>(partida.partidaData.inventario);

            for(int i = 0;i<playerInventory.instance.isFull.Length;i++){
                if(inventarioPartida[i].Contains("V")){
                    if(inventarioPartida[i].Contains("VJitomate")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VJitomate;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VChile")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VChile;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VMaiz")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VMaiz;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VCebada")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VCebada;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VLechuga")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VLechuga;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VZanahoria")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VZanahoria;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VAbono")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VAbono;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VFertilizante")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VFertilizante;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("VInsecticida")){
                        playerInventory.instance.slots[i].GetComponent<Item>().itemVenta = VInsecticida;
                        if(inventarioPartida[i].Contains("Abono")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.abono=true;}
                        if(inventarioPartida[i].Contains("Regenerativa")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.regenerativa=true;}
                        if(inventarioPartida[i].Contains("Insecticida")){playerInventory.instance.slots[i].GetComponent<Item>().itemVenta.insecticida=true;}
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateVenta();
                        playerInventory.instance.isFull[i] = true;
                    }
                }else{
                    if(inventarioPartida[i].Contains("Jitomate")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TJitomate;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("Chile")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TChile;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("Maiz")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TMaiz;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("Cebada")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TCebada;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("Lechuga")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TLechuga;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                    else if(inventarioPartida[i].Contains("Zanahoria")){
                        playerInventory.instance.slots[i].GetComponent<Item>().item = TZanahoria;
                        playerInventory.instance.slots[i].GetComponent<Item>().UpdateItem();
                        playerInventory.instance.isFull[i] = true;
                    }
                }
            }

            HUDScript.instance.numCiclos = partida.partidaData.ciclo;

            

        }
    }
}

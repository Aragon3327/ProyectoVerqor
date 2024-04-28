using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemVenta", menuName = "ItemVenta")]
public class ItemVenta : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public bool regenerativa;
    public bool abono;
    public bool insecticida;
    public bool fertilizante;
    public int precioInicial;
    public int precioInc;
    public int precioAbono;
    public int precioReg;


    void OnEnable()
    {
        precioInc = precioInicial;
        precioAbono = 0;
        precioReg = 0;
        regenerativa = false;
        abono = false;
    }
}


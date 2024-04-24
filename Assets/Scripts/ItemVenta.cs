using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemVenta", menuName = "ItemVenta")]
public class ItemVenta : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public bool tadicional;
    public bool abono;
    public bool insecticida;
    public bool fertilizante;
    public int precioInicial;
}


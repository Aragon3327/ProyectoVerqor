using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New ItemTienda", menuName = "ItemTienda")]
public class ItemTiendaObjt : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public int precio;
}

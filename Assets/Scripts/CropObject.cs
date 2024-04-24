using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Crop", menuName = "Crop")]
public class CropObject : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwStages;
    public float timeSlowed;
    public float timeSpeedUp;
    public int cantidad;
    public Sprite icon;

    public SpriteRenderer plantRender;
    public ItemVenta itemVenta;
}

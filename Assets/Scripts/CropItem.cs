using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropItem : MonoBehaviour
{
    public CropObject crop;
    public TextMeshProUGUI nameTxt;
    public float timeBtwStages;
    public Image icon;

    public Image btnImage;
    public TextMeshProUGUI btnText;

    public SpriteRenderer plantRenderer;

    FarmManager fm;

    public GameObject notificacion;

    // Start is called before the first frame update
    void Start()
    {
        fm = GameObject.Find("Canvas").GetComponent<FarmManager>();

        InitializeUI();
    }

    public void SelectCrop()
    {
        fm.SelectDeselectCrop(this);    
    }

    void InitializeUI()
    {
        nameTxt.text = crop.plantName;
        icon.sprite = crop.icon;
        crop.timeBtwStages = timeBtwStages;
        crop.plantRender = plantRenderer;
    }
}

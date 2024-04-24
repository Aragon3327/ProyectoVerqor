using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventPanel : MonoBehaviour
{
    public EventData evento;
    //public TextMeshProUGUI eventNameTxt;
    public Image eventTypeImg;
    public TextMeshProUGUI descripcion;
    public TextMeshProUGUI cantidad;
    public Image eventoImg;

    public void Start()
    {
        //eventNameTxt.text = evento.eventName;
        eventTypeImg.sprite = evento.eventTypeImg;
        descripcion.text = evento.descripcion;
        eventoImg.sprite = evento.eventoImg;
        cantidad.text = evento.cantidad.ToString();
    }

    public void Update()
    {
        cantidad.text = evento.cantidad.ToString();
    }
}

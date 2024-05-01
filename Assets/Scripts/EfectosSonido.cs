using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EfectosSonido : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void clickBoton()
    {
        audioManager.Playsfx(audioManager.buttonsound);
    }
    public void clickPlantar()
    {
        audioManager.Playsfx(audioManager.plantar);
    }
    public void clickComprar()
    {
        audioManager.Playsfx(audioManager.comprar);
    }
    public void clickPapel()
    {
        audioManager.Playsfx(audioManager.papel);
    }
    public void clickVerqor()
    {
        audioManager.Playsfx(audioManager.verqor);
    }
    public void clickCoyote()
    {
        audioManager.Playsfx(audioManager.coyote);
    }
    public void clickBanco()
    {
        audioManager.Playsfx(audioManager.banco);
    }
}

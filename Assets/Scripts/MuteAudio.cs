using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI en Unity

public class MuteAudio : MonoBehaviour
{
    public Toggle muteToggle; // Referencia al Toggle en tu UI

    private void Start()
    {
        // Configura el método OnToggleChanged para que se llame cuando cambie el estado del Toggle
        muteToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    public void OnToggleChanged(bool mute)
    {
        if (mute)
        {
            // Pausar todos los sonidos
            AudioListener.pause = true;
        }
        else
        {
            // Reanudar todos los sonidos
            AudioListener.pause = false;
        }
    }
}
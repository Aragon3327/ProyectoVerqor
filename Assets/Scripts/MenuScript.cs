using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Story");
    }

    public void sonido()
    {
        audioManager.Playsfx(audioManager.buttonsound);
    }
}
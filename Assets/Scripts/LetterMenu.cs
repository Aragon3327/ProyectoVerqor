using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterMenu : MonoBehaviour
{
    AudioManager audioManager;
    public UnityEngine.UI.Button carta;
    public UnityEngine.UI.Image hoja;
    public UnityEngine.UI.Button boton;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Start()
    {
        carta.enabled = true;
        hoja.gameObject.SetActive(false);
        boton.gameObject.SetActive(false);
    }
    public void clickCarta(){
        audioManager.Playsfx(audioManager.papel);
        carta.enabled = false;
        hoja.gameObject.SetActive(true);        
        boton.gameObject.SetActive(true);
    }

    public void clickboton(){
        audioManager.Playsfx(audioManager.buttonsound);
        SceneManager.LoadScene("Modificado");
    }
}

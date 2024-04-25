using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
    private void IniciarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Selector1(){
        PlayerPrefs.SetString("GeneroUsuario","H");
        IniciarMenu();
    }

    public void Selector2(){
        PlayerPrefs.SetString("GeneroUsuario","M");
        IniciarMenu();
    }

}

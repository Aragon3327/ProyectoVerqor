using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int deuda = 0;
    public int ganancia = 0;

    public bool seguro = false;

    public bool seguroCoyote = false;

    public bool seguroBanco = false;

    public static playerStats instance;

    private void Awake(){
        instance = this;
    }
}

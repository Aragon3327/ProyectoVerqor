using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{

    public static HUDScript instance;

    public TMP_Text gananciaText;
    public TMP_Text deudaText;
    public TMP_Text tiempoText;
    public TMP_Text ingresoFinal;
    public TMP_Text deudaFinal;
    public TMP_Text gananciaFinal;
    public TMP_Text win;
    public TMP_Text lose;
    public TMP_Text neutral;

    public WeatherSystem clima;
    public EventManager2 evento;
    AudioManager audioManager;


    public float tiempoCiclo = 720; 
    // public float tiempoCiclo = 60; // Para hacer pruebas
    private float tiempoCiclo2;
    public bool prestamoUsado = false;
    public bool seguroVerqorUsado = false;
    public bool seguroCoyoteUsado = false;
    public string financiamiento = "";
    public string seguro1= "";
    public string seguro2= "";
    public bool seguroBancoUsado = false;
    public int numCiclos = 0;
    public bool finalizado = false;

    void Start()
    {
        clima.ChangeWeather();
    }

    public UnityEngine.UI.Image Ver;
    public UnityEngine.UI.Image Coy;
    public UnityEngine.UI.Image Ban;
    public GameObject panelFinal;

    [SerializeField] private GameObject avisoFinanciamiento;
    [SerializeField] private GameObject avisoSeguro;
    [SerializeField] private GameObject avisoSeguroCoyote;


    private void Awake()
    {
        instance = this;
        tiempoCiclo2 = tiempoCiclo;
        Ver.enabled = false;
        Coy.enabled = false;
        Ban.enabled = false;
        avisoFinanciamiento.SetActive(false);
        avisoSeguro.SetActive(false);
        avisoSeguroCoyote.SetActive(false);
        panelFinal.SetActive(false);
        win.enabled = false;
        lose.enabled = false;
        neutral.enabled = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        // Actualiza el texto de la ganancia y la deuda en el HUD
        int deuda = playerStats.instance.deuda;
        int ganancia = playerStats.instance.ganancia;
        gananciaText.SetText(ganancia.ToString());
        deudaText.SetText(deuda.ToString());

        DisplayTime(tiempoCiclo);

        if (numCiclos > 3)
        {
            finalizado = true;
            panelFinal.SetActive(true);
            Time.timeScale = (finalizado) ? 0 : 1;
            ingresoFinal.SetText(ganancia.ToString());
            deudaFinal.SetText(deuda.ToString());
            gananciaFinal.SetText((ganancia - deuda).ToString());
            if ((ganancia - deuda) > 0)
            {
                win.enabled = true;
                audioManager.Playsfx(audioManager.win);
            }
            else if ((ganancia - deuda) < 0)
            {
                lose.enabled = true;
                audioManager.Playsfx(audioManager.lose);
            }
            else
            {
                neutral.enabled = true;
                audioManager.Playsfx(audioManager.malo);
            }
        }

        if (tiempoCiclo > 0)
        {
            tiempoCiclo -= Time.deltaTime;

            // Para tiempo real
            /* if (prestamoUsado)
            {
                if (tiempoCiclo <= 540.00 && tiempoCiclo > 539.99)
                {
                    evento.ChangeEvent();
                }
                else if (tiempoCiclo <= 360.00 && tiempoCiclo > 359.99)
                {
                    evento.ChangeEvent();
                }
            } */

            // Para hacer pruebas
            if (prestamoUsado)
            {
                if (tiempoCiclo <= 40.00 && tiempoCiclo > 39.99)
                {
                    evento.ChangeEvent();
                }
                else if (tiempoCiclo <= 20.00 && tiempoCiclo > 19.99)
                {
                    evento.ChangeEvent();
                }
            }
        }
        else
        {
            tiempoCiclo = tiempoCiclo2;
            numCiclos++;
            Debug.Log(numCiclos);
            clima.ChangeWeather(); // Cambiar clima cada ciclo
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        tiempoText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    // Método que se llama cuando se hace clic en cualquier botón de préstamo
    public void PrestamoButtonClick(string boton)
    {
        if (!prestamoUsado)
        {
            int cantidadBase = 5100;
            float porcentajeAdicional;
            switch (boton)
            {
                case "Verfin":
                    porcentajeAdicional = 0.3f; //Verqor 30%
                    Ver.enabled = true;
                    financiamiento ="Verqor";
                    break;
                case "Banfin":
                    porcentajeAdicional = 0.5f; // Banco 50%
                    Ban.enabled = true;
                    financiamiento ="Banco";
                    break;
                case "Coyofin":
                    porcentajeAdicional = 0.75f; // Coyote 75%
                    Coy.enabled = true;
                    financiamiento ="Coyote";
                    break;
                default:
                    return;
            }
            // Calcula la cantidad total a prestar
            int cantidadTotal = Mathf.RoundToInt(cantidadBase * (1 + porcentajeAdicional));
            // Agrega la cantidad total a la deuda del jugador
            playerStats.instance.deuda += cantidadTotal;
            // Actualiza el texto de la deuda en el HUD
            deudaText.SetText(playerStats.instance.deuda.ToString());
            // Agrega 5100 a la ganancia del jugador
            playerStats.instance.ganancia += 5100;
            // Actualiza el texto de la ganancia en el HUD
            gananciaText.SetText(playerStats.instance.ganancia.ToString());
            // Marca el préstamo como usado
            prestamoUsado = true;
        }
        else
        {
            avisoFinanciamiento.SetActive(true);
        }
    }

    // Método que se llama cuando se hace clic en el botón de seguro tradicional
    public void SeguroTradicionalButtonClick()
    {
        Debug.Log("SeguroTradicionalButtonClick llamado");
        if (!seguroVerqorUsado)
        {
            int costoSeguro = 1500;
            playerStats.instance.deuda += costoSeguro;
            deudaText.SetText(playerStats.instance.deuda.ToString());
            seguroVerqorUsado = true;
            if(seguro1==""){
                seguro1="Verqor";
            }else{
                if(seguro2==""){
                    seguro2="Verqor";
                }
            }
        }
        else
        {
            Debug.Log("¡El seguro tradicional ya se ha utilizado!");
            avisoSeguro.SetActive(true);
        }
    }

    // Método que se llama cuando se hace clic en el botón de seguro coyote
    public void SeguroCoyoteButtonClick()
    {
        Debug.Log("SeguroCoyoteButtonClick llamado");
        if (!seguroCoyoteUsado)
        {
            int costoSeguro = 1500;
            playerStats.instance.deuda += costoSeguro;
            deudaText.SetText(playerStats.instance.deuda.ToString());
            seguroCoyoteUsado = true;
            if(seguro1==""){
                seguro1="Coyote";
            }else{
                if(seguro2==""){
                    seguro2="Coyote";
                }
            }
        }
        else
        {
            Debug.Log("¡El seguro coyote ya se ha utilizado!");
            avisoSeguroCoyote.SetActive(true);
        }
    }

    public void SeguroBancoButtonClick()
    {
        Debug.Log("SeguroBancoButtonClick llamado");
        if (!seguroBancoUsado)
        {
            int costoSeguro = 1500;
            playerStats.instance.deuda += costoSeguro;
            deudaText.SetText(playerStats.instance.deuda.ToString());
            seguroBancoUsado = true;
            if(seguro1==""){
                seguro1="Banco";
            }else{
                if(seguro2==""){
                    seguro2="Banco";
                }
            }
        }
        else
        {
            Debug.Log("¡El seguro banco ya se ha utilizado!");
            avisoSeguro.SetActive(true);
        }
    }

    // Método para obtener información sobre los seguros activados
    public string ObtenerSegurosActivados()
    {
        string segurosActivados = "Seguros activados:\n";
        if (seguroVerqorUsado)
        {
            segurosActivados += "- Seguro Tradicional\n";
        }
        if (seguroCoyoteUsado)
        {
            segurosActivados += "- Seguro Coyote\n";
        }
        return segurosActivados;
    }

    public void CerrarAviso()
    {
        avisoFinanciamiento.SetActive(false);
        avisoSeguro.SetActive(false);
        avisoSeguroCoyote.SetActive(false);
    }
}
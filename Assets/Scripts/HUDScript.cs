using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{

    public static HUDScript instance;

    public TMP_Text gananciaText;
    public TMP_Text deudaText;
    public TMP_Text tiempoText;

    public WeatherSystem clima;
    public EventManager2 evento;

    private float tiempoCiclo = 21;
    private float tiempoCiclo2;
    private bool prestamoUsado = false;
    public bool seguroVerqorUsado = false;
    public bool seguroCoyoteUsado = false;

    public bool seguroBancoUsado = false;

    void Start()
    {
        clima.ChangeWeather();
    }

    public UnityEngine.UI.Image Ver;
    public UnityEngine.UI.Image Coy;    
    public UnityEngine.UI.Image Ban;

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
    }

    void FixedUpdate()
    {
        // Actualiza el texto de la ganancia y la deuda en el HUD
        int deuda = playerStats.instance.deuda;
        int ganancia = playerStats.instance.ganancia;
        gananciaText.SetText(ganancia.ToString());
        deudaText.SetText(deuda.ToString());

        DisplayTime(tiempoCiclo);
        if (tiempoCiclo > 0)
        {
            tiempoCiclo -= Time.deltaTime;

            // Para llamar a los eventos cada 5 segundos y 15 segundos
            if (tiempoCiclo <= 10.00 && tiempoCiclo > 9.99)
            {
                evento.ChangeEvent();
            }
            /* else if (tiempoCiclo <= 15 && tiempoCiclo > 14.99)
            {
                evento.ChangeEvent();
            }
            else if (tiempoCiclo <= 10 && tiempoCiclo > 9.99)
            {
                evento.ChangeEvent();
            } */
        }
        else
        {
            tiempoCiclo = tiempoCiclo2;
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
                    break;
                case "Banfin":
                    porcentajeAdicional = 0.5f; // Banco 50%
                    Ban.enabled = true;
                    break;
                case "Coyofin":
                    porcentajeAdicional = 0.75f; // Coyote 75%
                    Coy.enabled = true;
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
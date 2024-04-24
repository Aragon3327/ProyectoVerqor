using UnityEngine;
using UnityEngine.UI;

public class BotonPrestamo : MonoBehaviour
{ // Nombre único del botón asignado en el Inspector
    public string nombreBoton;
    // Método que se llama cuando se hace clic en el botón
    public void OnClick()
    {
        // Llama al método PrestamoButtonClick del HUDScript con el nombre del botón como argumento
        HUDScript.instance.PrestamoButtonClick(nombreBoton);
    }
}

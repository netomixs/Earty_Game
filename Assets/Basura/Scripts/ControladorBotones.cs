using UnityEngine;
using UnityEngine.UI;
//Controlador  de los controles
public class ControladorBotones : MonoBehaviour
{
    public GameObject personaje;
    //Cada funcion realiza un impulso en la direccion indicada
    //Impulsa al personaje a la izquierda
    public void MoverIzquierda()
    {
        personaje.transform.Translate(Vector2.left * Time.deltaTime);
    }
    //Impulsa al personaje a la derecha
    public void MoverDerecha()
    {
        personaje.transform.Translate(Vector2.right * Time.deltaTime);
    }
    //Impulsa al personaje a la arriba
    public void MoverArriba()
    {
        personaje.transform.Translate(Vector2.up * Time.deltaTime);
    }
    //Impulsa al personaje a la abajo
    public void MoverAbajo()
    {
        personaje.transform.Translate(Vector2.down * Time.deltaTime);
    }
}
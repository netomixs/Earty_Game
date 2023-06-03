using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VentanaPausaController : MonoBehaviour
{
    // eSTA CLASE CONTROLA LA VENTANA DE pAUSA
    //Varieble que indica el estado de la ventana
    public int estado = 3;
    /*
     2- la ventana  esta desplegada
     1- se dio al boton positivo
     0- se dio al boton negativo
     */
    public void desplegar()
    {
        gameObject.SetActive(true);
        estado = 2;
    }
    public void aceptar()
    {
       gameObject.SetActive(false);
        estado = 1;
    }
    public void cancelar()
    {
        gameObject.SetActive(false);
        estado = 0;
    }
}

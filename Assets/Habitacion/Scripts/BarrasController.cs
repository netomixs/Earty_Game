using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Actualiza el valor de las barras dependidondo los valores de Earty
public class BarrasController : MonoBehaviour
{
    public BarraController bosque, agua, aire, limpieza;
    void Update()
    {
        //Actualiza los valores délas
        bosque.valor = Mascota.Instance.Bosque;
        agua.valor = Mascota.Instance.Agua;
        aire.valor = Mascota.Instance.Aire;
        limpieza.valor = Mascota.Instance.Limpieza;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraControllerLimpieza : MonoBehaviour
{
    public BarraController   limpieza;
    void Start()
    {
        
    }

    void Update()
    {
        limpieza.valor = Mascota.Instance.Limpieza;
    }
}

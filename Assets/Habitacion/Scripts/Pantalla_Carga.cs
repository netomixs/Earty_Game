using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla_Carga : MonoBehaviour
{
    public GameObject pantalla;
    void Awake()
    {
        if (!pantalla.activeInHierarchy)
        {
            pantalla.SetActive(true);
            Debug.Log("Cargando Pantaklla");
        }
     
    }
 
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VentanaEmergente : MonoBehaviour
{
    public GameObject ventana;
    public TMP_Text texto;
    void Start()
    {
        
    }
    public void setText(string txt)
    {
        texto.text = txt;
        ventana.SetActive(true);
    }
   
   public void Destruir()
    {
        ventana.SetActive(false);
    }
      
}

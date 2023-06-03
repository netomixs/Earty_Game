using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VentanaPuntuacion : MonoBehaviour
{   
    public TMP_Text tiempo, puntos, resultado;
    public int estado = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Llama este metodo para mostrar la ventana con el texto introducido
    public void setText(string txt_tiempo,string txt_puntos, string txt_resultado)
    {
        tiempo.text= txt_tiempo;
        puntos.text= txt_puntos;
        resultado.text= txt_resultado;
        gameObject.SetActive(true);
    }
    //Al dar el boton aceptar la ventana desaparece y el estado pasa a 1
    public void aceptar()
    {
        gameObject.SetActive(false);
        estado = 1;
    }
}

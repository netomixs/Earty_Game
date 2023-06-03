using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausaController : MonoBehaviour
{
    //NO TOCAR SI NO ES NECESARIO
    //Clase que se usa paráponer en pausa el juego 
    private bool isPaused;
    //Agrega la vcentana de pausa desde el editor
   public  VentanaPausaController ventana;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si el estado de la ventana pasas a 1 el jeugo continuar
        if (ventana.estado == 1)
        {
            isPaused = false;
            Time.timeScale = 1;
        }
        //Si el estado de la ventana pasas a 0 el juego termina 
        if (ventana.estado == 0)
        {
            Time.timeScale = 1;
            regresar();
        }
    }
    //Llama a este metodo para poner en pausa el juego
    public void pausa()
    {
            // Cambiar el estado de pausa
            isPaused = true;
        // Activar o desactivar el panel de pausa según el estado de pausa
        ventana.desplegar();

        // Pausar o reanudar el tiempo en el juego según el estado de pausa
        Time.timeScale = 0;
    }

    //Este metodo regresa a la habitacion
    private void regresar()
    {
        gameObject.GetComponent<PanelSuperiorController>().Terminarjuego();
    }
}

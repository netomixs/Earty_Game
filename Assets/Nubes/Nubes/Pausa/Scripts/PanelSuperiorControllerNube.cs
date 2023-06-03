using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSuperiorControllerNube : MonoBehaviour
{   //Pon aqui las varible que necvesites
   
    //-------------------------------
    //No tocar, varibles estandar
    public TMP_Text txtPunto, txt_Tiempo;
    //Esta el la ventana de puntuacion debes asignarla el el editor
    public VentanaPuntuacion ventana;
    public float time = 0;
    public int puntos = 0;
    public int resultado;
    public MovNubeNegra nubeN;
    public MovNubeBlanca nubeB;
    public ControllerNube ControllerNube;
    public VentanaEmergente mensaje;
    bool mensajeMostrdo = false;
    //---------------------------
    void Start()
    {
        mensaje.setText("Destruye la contaminación");
    }

    void Update()
    {
        if (mensajeMostrdo==false)
        {
            if (mensaje.isActiveAndEnabled)
            {
                Time.timeScale = 0;

            }
            else
            {
                Time.timeScale = 1;
                mensajeMostrdo = true;
            }
        }
        

        //Pon aqui las condiciones que se deben de cumplr para que termine el juego
        //Y las agsiones a realizar
        if (ControllerNube.perdida>= 5)
        {
            Terminarjuego();


        }
        else
        {
            puntos = nubeN.score;
            time+= Time.deltaTime;
            txtPunto.text = puntos+"";
            txt_Tiempo.text = getTime(time);
        }
        //----------------------------------------------
        
    }

    //Metodo que formatea el tiempo en 00:00
     string getTime(float seconds)
    {
        float segundos = seconds;
        float minutos = segundos / 60;
        float segundos_restantes = segundos % 60;
        string tempo_formatado = string.Format("{0:00}:{1:00}", minutos, segundos_restantes);
        return tempo_formatado;
    }
    public void Terminarjuego()
    {
        Time.timeScale = 0;
        resultado = puntos;
        ventana.setText(getTime(time), puntos + "", resultado + "");
        if (ventana.estado == 1)
        {
            Mascota.Instance.Aire += puntos;
            Mascota.Instance.GotoHome();
        }
    }
}

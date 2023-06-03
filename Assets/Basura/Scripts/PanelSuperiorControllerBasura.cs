using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSuperiorControllerBasura : MonoBehaviour
{   //Pon aqui las varible que necvesites

    public GameManager game;
    //-------------------------------
    int anterior = 0;
    //No tocar, varibles estandar
    public TMP_Text txtPunto, txt_Tiempo;
    //Esta el la ventana de puntuacion debes asignarla el el editor
    public VentanaPuntuacion ventana;
    public float time = 20;
    public int puntos = 0;
    public int resultado;
    public VentanaEmergente mensaje;
    bool mensajeMostrao = false;
    //---------------------------
    void Start()
    {
        mensaje.setText("Busca la basura");
    }

    void Update()
    {
        if (mensajeMostrao==false)
        {
            if (mensaje.isActiveAndEnabled)
            {
                Time.timeScale = 0;

            }
            else
            {
                Time.timeScale = 1;
                mensajeMostrao=true;

            }
        }
      
        puntos = game.PuntosTotales;
        if (puntos!=anterior)
        {
            time += 20;
          anterior= puntos; 
        }
        //Pon aqui las condiciones que se deben de cumplr para que termine el juego
        //Y las agsiones a realizar
        if (time<=0 || puntos>=6)
        {
            Terminarjuego();
        }
        else
        {
            time-= Time.deltaTime;
            txtPunto.text = puntos+"";
            txt_Tiempo.text = getTime(time);
        }
        //----------------------------------------------
        
    }
    //Metodos propis del juego Plantar arboles 
    //Eliminar

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
        resultado = (int)(puntos +time);
        ventana.setText(getTime(time), puntos + "", resultado + "");
        if (ventana.estado == 1)
        {
            Mascota.Instance.Limpieza += resultado;
            Mascota.Instance.GotoHome();
        }
    }
}

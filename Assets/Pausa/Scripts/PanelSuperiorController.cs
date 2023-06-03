using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelSuperiorController : MonoBehaviour
{   //Pon aqui las varible que necvesites
    public int desperdicios=0;
    int maxDesperdicios = 5;
    public float aguaGastada;
    public Regadera regadera;
    //-------------------------------
    //No tocar, varibles estandar
    public TMP_Text txtPunto, txt_Tiempo;
    //Esta el la ventana de puntuacion debes asignarla el el editor
    public VentanaPuntuacion ventana;
    public float time = 0;
    public int puntos = 0;
    public int resultado;
    //---------------------------
    void Start()
    {
        
    }

    void Update()
    {
        //Pon aqui las condiciones que se deben de cumplr para que termine el juego
        //Y las agsiones a realizar
        if (desperdicios>= maxDesperdicios)
        {
            Terminarjuego();
        }
        else
        {
            time+= Time.deltaTime;
            txtPunto.text = puntos+"";
            txt_Tiempo.text = getTime(time);
        }
        //----------------------------------------------
        
    }
    //Metodos propis del juego Plantar arboles 
    //Eliminar
    public void arbolSano()
    {
        puntos = puntos + 5;
    }
    public void bebeSano()
    {
        puntos = puntos + 1;
    }
    public void semilla()
    {
        puntos = puntos - 1;
    }
    public void arbolSeco()
    {
        desperdicios++;
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
        ventana.setText(getTime(time), puntos + "", resultado + "");
        if (ventana.estado == 1)
        {
            Mascota.Instance.Bosque += puntos;
            Mascota.Instance.Agua -= regadera.aguaGastada * .6f;
            Time.timeScale =1;
            Mascota.Instance.GotoHome();
        }
    }
}

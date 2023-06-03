using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstaditicasController : MonoBehaviour
{
    [Range(0,100)]
    public float factorDesgasteBosque = 25;
    [Range(0, 100)]
    public float factorDesgasteLimpieza = 80;
    [Range(0, 100)]
    public float factorDesgasteAire = 40;
    [Range(0, 100)]
    public float factorDesgasteAgua = 75;
    [Range(1, 100)]
    public int duracionCicloEnMinutos = 10;
     float yaerDuracion ;
    public float time=0;
    float promedio;
    float disminuri;
    int extraTime = 0;
    void Start()
    {
        yaerDuracion = duracionCicloEnMinutos * 60;
       
     
    }

    // Update is called once per frame
    void Update()
    {   //Calcula la salud de que se perdio mientras estuvo inactivo
        if (Mascota.Instance.isSave)
        {
            TimeSpan tiempoTranscurrido = Mascota.Instance.ultimoAcceso - DateTime.Now;
            extraTime = (int)tiempoTranscurrido.TotalSeconds;
            Debug.Log(Mascota.Instance.ultimoAcceso);
            Debug.Log(DateTime.Now);

            Debug.Log(extraTime);
            /*Debug.Log("bajando");
            Debug.Log(extraTime);
            while (extraTime > 0)
            {
                disminur();
                //Si la salud baja entre 0 y unoi se detiene ya que no es necesario bajar mas
                if (promedio < 1)
                {
                    break;

                }
                extraTime--;
               
            }*/
            Mascota.Instance.isSave = false;
        }
        //Permite ejecutar cada segundo
        time += Time.deltaTime;
        if (time>=1)
        {
            disminur();
            time = 0;
            //Se calula el promedio de salud
            CalcularEmoccion();
        }
        
    }
    private void CalcularEmoccion()
    {
        promedio = Mascota.Instance.Bosque + Mascota.Instance.Agua + Mascota.Instance.Aire + Mascota.Instance.Limpieza;
        promedio = promedio / 4;
        //dependidno de la salud su estado der animo cambia
        if (promedio >= 75)
        {
            Mascota.Instance.tristeza = 0;
        }
        if (promedio < 75)
        {
            Mascota.Instance.tristeza = 1;
        }
        if (promedio < 50)
        {
            Mascota.Instance.tristeza = 2;
        }
    }
    //Diminuye la salud de dependiendo los valores indicados en los parametros de la clase
  public void disminur()
    {
        if (Mascota.Instance.Bosque > 0)
        {
            disminuri = factorDesgasteBosque / yaerDuracion;
            Mascota.Instance.Bosque = Mascota.Instance.Bosque - disminuri;
        }
        if (Mascota.Instance.Agua > 0)
        {
            disminuri = factorDesgasteAgua / yaerDuracion;
            Mascota.Instance.Agua = Mascota.Instance.Agua - disminuri;
        }
        if (Mascota.Instance.Aire > 0)
        {
            disminuri = factorDesgasteAire / yaerDuracion;
            Mascota.Instance.Aire = Mascota.Instance.Aire - disminuri;
        }
        if (Mascota.Instance.Limpieza > 0)
        {
            disminuri = factorDesgasteLimpieza / yaerDuracion;
            Mascota.Instance.Limpieza = Mascota.Instance.Limpieza - disminuri;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public int vidad = 10;
    public  int puntos = 0;
    public float tiempo = 0;
    public GameObject contadorTiempo;
    public GameObject contadorPuntos;
    public GameObject ventana;
    public GameObject ventanaPausa;
    public GameObject btnPausa;
    public bool isPause=false;
    // Update is called once per frame
    void Update()
    {
        
        contadorPuntos.GetComponent<TMP_Text>().text = puntos+"";
       
        contadorTiempo.GetComponent<TMP_Text>().text = FormatearTiempo(tiempo);
    
        if (vidad<=0)
        {
            int total = (int)((puntos + (tiempo * .5))*.5);
            ventana.GetComponent<VentanaEmergenteAgua>().Mostrar(puntos + "", FormatearTiempo( tiempo), total+"");
            Mascota.Instance.Agua += total;
        }
        else
        {
            if (!isPause)
            {
                tiempo += Time.deltaTime;
            }
           
        }

    }
    public void sumarPuntos(int punto)
    {
        puntos += punto;
    }
    public void restarVidas(int v)
    {
        vidad -= v;
    }
    public string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);

        string tiempoFormateado = minutos.ToString("00") + ":" + segundos.ToString("00");

        return tiempoFormateado;
    }
    public void enPausa()
    {
        isPause = true;
        btnPausa.SetActive(false);
        ventanaPausa.SetActive(true);
    }
    public void salirPausa()
    {
        isPause = false;
        btnPausa.SetActive(true);
        ventanaPausa.SetActive(false);
    }
    public void salir()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

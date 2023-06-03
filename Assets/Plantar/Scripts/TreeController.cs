using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private float time;
    public float velocidad=1;
    public float timepoParaSecar=20;
    public float maxTIempoParaSecar = 20;
    public float tiempoParaCrecer=20;
    public float intervaloMinimo=10;
    public List<GameObject> lista;
    public GameObject celda;
    public GameObject barra;
    public float maxBarra;
    int estadoActual=0;
    public bool isPlantado=false;
    public Vector2 posicion;
    void Start()
    {
        activarEstado(estadoActual);
        maxBarra=barra.transform.localScale.x;
    }


    void Update()
    {
        if (isPlantado)
        {
            time = Time.deltaTime * velocidad;
            if (celda.GetComponent<Celda>().isHumedo )
            {
                timepoParaSecar = maxTIempoParaSecar;
                barra.SetActive(false);
            }
            else
            {
                barra.transform.localScale = new Vector3(timepoParaSecar * (maxBarra / maxTIempoParaSecar), barra.transform.localScale.y, barra.transform.localScale.z);
                barra.SetActive(true);
            }

            if (timepoParaSecar > 0 && celda.GetComponent<Celda>().isHumedo==false)
            {
                
                timepoParaSecar -= time;

            }

            if (timepoParaSecar <= 0)
                {
                    secar();
                }
            if (tiempoParaCrecer>0)
                {
                tiempoParaCrecer -= time;
            }

        if (tiempoParaCrecer<=0)
            {
            crecer();
            }

        }
    }
    void crecer()
    {
        if (estadoActual<3)
        {
            estadoActual++;
            tiempoParaCrecer = intervaloMinimo * (estadoActual);
        }
        if (estadoActual==3)
        {
            timepoParaSecar = maxTIempoParaSecar;
        }
        activarEstado(estadoActual);
    }
    void secar()
    {
        if (estadoActual<4)
        {
            estadoActual+=4;
        }
        activarEstado(estadoActual);
    }
    private void activarEstado(int index)
    {
        for (int i=0;i<lista.Count;i++)
        {
            lista[i].SetActive(false);
        }
        lista[index].SetActive(true);
    }


    public void setCelda(GameObject gameObject)
    {
        celda=gameObject;
        string nombre= celda.name;
        string[] partes = nombre.Split('_');

        // Obtener las coordenadas x e y como enteros
        int x = int.Parse(partes[1]);
        int y = int.Parse(partes[2]);
        posicion = new Vector2(x,y);
        isPlantado = true;
    }
    public int  retirar()
    {   
        Destroy(gameObject);
        gameObject.SetActive(false);
        return estadoActual;
    }
}

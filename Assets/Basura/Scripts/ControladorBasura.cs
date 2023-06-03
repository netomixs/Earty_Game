using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorBasura : MonoBehaviour
{

    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;

    void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }


    void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if(tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            crearEnemigo();
        }
    }

    private void crearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
}

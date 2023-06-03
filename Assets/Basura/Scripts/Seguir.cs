using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Transform personaje;
    public float velocidadMovimiento = 5f;
    private float posicionOriginalZ;
    public float offsetVertical = 2f; // Distancia vertical desde la parte inferior de la cámara

    private void Start()
    {
        posicionOriginalZ = transform.position.z;
    }

    private void Update()
    {
        Vector3 direccion = personaje.position - transform.position;
      //  direccion.z = 0;
        direccion.Normalize();

        float distancia = Vector3.Distance(transform.position, personaje.position);

        if (distancia > 0.1f)
        {
            transform.position += direccion * velocidadMovimiento * Time.deltaTime;
        }
        Vector3 targetPosition = personaje.position;
        targetPosition.z = transform.position.z; // Mantener la posición Z actual de la cámara
        targetPosition.y -= offsetVertical; // Desplazar hacia abajo según el offsetVertical

        transform.position = Vector3.Lerp(transform.position, targetPosition, velocidadMovimiento * Time.deltaTime);
        // Si la distancia en Z es mayor a un valor determinado, volvemos a la posición original en Z
        if (Mathf.Abs(personaje.position.z - transform.position.z) > 1f)
        {
            Vector3 posicionActual = transform.position;
            posicionActual.z = posicionOriginalZ;
            transform.position = posicionActual;
        }
    }
}


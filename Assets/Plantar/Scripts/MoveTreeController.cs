using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//Controla el movimeinto de una semilla
public class MoveTreeController : MonoBehaviour
{   private Vector2 initialPosition;
    private bool isDragging = false;
    public GameObject inventario;
    public AudioSource tomar;
    private void Awake()
    {
        inventario = GameObject.Find("Inventario");
    }
    //Cuando se toma una semilla
    void OnMouseDown()
    {
        if (!gameObject.GetComponent<TreeController>().isPlantado)
        {
            isDragging = true;
            initialPosition = transform.position;
            inventario.GetComponent<Inventario_Llegada>().tomarSemilla();
            tomar.Play();
        }
    }
    //Se usa cuando se deja de tocar la semmila
    void OnMouseUp()
    {
        isDragging = false;
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {   //Si se sat tocando una celda se coloca la semiila en esa celda
            if (collider.CompareTag("Celda"))
            {   
                transform.position = collider.transform.position;
                GetComponent<TreeController>().setCelda(collider.gameObject);
                Debug.Log(gameObject.name);
                tomar.Play();
                return;
            }
        }
        //En caso contrario se destruye la semilla y se aumenta inventario
        if (inventario.GetComponent<Inventario_Llegada>().dejarSemilla()){ }
        else
        {
            desperdicio();
        }
        Destroy(gameObject);
    }

    private void desperdicio()
    {
        Debug.Log("Se desoperdicion una semilla");
    }
    //Se copia el moviemieto del cursor
    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1f;
            transform.position = mousePosition;
        }
    }
}



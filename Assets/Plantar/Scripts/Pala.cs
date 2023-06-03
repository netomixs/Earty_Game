using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Control de moviemnto de pala
public class Pala : MonoBehaviour
{

    private Vector3 posInicial;
    private bool enMovimiento = false;
    private Transform celdaDestino;
    public PanelSuperiorPlantarController puntos;
    public AudioSource audioSource;
    void Start()
    {
        reposicionar();
        posInicial = transform.position;
    
    }


    void OnMouseDown()
    {
        // Guarda la posición inicial
        posInicial = transform.position;

        // Inicia el movimiento cuando se hace clic en el objeto
        enMovimiento = true;
        Debug.Log("Se toco la pala");
    }
    //Se suelta la pala
    void OnMouseUp()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        foreach (Collider2D collider in colliders)
        {   //Si la pala esta arriba de un arbol se corta
            if (collider.CompareTag("Arbol"))
            {
                audioSource.Play();
                GameObject arbol = collider.gameObject;
                if (arbol.GetComponent<TreeController>().celda!=null)
                {//Se asigna putnos depediendo del estado del arbol
                    int estado=arbol.GetComponent<TreeController>().retirar();
                    if (estado == 3)
                    {
                        arbolSano();
                        Debug.Log("Puntos totales");
                    }
                    if (estado==2)
                    {
                       bebeSano();
                        Debug.Log("Puntos parceales");
                    }
                    if (estado<2)
                    {
                        semilla();
                        Debug.Log("Puntos -1");
                    }
                    if (estado>3)
                    {
                        arbolSeco();
                        Debug.Log("Puntos malos");
                    }
                    transform.position = posInicial;
                }
                
                transform.position = posInicial;
                return;
            }
        }
        transform.position = posInicial;
    }
    void OnMouseDrag()
    {
        if (enMovimiento)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1f;
            transform.position = mousePosition;
        }
    }
    void reposicionar()
    {
        // Obtenemos el tamaño de la pantalla en píxeles
        // Obtenemos la posición de la cámara en el mundo
        Vector3 cameraPosition = Camera.main.transform.position;

        // Convertimos la coordenada de la pantalla a una coordenada del mundo utilizando la cámara
        Vector3 worldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - cameraPosition;

        // Obtenemos la medida del mundo de la pantalla dividiendo el ancho de la pantalla entre el ancho en coordenadas del mundo
        float worldScreenWidth = worldWidth.magnitude ;

        // Calculamos la posición del objeto
        float posX = worldScreenWidth / 2 ;
        Renderer renderer = GetComponent<Renderer>(); // Obtenemos el componente Renderer del objeto actual
        Vector3 size = renderer.bounds.size;
        posX =posX-size.x;
            ;

        // Posicionamos el objeto en la posición calculada
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
    private void Update()
    {

    }

    public void arbolSano()
    {
        puntos.puntos = puntos.puntos + 5;
    }
    public void bebeSano()
    {
        puntos.puntos = puntos.puntos + 1;
    }
    public void semilla()
    {
        puntos.puntos = puntos.puntos - 1;
    }
    public void arbolSeco()
    {
        puntos.desperdicios++;
    }
}


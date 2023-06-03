using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla el tama�o del tablero
public class CampoSize : MonoBehaviour
{
    float screenWidth;
    float screenWorldWidth;
    GameObject[] cells;
    public float visibilityRange = 0.2f;
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Celda");
    }
    void Update()
    {//Se elimina cualquier celda que se salgo por mas de la mitad de la pantalla
        foreach (GameObject cell in cells)
        {
            Renderer renderer = cell.GetComponent<Renderer>();

            // Obtener la posici�n del objeto en relaci�n con la c�mara
                    Vector3 screenPos = Camera.main.WorldToViewportPoint(cell.transform.position);

            // Comprobar si el objeto est� dentro del rango de visibilidad
            bool isVisible = screenPos.x >= -visibilityRange && screenPos.x <= 1 + visibilityRange && screenPos.y >= -visibilityRange && screenPos.y <= 1 + visibilityRange && screenPos.z > 0;
            // Si el objeto no est� dentro del rango de visibilidad, desactivarlo
            if (!isVisible )
            {
                renderer.enabled = false;
                cell.gameObject.SetActive(false);
            }
            else
            {
                renderer.enabled = true;
                cell.gameObject.SetActive(true);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//Controlla el inventario de las semillas
public class Inventario_Llegada : MonoBehaviour
{
    public int itemAmount = 0; //Cantidad actual del art�culo en el inventario
    public int maxCapacity = 20; //Capacidad m�xima del inventario
    public float initialReplenishRate = 0.1f; //Velocidad de reposici�n inicial
    public float maxReplenishRate = 1.0f; //Velocidad de reposici�n m�xima
    public float replenishRateIncrease = 0.1f; //Incremento de la velocidad de reposici�n por unidad de tiempo
    public float replenishTime = 20.0f; //Tiempo que tarda en reabastecerse el inventario
    public TMP_Text Contador_Arboles;
    private float currentReplenishRate; //Velocidad de reposici�n actual
    int semillasGeneradas;
    private float timer; //Temporizador para controlar el reabastecimiento
    public GameObject objetoPrefab;
    public bool semillaDesplegada = false;
    void Start()
    {
        currentReplenishRate = initialReplenishRate;
    }
    void Update()
    {
        // Si el inventario no est� lleno, comienza el temporizador para reabastecerse
        if (itemAmount < maxCapacity)
        {
            timer += Time.deltaTime;
            // Si ha pasado suficiente tiempo, aumenta la cantidad de art�culos en el inventario
            if (timer >= replenishTime)
            {
                itemAmount += Mathf.FloorToInt(currentReplenishRate);
                itemAmount = Mathf.Clamp(itemAmount, 0, maxCapacity);
                timer = 0f;
                // Aumenta la velocidad de reposici�n con el tiempo
                currentReplenishRate = Mathf.Clamp(currentReplenishRate + replenishRateIncrease, initialReplenishRate, maxReplenishRate);
            }
        }
        Contador_Arboles.text = itemAmount+"";
        //Genera un item d�semilla
        if (itemAmount > 0 && semillaDesplegada == false)
        {
            semillaDesplegada = true;
            Vector3 vector3=transform.position;
            vector3.z = 1;
            vector3.y += 1.5f;
            Instantiate(objetoPrefab,vector3,Quaternion.identity);
              
        }
    }
    public void tomarSemilla()
    {
        itemAmount--;
        semillaDesplegada=false;
    }
    public bool dejarSemilla()
    {
        if (itemAmount<maxCapacity)
        {
            itemAmount++;
            return true;
        }
        else
        {
            return false;
        }
    }
}

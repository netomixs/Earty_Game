using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla cuando aparecen las nubes ademas de cuales nubes se pueden tocar y cuales n
public class GeneradorNubes : MonoBehaviour
{
    public GameObject objectPrefab; // El objeto que queremos generar
    public int numberOfObjects; // El número de objetos que queremos generar
    public float minX; // La posición mínima en el eje X
    public float maxX; // La posición máxima en el eje X
    public float minY; // La posición mínima en el eje Y
    public float maxY; // La posición máxima en el eje Y
    private float time=10;
    private void Update()
    {   //Busca todas las nubes generada
        List<GameObject> objetonEncontrado = new List<GameObject>(GameObject.FindGameObjectsWithTag("Nube"));
        //Dependido el valor del estado de aire se calcula que perosenje de nubes seran blancas y cvuales negaras
        int count = (int)(objetonEncontrado.Count*Mascota.Instance.Aire/100 );
   
        for (int i = 0; i < count; i++)
        {
            objetonEncontrado[i].GetComponent<NubesController>().isTocable = true;
        }

        for (int i = count; i < objetonEncontrado.Count; i++)
        {
            objetonEncontrado[i].GetComponent<NubesController>().isTocable = false;
        }
        
        if (objetonEncontrado.Count<10)
        {
            if (time <= 0)
            {
                time = 10;
                Instantiate(objectPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                time=time-Time.deltaTime;
            }
        }
    }
}

 


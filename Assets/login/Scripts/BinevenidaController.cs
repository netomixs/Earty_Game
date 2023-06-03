using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BinevenidaController : MonoBehaviour
{
    public GameObject barra;
    GameObject indicador;
    RectTransform rec;
    float minimo, maximo;
   //Esta clase se ecnarga de controlar el tiempo de espera para cargar le escena y mostara la barra de carga
    void Start()
    {
        //Se asignan  valores iniciales a las variables estaticas
        indicador = barra.transform.GetChild(0).gameObject;
        rec = indicador.transform.GetComponent<RectTransform>();
        maximo = rec.offsetMax.x;
        minimo = rec.rect.width;
        rec.offsetMax = new Vector2((minimo + maximo), rec.offsetMax.y);
    }
    float time = 0;
    void Update()
    {   // SE GENERA UN TIEMPO DE CARGAS SIMULADO
        ///cuanndo este teimpo pasa se empeiza a cargar la escena real
         time+= Time.deltaTime;
        if (time>=5)
        {
            cambiarEcena();
        }
        else if (time<5)    
        {
            
            PintarBarraCarga((int)time*12);
        }

       
        
    }
    void cambiarEcena()
    {
        StartCoroutine(carga());
    }

    //Se encarga de pintar la barra de carga
    void PintarBarraCarga(int porcentaje)
    {
        float aux = minimo / 100;
        float actual = aux * porcentaje;
        rec.offsetMax = new Vector2((-(minimo - maximo)) + actual, rec.offsetMax.y);

    }
    //Este netodo se ejecuta miesntras se esta cargado la pagina
    private IEnumerator carga()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        //se obntiene el tiempo que falta para cargar l;a escena
        float progreso = Mathf.Clamp01(asyncOperation.progress / 0.9f);
        while (asyncOperation.isDone==false)
        {   // Mietras no se cargue se meustra la  pantalla de carga
            
            progreso = Mathf.Clamp01(asyncOperation.progress / 0.09f)*100;//se obntiene el tiempo que falta para cargar l;a escena
            Debug.Log(asyncOperation.progress+" "+ progreso);
            // Se pinta la barra de carga 
            if (progreso > 60)
            {
                PintarBarraCarga((int)progreso);
            }
            yield return null;
        }  
        
    }
}

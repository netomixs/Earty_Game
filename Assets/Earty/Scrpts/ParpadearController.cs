using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla el parpadeo de earty
public class ParpadearController : MonoBehaviour
{
    public Sprite caraParpadeando;
    public Sprite caraNoParpadeando;
    public GameObject cara;
    public GameObject pupilaR, pupilaL;
    [Range(0f, 10f)]
    public float duracionCerrado = 5f;
    [Range(0f, 10f)]
    public float duracionAbierto = 0.2f;
    private float tiempoCerrado=0,tiempoAbierto=0;
    private bool isParpadeando=false;
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
        {

      
        //Cada cierto tiempo se cambia el sprite de la cara por otro dependidno del estado
        //en el que se encuentre simulando el parpadeo
        if (isParpadeando)
        {
            cara.GetComponent<SpriteRenderer>().sprite = caraParpadeando;
            Mascota.Instance.parpadeo = true;
            tiempoCerrado += Time.deltaTime;
            pupilaR.SetActive(false);
            pupilaL.SetActive(false);
        }
        else
        {
            cara.GetComponent<SpriteRenderer>().sprite = caraNoParpadeando;
            Mascota.Instance.parpadeo = false;
            tiempoAbierto += Time.deltaTime;

        }
        //Si se a acumulado mucho tiempo cerrado se cambia el es5tado a parpadeo false
        if (tiempoCerrado >= duracionCerrado)
        {
            isParpadeando = false;
            tiempoCerrado = 0;

        }
        //Si se a acumulado mucho tiempo abiero se cambia el es5tado a parpadeo true
        if (tiempoAbierto >= duracionAbierto)
        {
            isParpadeando = true;
            tiempoAbierto = 0;
        }
        pupilaR.SetActive(!isParpadeando);
        pupilaL.SetActive(!isParpadeando);
        }
    }
}

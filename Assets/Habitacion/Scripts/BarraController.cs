using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Controlla el tamano de la barra dependiondo un valor dado
public class BarraController : MonoBehaviour
{
    public GameObject barra;
    GameObject indicador;
    RectTransform rec;
    public float valor=0;
    float  minimo,maximo;
    void Start()
    {
        indicador = barra.transform.GetChild(1).gameObject;
        Debug.Log(indicador.name);
        rec = indicador.transform.GetComponent<RectTransform>();
        maximo = rec.offsetMax.x;
        minimo = rec.rect.width;
        rec.offsetMax = new Vector2((minimo+ maximo), rec.offsetMax.y);
    }

    // Update is called once per frame
    void Update()
    {

        float aux = minimo / 100;
        float salud = aux * ((int)valor);
        rec.offsetMax=new Vector2((-(minimo - maximo))+salud, rec.offsetMax.y);
        //rec.offsetMax = new Vector2(barraSize.x - res, barraSize.y);
    }

}

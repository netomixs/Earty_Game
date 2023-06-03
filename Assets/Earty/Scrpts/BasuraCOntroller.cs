using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraCOntroller : MonoBehaviour
{
    List<GameObject> basura;
    // Start is called before the first frame update
    void Start()
    {
     basura = new List<GameObject>(GameObject.FindGameObjectsWithTag("Basura"));

    }
    void Update()
    {   //Divide la lista de los objetos basura en 2
        //Los visible y ni visibles
        //Dependidindo del prosentaje de Limpieza
        float basuraPorcentaje = basura.Count *Mascota.Instance.Limpieza;
        int count = (int)(basuraPorcentaje / 100);
        for (int i = 0; i < count; i++)
        {
            basura[i].SetActive(false);
        }
        for (int i = count; i < basura.Count; i++)
        {
            basura[i].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barraontrolleragua : MonoBehaviour
{
    public BarraController agua;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agua.valor = Mascota.Instance.Agua;
    }
}

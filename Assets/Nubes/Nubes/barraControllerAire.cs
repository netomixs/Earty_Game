using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraControllerAire : MonoBehaviour
{
    public BarraController  aire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aire.valor = Mascota.Instance.Aire;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaAspectoController : MonoBehaviour
{
   public GameObject aspectoAgua;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mascota.Instance.Agua<50)
        {
            aspectoAgua.SetActive(true);
        }
        else
        {
            aspectoAgua.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaController : MonoBehaviour
{   //Control de imagenes de corazon que cunetan las vidas
    public GameObject[] vidas;
    public ControllerNube ControllerNube;
 

  //Cada vez que se pierde una vida se queita un corazon
    void Update()
    {
        int a = 5;
        if (ControllerNube.perdida>0)
        {
            vidas[ControllerNube.perdida-1].SetActive(false);
        }
        
    }
}

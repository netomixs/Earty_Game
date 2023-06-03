using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla cuando se meustra el especto de agua lodosa
public class TierraLodoAspectoController : MonoBehaviour
{
    public GameObject lodoAspecto;
    void Update()
    {
        if (Mascota.Instance.Bosque<50)
        {
            lodoAspecto.SetActive(true);
        }
        else
        {
            lodoAspecto.SetActive(false);
        }
    }
}

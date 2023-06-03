using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Selecciona la cara a mostrar dependidon de la emocion de earty
public class FillingController : MonoBehaviour
{
    public List<GameObject> ListaCara;
    private int estadoAnterior;
    void Update()
    {

        if (Mascota.Instance.tristeza != estadoAnterior)
        {
            reinicar();
            estadoAnterior = Mascota.Instance.tristeza;
            ListaCara[estadoAnterior].SetActive(true);
        }

    }
    //QUita dodas las caras activadas
    void reinicar()
    {
        foreach (GameObject i in ListaCara)
        {
            i.SetActive(false);
        }
    }
}

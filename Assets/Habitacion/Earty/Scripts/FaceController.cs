using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceController : MonoBehaviour
{
    public GameObject PupilaR, PupilaL;
    public GameObject Cara;
    public List<GameObject> ListaCara;
    [SerializeField]
    [HideInInspector]
    int estadoAnterior=0;
    public string emocion = "";
    void Start()
    {
        emocion = "Feliz";
    }

    // Update is called once per frame
    void Update()
    {   
        switch (Mascota.Instance.tristeza)
        { 
            case 0:
                emocion = "Feliz";
                
                break;
                case 1:
                emocion = "Melalcolico";
                break;
                    case 2:
                emocion = "Triste";
                break;
            case 3:
                emocion = "Enfermo";
                break;
            default:
                break;
        }
        if (Mascota.Instance.tristeza==estadoAnterior)
        {

        }
        else
        {
            SpriteRenderer eR = PupilaR.transform.GetComponent<SpriteRenderer>();
            SpriteRenderer eL = PupilaL.transform.GetComponent<SpriteRenderer>();
            SpriteRenderer b = Cara.transform.GetComponent<SpriteRenderer>();
            eR.sprite = ListaCara[Mascota.Instance.tristeza].GetComponent<Face>().eyeRight;
            eL.sprite = ListaCara[Mascota.Instance.tristeza].GetComponent<Face>().eyeLeft;
            b.sprite = ListaCara[Mascota.Instance.tristeza].GetComponent<Face>().boca;
            estadoAnterior = Mascota.Instance.tristeza;
        }
     
    }
}

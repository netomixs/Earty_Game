using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;
//Clase que controla los ojos de earty
public class TouchEyesController : MonoBehaviour
{
    public GameObject pupilaR;
    public GameObject pupilaL;
    [Range(0.0f, 1.0f)]
    public float radio=0.1f;
    private Vector3 ojosOriginalR, ojosOriginaL;
    private Vector2 max;
   
    void Start()
    {
        max=getDimnesionScren();
        ojosOriginalR = new Vector3();
        ojosOriginaL = new Vector3();
        ojosOriginalR.x = pupilaR.transform.position.x;
        ojosOriginalR.y = pupilaR.transform.position.y;
        ojosOriginaL.y = pupilaL.transform.position.y;
        ojosOriginaL.x = pupilaL.transform.position.x;
    }
    void Update()
    {
        Vector2 touchPosition;
        if (Input.GetMouseButton(0) || Input.touchCount > 0) // Verifica si se ha hecho clic o hay un toque en la pantalla
        {

            if (Input.GetMouseButton(0)) // Verifica si se ha hecho clic con el mouse
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convierte las coordenadas del mouse a coordenadas del mundo
            }
            else if (Input.GetMouseButtonDown(0))
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convierte las coordenadas del mouse a coordenadas del mundo

            }
            else // Se ha detectado un toque en la pantalla
            {
                Touch touch = Input.GetTouch(0); // Obtiene el primer toque en la pantalla
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position); // Convierte las coordenadas del toque a coordenadas del mundo
            }
            Vector3 vector=new Vector3((touchPosition.x*radio)/max.x, (touchPosition.y * radio) / max.y,0.01f);
            if (touchPosition.y<pupilaR.transform.position.y && touchPosition.y>0)
            {
                Vector3 aux = new Vector3(vector.x,vector.y, 0);
                   
                aux.y=vector.y-pupilaR.transform.position.y*radio*2;
                pupilaR.transform.Translate(aux * Time.deltaTime);
                pupilaL.transform.Translate(aux);
                //vector.y= - eyeR.transform.position.y;
                if (pupilaR.transform.position.y >= (ojosOriginalR.y + vector.y))
                {
                    pupilaR.transform.position = (ojosOriginalR + vector); ;
                }
            }
            else
            {
                pupilaR.transform.Translate(vector * Time.deltaTime);
                pupilaL.transform.Translate(vector);
            }
          
            if (pupilaR.transform.position.x>=(ojosOriginalR.x+vector.x))
            {
                pupilaR.transform.position = (ojosOriginalR + vector);
            }
            if (pupilaR.transform.position.x <= (ojosOriginalR.x + vector.x))
            {
                pupilaR.transform.position = (ojosOriginalR + vector);
            }

            if (pupilaL.transform.position.x >= (ojosOriginaL.x + vector.x))
            {
                pupilaL.transform.position = (ojosOriginaL + vector);
               
            }
            if (pupilaL.transform.position.x <= (ojosOriginaL.x + vector.x))
            {
                pupilaL.transform.position = (ojosOriginaL + vector);
                
            }
            pupilaL.transform.localPosition = new Vector3(pupilaL.transform.localPosition.x, pupilaL.transform.localPosition.y, -0.7f);
            pupilaR.transform.localPosition = new Vector3(pupilaR.transform.localPosition.x, pupilaR.transform.localPosition.y, -0.7f);
            Debug.Log(pupilaL.transform.position);
            Debug.Log(pupilaL.transform.localPosition);
        }
        else
        {
            pupilaR.transform.position = ojosOriginalR;
            pupilaL.transform.position = ojosOriginaL;
    
        }
        pupilaL.transform.localPosition = new Vector3(pupilaL.transform.localPosition.x, pupilaL.transform.localPosition.y, -0.7f);
        pupilaR.transform.localPosition = new Vector3(pupilaR.transform.localPosition.x, pupilaR.transform.localPosition.y, -0.7f);


    }


    Vector2 getDimnesionScren()
    {
        Vector2 maxScreenCoordinates = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log("Coordenadas máximas de la pantalla: " + maxScreenCoordinates);
        return maxScreenCoordinates;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class EyesController : MonoBehaviour
{

    public GameObject eyeR;
    public GameObject eyeL;
    [Range(0.0f, 1.0f)]
    public float radio=0.1f;
    private Vector3 ojosOriginalR, ojosOriginaL;
    private Vector2 max;
    
    // Start is called before the first frame update
    void Start()
    {
        max=getDimnesionScren();
        ojosOriginalR = new Vector3();
        ojosOriginaL = new Vector3();
        ojosOriginalR.x = eyeR.transform.position.x;
        ojosOriginalR.y = eyeR.transform.position.y;
        ojosOriginaL.y = eyeL.transform.position.y;
        ojosOriginaL.x = eyeL.transform.position.x;
    }

    // Update is called once per frame
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
            if (touchPosition.y<eyeR.transform.position.y && touchPosition.y>0)
            {
                Vector3 aux = new Vector3(vector.x,vector.y, 0);
                   
                aux.y=vector.y-eyeR.transform.position.y*radio*2;
                eyeR.transform.Translate(aux * Time.deltaTime);
                eyeL.transform.Translate(aux);
                //vector.y= - eyeR.transform.position.y;
                if (eyeR.transform.position.y >= (ojosOriginalR.y + vector.y))
                {
                    eyeR.transform.position = (ojosOriginalR + vector); ;
                }
            }
            else
            {
                eyeR.transform.Translate(vector * Time.deltaTime);
                eyeL.transform.Translate(vector);
            }
          
            if (eyeR.transform.position.x>=(ojosOriginalR.x+vector.x))
            {
                eyeR.transform.position = (ojosOriginalR + vector);
            }
            if (eyeR.transform.position.x <= (ojosOriginalR.x + vector.x))
            {
                eyeR.transform.position = (ojosOriginalR + vector);
            }

            if (eyeL.transform.position.x >= (ojosOriginaL.x + vector.x))
            {
                eyeL.transform.position = (ojosOriginaL + vector);
               
            }
            if (eyeL.transform.position.x <= (ojosOriginaL.x + vector.x))
            {
                eyeL.transform.position = (ojosOriginaL + vector);
                
            }
            eyeL.transform.localPosition = new Vector3(eyeL.transform.localPosition.x, eyeL.transform.localPosition.y, -0.7f);
            eyeR.transform.localPosition = new Vector3(eyeR.transform.localPosition.x, eyeR.transform.localPosition.y, -0.7f);
            Debug.Log(eyeL.transform.position);
            Debug.Log(eyeL.transform.localPosition);
        }
        else
        {
            eyeR.transform.position = ojosOriginalR;
            eyeL.transform.position = ojosOriginaL;
    
        }
        eyeL.transform.localPosition = new Vector3(eyeL.transform.localPosition.x, eyeL.transform.localPosition.y, -0.7f);
        eyeR.transform.localPosition = new Vector3(eyeR.transform.localPosition.x, eyeR.transform.localPosition.y, -0.7f);


    }


    Vector2 getDimnesionScren()
    {
        Vector2 maxScreenCoordinates = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log("Coordenadas máximas de la pantalla: " + maxScreenCoordinates);
        return maxScreenCoordinates;
    }
}

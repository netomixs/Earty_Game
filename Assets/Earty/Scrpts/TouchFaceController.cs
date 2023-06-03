using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//Esta clase controla la posicion de la cara cuando se eecibe un toque en la pantalla
public class TouchFaceController : MonoBehaviour
{
    public GameObject cara;
    
    [Range(0.0f, 1.0f)]
    public float radio = 0.1f;
    private Vector3 original ;
    private Vector2 max;
    void Start()
    {
        max = getDimnesionScren();
        original = new Vector3();
        original.x = cara.transform.position.x;
        original.y = cara.transform.position.y;
     
    }
    void Update()
    {
        float posZ;
        if (Mascota.Instance.parpadeo)
        {
            posZ = -1.5f;
        }
        else
        {
            posZ = -0.5f;
        }
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
            Vector3 vector = new Vector3((touchPosition.x * radio) / max.x, (touchPosition.y * radio) / max.y, posZ);
            if (touchPosition.y < cara.transform.position.y && touchPosition.y > 0)
            {
                Vector3 aux = new Vector3(vector.x, vector.y, 0);

                aux.y = vector.y - cara.transform.position.y * radio * 2;
                cara.transform.Translate(aux * Time.deltaTime);
               
                //vector.y= - eyeR.transform.position.y;
                if (cara.transform.position.y >= (original.y + vector.y))
                {
                    cara.transform.position = (original + vector); ;
                }
            }
            else
            {
                cara.transform.Translate(vector * Time.deltaTime);
                
            }

            if (cara.transform.position.x >= (original.x + vector.x))
            {
                cara.transform.position = (original + vector);
            }
            if (cara.transform.position.x <= (original.x + vector.x))
            {
                cara.transform.position = (original + vector);
            }


            cara.transform.localPosition = new Vector3(cara.transform.localPosition.x, cara.transform.localPosition.y, posZ);
            
        }
        else
        {
            cara.transform.position = original;
           

        }
         cara.transform.localPosition = new Vector3(cara.transform.localPosition.x, cara.transform.localPosition.y, posZ);


    }
    Vector2 getDimnesionScren()
    {
        Vector2 maxScreenCoordinates = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        return maxScreenCoordinates;
    }
}

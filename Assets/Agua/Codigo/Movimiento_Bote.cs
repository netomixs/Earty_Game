using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Bote : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.transform.GetComponent<Jugador>().isPause)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                Debug.Log(touchPosition.x);
                double halfScreen = Screen.width / 2.0;
                Debug.Log(halfScreen);
 
                if (touchPosition.x < halfScreen)
                {
                    if (player.transform.position.x <= -1.95)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log(Vector3.left);
                        player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
                        Debug.Log(player.transform.position.x);
                        Debug.Log(player.transform.position.y);
                    }



                }
                else if (touchPosition.x > halfScreen)
                {
                    if (player.transform.position.x >= 2.1)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log(Vector3.right);
                        player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
                        Debug.Log(player.transform.position.x);
                    }


                }



            }

        }
        // +

    }
}

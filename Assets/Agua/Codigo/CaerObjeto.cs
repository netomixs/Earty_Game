using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaerObjeto : MonoBehaviour
{
    public GameObject player;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(waiter()); 
    }

    IEnumerator waiter()
    {       
        
         float defaulY = player.transform.position.y;
         float defaulZ = player.transform.position.z;
        
        int waitcase = 25;
        int counter = 0;
        while (counter < waitcase)
        {
           float timer = 0.01F;
            Debug.Log(player.transform.position.y);
            while (player.transform.position.y  >= -5)
            {
                player.transform.Translate(Vector3.down * 1 * Time.deltaTime);
                Debug.Log(player.transform.position.y);
                yield return new WaitForSeconds(timer);
            }   
             float num = UnityEngine.Random.Range(-1.80F,2.00F);
            originalPos = new Vector3(num,defaulY,defaulZ ); 
          
            player.transform.position = originalPos;

           counter++;
        }
               
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

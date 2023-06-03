using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlladorLluvia : MonoBehaviour
{
    GameObject[] cells;
    public ParticleSystem particle;
    bool isClick=false;
    float time;
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Celda");
    }
    private void Update()
    {

        if (isClick)
        {
            if (time <= 0)
            {
                foreach (GameObject cell in cells)
                {
                    cell.GetComponent<Celda>().upMojado(Random.Range(1, 10));
                }
                Destroy(gameObject);
            }
            else
            {
                time = time - Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        
        particle.Play();
        time = 4;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent< Renderer >().enabled= false;
        isClick = true;
     
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Item")
        {
                Destroy(gameObject);    
        }
    }
}


using UnityEngine;


public class ControllerItemLluvia : MonoBehaviour
{
    GameObject[] cells;
    float time = 1;
    public GameObject item;
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Celda");
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0) { 
        if (Random.Range(0,100)>=75)
        {
            GameObject cell = cells[Random.Range(0,cells.Length)];
                if (cell.activeInHierarchy) {
                    Vector3 vector3 = cell.transform.position;
                    vector3.z= 0;
                    Instantiate(item, vector3, Quaternion.identity);
                    Debug.Log("Item");
                }
               
           
        }
            time = 2;
        }
        else
        {
            time=time-Time.deltaTime;
        }
    }
}

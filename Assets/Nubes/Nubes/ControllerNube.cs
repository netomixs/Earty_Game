using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerNube : MonoBehaviour
{
    public float speed=1;
    public int perdida;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void aumentarVelocidad(float i)
    {
        speed += i;
    }
    public void disminuariVelocidad(float i)
    {
        speed-= i;
    }
}

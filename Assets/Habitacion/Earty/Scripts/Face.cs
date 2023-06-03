using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public Sprite eyeRight,eyeLeft,boca,parpadeo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Sprite getParpaedeo()
    {
        return parpadeo;
    }
    public Sprite getCara()
    {
        return boca;
    }
}

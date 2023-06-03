using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDowController : MonoBehaviour
{
    public TMPro.TMP_Dropdown dropdown1;
    // Start is called before the first frame update
    void Start()
    {

        dropdown1.options.Clear();

        int year = DateTime.Now.Year;
        for (int i = year - 3; i >= 1960; i--)
        {
            dropdown1.options.Add(new TMPro.TMP_Dropdown.OptionData(i+""));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

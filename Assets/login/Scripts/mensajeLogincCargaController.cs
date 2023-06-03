
using JetBrains.Annotations;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class mensajeLogincCargaController : MonoBehaviour
{   public TMPro.TMP_Text textMeshPro;
    //Clase que selecciona un mensaje aleatorio para las pantallas de carga
    private string fileName = "MensajesBienvenida";
    void Start()
    {//Genera un numero aleatrori
        int lineaN = Random.Range(0, 29);

        TextAsset asset = Resources.Load(fileName) as TextAsset;
        
        if (asset != null)
        {
            // Separar el contenido del archivo en líneas
            string[] lineas = asset.text.Split('\n');
            //Muestra la linea seleccionada
            lineaN=Random.Range(0, lineas.Length);
                textMeshPro.text= lineas[lineaN];
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentanaEmergenteAgua : MonoBehaviour
{
    public GameObject gOpuntos;
    public GameObject gOtiempo;
    public GameObject gOtotal;
    public GameObject ventana;
    void Start()
    {
       
    }
    public void Mostrar(string puntos,string timepo,string total)
    {
        gOpuntos.GetComponent<TMP_Text>().text=puntos;
        gOtiempo.GetComponent<TMP_Text>().text = timepo;
        gOtotal.GetComponent<TMP_Text>().text = total;
        ventana.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resegresar()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

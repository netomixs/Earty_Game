using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJuego : MonoBehaviour
{
    public GameObject MenuJuegoobjetc;
    public GameObject pupil1,pupila2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activar()
    {
        MenuJuegoobjetc.SetActive(true);
        pupil1.SetActive(false);
        pupila2.SetActive(false);
    }
    public void desactivar()
    {
        MenuJuegoobjetc.SetActive(false);
        pupil1.SetActive(true);
        pupila2.SetActive(true);
    }
    public void cargarJuegosAgua()
    {
        Mascota.Instance.guardarDatos();
        SceneManager.LoadSceneAsync(6);
     
    }
    public void cargarJuegosBasura()
    {
        Mascota.Instance.guardarDatos();
        SceneManager.LoadSceneAsync(4);

    }
    public void cargarJuegosPlantar()
    {
        Mascota.Instance.guardarDatos();
        SceneManager.LoadSceneAsync(5);
    }
    public void cargarJuegoNube()
    {
        SceneManager.LoadSceneAsync(7);
    }
}

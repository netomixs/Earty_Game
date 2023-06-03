using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuuPausa;
    public void pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuuPausa.SetActive(true);
    }
    
    public void reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuuPausa.SetActive(false);
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void cerrar()
    {
        Application.Quit();
    }

}

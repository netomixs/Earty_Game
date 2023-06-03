using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("La escena " + scene.name + " se cerr�.");
        // Realiza cualquier otra acci�n que necesites aqu�
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        // Registra la funci�n OnSceneUnloaded para el evento SceneManager.sceneUnloaded
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        Mascota.Instance.guardarDatos();
    }

    void OnDisable()
    {
        // Anula el registro de la funci�n OnSceneUnloaded para el evento SceneManager.sceneUnloaded
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}

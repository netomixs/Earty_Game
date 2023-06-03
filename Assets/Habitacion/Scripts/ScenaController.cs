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
        Debug.Log("La escena " + scene.name + " se cerró.");
        // Realiza cualquier otra acción que necesites aquí
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        // Registra la función OnSceneUnloaded para el evento SceneManager.sceneUnloaded
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        Mascota.Instance.guardarDatos();
    }

    void OnDisable()
    {
        // Anula el registro de la función OnSceneUnloaded para el evento SceneManager.sceneUnloaded
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}

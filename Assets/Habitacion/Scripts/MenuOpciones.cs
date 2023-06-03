using Firebase.Auth;
using Google;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{

    public GameObject menu;
    private FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostarVentana()
    {
        menu.SetActive(true);
    }
    public void ocultarVentana()
    {   
        menu.SetActive(false);
    }
    public void CerrarSesion()
    {
        SignOut();
    }
    public void cerrarJuego()
    {
      
    }
    private void SignOut()
    {
        // Cerrar la sesión actual
        auth.SignOut();
        Debug.Log("Sesión cerrada");
        Mascota.Instance.guardarDatos();
        Mascota.Instance.riniciar();
        OnSignOut();
        GoogleSignIn.DefaultInstance.Disconnect();
       auth = null;
        SceneManager.LoadSceneAsync(0);
        Mascota.Instance.Matar();
    }
    private void OnSignOut()
    {
        // AddToInformation("Calling SignOut");
        GoogleSignIn.DefaultInstance.SignOut();
    }
}   

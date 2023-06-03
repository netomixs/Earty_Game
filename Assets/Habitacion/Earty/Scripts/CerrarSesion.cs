using Firebase.Auth;
using Google;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CerrarSesion : MonoBehaviour
{
    private FirebaseAuth auth;
 
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SignOut()
    {
        // Cerrar la sesión actual
        auth.SignOut();
        Debug.Log("Sesión cerrada");
        Mascota.Instance.riniciar();
        OnSignOut();
  
        SceneManager.LoadSceneAsync(0);
    }
    private void OnSignOut()
    {
        // AddToInformation("Calling SignOut");
        GoogleSignIn.DefaultInstance.SignOut();
    }
}

using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class RecuperarPassword : MonoBehaviour
{
    Firebase.Auth.FirebaseUser user;
    private FirebaseAuth auth;
    public TMP_InputField email;
    public GameObject emergente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recuperar()
    {string correo=email.text;
        if (isCorreo(correo))
        {

            Task t = RecuperarPasword(correo);
            if (t.IsCompleted)
            {
                emergente.GetComponent<VentanaEmergente>().setText("Si el correo existe, se envio un correo con el cual podra recuparar su contraseña");
            }
        }

    }
    private bool isCorreo(string txt)
    {
        if (Regex.IsMatch(txt, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<Task> RecuperarPasword(string email )
    {
        auth = FirebaseAuth.DefaultInstance;
        return auth.SendPasswordResetEmailAsync(email).ContinueWith(task => {

            if (task.IsCanceled)
            {
                Debug.LogError("Envío de correo electrónico de restablecimiento de contraseña cancelado.");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Error al enviar correo electrónico de restablecimiento de contraseña: " + task.Exception);
            }
            else
            {
                Debug.Log("Correo electrónico de restablecimiento de contraseña enviado correctamente a " + email);
            }

        });
   

    }
}

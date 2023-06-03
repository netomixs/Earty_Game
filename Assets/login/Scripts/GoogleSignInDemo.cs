using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Google;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoogleSignInDemo : MonoBehaviour
{
    //public Text infoText;
    public string webClientId = "425072916453-slmu2ujqf2k1ee055hhbchqvc0r47nr0.apps.googleusercontent.com";
    Firebase.Auth.FirebaseUser user;
    private FirebaseAuth auth;
    private GoogleSignInConfiguration configuration;

    private void Awake()
    {
       configuration = new GoogleSignInConfiguration { WebClientId = webClientId, RequestIdToken = true,RequestEmail =true,RequestProfile=true };
       CheckFirebaseDependencies();
    }

    private void CheckFirebaseDependencies()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                    auth = FirebaseAuth.DefaultInstance;
                else
                {
                    //  AddToInformation("Could not resolve all Firebase dependencies: " + task.Result.ToString());

                }
            }
            else
            {
              //  AddToInformation("Dependency check was not completed. Error : " + task.Exception.Message);
            }
        });
    }

    public void SignInWithGoogle() {
        OnSignIn();

   
    }
    public void SignOutFromGoogle() { OnSignOut(); }

    private void OnSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
       //AddToInformation("Calling SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }

    private void OnSignOut()
    {
       // AddToInformation("Calling SignOut");
        GoogleSignIn.DefaultInstance.SignOut();
    }

    public void OnDisconnect()
    {
       // AddToInformation("Calling Disconnect");
        GoogleSignIn.DefaultInstance.Disconnect();
    }
 

    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        Debug.Log(task);
        //AddToInformation("task: "+task);
        if (task.IsFaulted)
        {
            using (IEnumerator<Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                   // AddToInformation("Got Error: " + error.Status + " " + error.Message);
                }
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                   // AddToInformation("Got Error: " + error.Status + " " + error.Message);
                }
                else
                {
                    //AddToInformation("Got Unexpected Exception?!?" + task.Exception);
                }
            }
        }
        else if (task.IsCanceled)
        {
          //  AddToInformation("Canceled");
        }
        else
        {
          //  AddToInformation("Welcome: " + task.Result.DisplayName + "!");
       //     AddToInformation("Email = " + task.Result.Email);
          //  AddToInformation("Google ID Token = " + task.Result.IdToken);
           // AddToInformation("Email = " + task.Result.Email);
            SignInWithGoogleOnFirebase(task.Result.IdToken);
            
        }
    }

    private void SignInWithGoogleOnFirebase(string idToken)
    {
        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);

        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            AggregateException ex = task.Exception;
            if (ex != null)
            {
                if (ex.InnerExceptions[0] is FirebaseException inner && (inner.ErrorCode != 0)) {

                    // AddToInformation("\nError code = " + inner.ErrorCode + " Message = " + inner.Message)

                }
            }
            else
            {
                user = task.Result;
                //   AddToInformation("Sign In Successful.");
                SceneManager.LoadSceneAsync(2);
                 

            }
        });
    }

    public void OnSignInSilently()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
       // AddToInformation("Calling SignIn Silently");

        GoogleSignIn.DefaultInstance.SignInSilently().ContinueWith(OnAuthenticationFinished);
    }

    public void OnGamesSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = true;
        GoogleSignIn.Configuration.RequestIdToken = false;

      //  AddToInformation("Calling Games SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }
    private  bool resgirtarConCorreoyPassword(string email,string password,string usuario)
    {
        bool estado=false;
          auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled)
        {
            estado = false;
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted)
        {
            estado = false;
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }
              if (task.IsCompleted)
              {

              }

        // Firebase user has been created.
        Firebase.Auth.FirebaseUser newUser = task.Result;
        estado = true;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        UserProfile perfil = new UserProfile { DisplayName = usuario };
        newUser.UpdateUserProfileAsync(perfil).ContinueWith(task=>{

        });
            Salir();
    });
        return estado;

    }
    void Salir()
    {
        auth = null;
    }
    public int InicioConCoreo(string email,string password)
    {
        int estado = 0;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                estado = 1;
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                estado = 2;
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            estado = 6;
            user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            SceneManager.LoadSceneAsync(2);
        });
        return estado;
    }
    public int RegistrarConCorreo(string email,string password,string usuario)
    {
        int estado = 0;
        auth.FetchProvidersForEmailAsync(email).ContinueWith(task => {
            if (task.IsCanceled)
            {
                estado = 1;
                Debug.LogError("La operación de verificación de usuario fue cancelada.");
                return;
            }

            if (task.IsFaulted)
            {
                estado = 2;
                return;
            }

            // Recuperar la lista de proveedores de inicio de sesión asociados con el correo electrónico
            List<string> proveedores = (List<string>)task.Result;

            if (proveedores.Count > 0)
            {
                 estado = 3;
                // El correo electrónico está registrado con al menos un proveedor de inicio de sesión
                Debug.Log("El usuario ya está registrado.");
            }
            else
            {
                // El correo electrónico no está registrado con ningún proveedor de inicio de sesión
       
                if (resgirtarConCorreoyPassword(email, password,usuario))
                {
                    estado = 5;
                }
                else
                {
                    estado = 4;
                }
            }
        });
        return estado;
    }

    //private void AddToInformation(string str) { infoText.text += "\n" + str; }
}
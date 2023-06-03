using Firebase.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
   public List<TMPro.TMP_InputField> lista;
    public GoogleSignInDemo inDemo;
    public Color error;
    public Color inputColor;
    string passwordActual="";
    string correo, password,usuario;
    public GameObject emergente;
    Firebase.Auth.FirebaseUser user;
    private FirebaseAuth auth;
    bool corectoRegistro=false;
    bool existe = false;
    int corectoInicio = 0;
    public GameObject Registro;
    public GameObject InicioSesion;
 
    //Detecta si hay una sesion iniciada
    void sesionStrar()
    {
   
        if (auth == null)
        {
            auth = FirebaseAuth.DefaultInstance;
        }
        if (auth.CurrentUser != null)
        { //Carga la escena del juego si es asi
            SceneManager.LoadSceneAsync(2);
        }

    }

    // Update is called once per frame
    void Update()
    {
      //Dependiendo el estado que se tome a resultado de las operaciones de registro e inicio de sesion dse meusytra una venta emergente
        if (corectoRegistro)
        {
            emergente.GetComponent<VentanaEmergente>().setText("Cuenta registrada");
            emergente.transform.Find("BotonPrincipal").GetComponent<Button>().onClick.AddListener(redireccionar);
             
        }
        if (existe)
        {
            emergente.GetComponent<VentanaEmergente>().setText("Cuenta ya existe con ese correo");
            emergente.transform.Find("BotonPrincipal").GetComponent<Button>().onClick.AddListener(redireccionar);
        }
        switch (corectoInicio)
        {
            case 1:
                emergente.GetComponent<VentanaEmergente>().setText("Error al autentificar usuario");
                corectoInicio = 0;
                break;
            case 2:
                emergente.GetComponent<VentanaEmergente>().setText("Iniciando...");
                corectoInicio = 0;
                sesionStrar();
                break;
            case 3:
                   emergente.GetComponent<VentanaEmergente>().setText("Correo no verificado");
                corectoInicio = 0;
                break;
            case 4:
                emergente.GetComponent<VentanaEmergente>().setText("Ha ocurrido un error inesperado");
                corectoInicio = 0;
                break;
            default:
                break;
        }

    }

    void redireccionar()
    {
        Registro.SetActive(false);
        InicioSesion.SetActive(true);
        
    }
    string[] arr = { "Ocurrio un error","La operación de verificación de usuario fue cancelada",
                      "La verificación del usuario falló inseperadamente",
                        "El usuario ya está registrado.",
                        "Algo salio mal al regsitrar el usuario",
                        "Registro exitoso",
                         "Inicio correcto"};
    // Metodo que se llama atravez del editor en el bton
    public void registrar()
    {
       
      RegistrarPorCorreoAsync();
    }
    float contador = 0;
    //Este metodo comprueba que no se tenga errores en el formulario de registro y despues registra el usuario
    public void RegistrarPorCorreoAsync()
    {
        if (comprovarErrores())
        {
            try { 
            auth.FetchProvidersForEmailAsync(correo).ContinueWith(a =>
            {
                List<string> list = (List<string>)a.Result;
                if (list.Count>0)
                {
                    existe= true;
                }
                else
                {
                    existe = false;
                }

            });
            }
            catch
            {

            }



            Task t =   resgirtarConCorreoyPassword(correo, password, usuario);
           
            if (t.IsCompleted)
            {
                corectoRegistro = true;
            }
            else
            {
            }
            
        }
    }
    //Este metodo comprueba que no se tenga errores en el formulario de incio de sesion con correo y despues inicia sesion
    public void InicioPorCorreo()
    {
        if (comprovarErrores())
        {
            Task t = InicioConCoreo(correo, password);    
        }
        else
        {

        }
    }
 //Metodo que verifica quelo s campos de los formularios referente al inico de sesion y registro sean correctos
   private bool comprovarErrores()
    {   passwordActual= string.Empty;
        int errores = 0;
        for (int i = 0; i < lista.Count; i++)
        {
            TMPro.TMP_InputField aux = lista[i];
            if (string.IsNullOrEmpty(aux.text) && lista[i].tag!="rec_correo")
            {
                aux.placeholder.color = error;
                Debug.Log("Error:" + aux.name);
                emergente.GetComponent<VentanaEmergente>().setText("Completa todos los campos");
                errores++;
                break;
            }
            else
            {
                aux.placeholder.color = inputColor;
                if (aux.tag == "correo")
                {
                    if (!isCorreo(aux.text))
                    {
                        Debug.Log("Correo error:" + aux.name);
                        aux.textComponent.color = error;
                        emergente.GetComponent<VentanaEmergente>().setText("El correo no es valido");
                        errores++;
                        break; ;
                    }
                    else
                    {
                        correo = aux.text;
                        aux.textComponent.color = inputColor;
                    }
                }
                if (aux.tag == "password" && passwordActual == "")
                {
                    passwordActual = aux.text;
                    if (!EsContrasenaFuerte(aux.text))
                    {
                        Debug.Log("Error Password:" + aux.name);

                        aux.textComponent.color = error;
                        emergente.GetComponent<VentanaEmergente>().setText("La contraseña debe de tener minimo una letra mayuscula, una minuscula, un numero y un caracter especial");
                        errores++;
                        break;
                    }
                    else
                    {
                        password = aux.text;
                        aux.textComponent.color = inputColor;
                    }
                }
                if (aux.tag == "password" && passwordActual != "")
                {
                    if (!aux.text.Equals(passwordActual))
                    {
                        Debug.Log("ErrorNo igual Password:" + aux.name);
                        aux.textComponent.color = error;
                        emergente.GetComponent<VentanaEmergente>().setText("Las contaseñas deben de coincidir");
                        errores++;
                        break;
                    }
                    else
                    {
                        aux.textComponent.color = inputColor;
                    }
                    passwordActual = "";
                }

                if (aux.tag == "usuario")
                {
                    usuario = aux.text;
                    Debug.Log("usuario recojico"+usuario);
                }
            
        }
        }
        if (errores>0)
        {
            return false;

        }
        else
        {
            return true;
        }
    }
    //Comprueba que el correo ingresado sea valido
    private bool isCorreo(string txt)
    {
        if(Regex.IsMatch(txt, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Compureba que la contraseña ingresada sea segura
    private  bool EsContrasenaFuerte(string contrasena)
    {
        if (contrasena.Length < 8)
        {
            return false;
        }

        bool tieneMinusculas = false;
        bool tieneMayusculas = false;
        bool tieneNumeros = false;
        bool tieneCaracteresEspeciales = false;

        foreach (char caracter in contrasena)
        {
            if (char.IsLower(caracter))
            {
                tieneMinusculas = true;
            }
            else if (char.IsUpper(caracter))
            {
                tieneMayusculas = true;
            }
            else if (char.IsDigit(caracter))
            {
                tieneNumeros = true;
            }
            else
            {
                tieneCaracteresEspeciales = true;
            }
        }

        return tieneMinusculas && tieneMayusculas && tieneNumeros && tieneCaracteresEspeciales;
    }
    private static bool ContieneMalaPalabra(string texto, List<string> palabrasProhibidas)
    {
        foreach (string palabra in palabrasProhibidas)
        {
            if (Regex.IsMatch(texto, @"\b" + palabra + @"\b", RegexOptions.IgnoreCase))
            {
                return true;
            }
        }
        return false;
    }
    public void RecuperarPassword()
    {
        auth = FirebaseAuth.DefaultInstance;
        string coroeoRecup = lista[4].text;
        if (string.IsNullOrEmpty(coroeoRecup))
        {
            emergente.GetComponent<VentanaEmergente>().setText("Ingresa correo");
        }
        else if (!isCorreo(coroeoRecup))
        {
            emergente.GetComponent<VentanaEmergente>().setText("Ingresa un correo valido");
        }
        else
        {
            auth.SendPasswordResetEmailAsync(coroeoRecup);
            emergente.GetComponent<VentanaEmergente>().setText("Se ha intentado enviar un correo para restablecer su contraseña. Revise su bandeja de entrada");
        }
       
    }
    //--------------------Ta bien puerco esta parte pero si le muevo deja de funcionar-------------------------------\
    //Registro por correo
    public async Task<Task> resgirtarConCorreoyPassword(string email, string password, string usuario)
    {
        auth = FirebaseAuth.DefaultInstance;
     
        return auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled){}
            if (task.IsFaulted){}
            if (task.IsCompleted)
            {
                user = task.Result;
                UserProfile perfil = new UserProfile { DisplayName = usuario };
                user.UpdateUserProfileAsync(perfil).ContinueWith(task => {
                    if (task.IsCompleted)
                    {
                        //Si se registro correctamente el usuario se marca como true
                        corectoRegistro = true;
                    }
                });
                if (user != null)
                {   //Si se creo el usuario se envia un correo de verificacion
                    user.SendEmailVerificationAsync().ContinueWith(task => {
                        if (task.IsCanceled){ }
                        else if (task.IsFaulted){ }
                        else
                        { }
                    });
                }
            }
        });


    }
    // Se usa para iniicar sesion con correo
    public async Task<Task> InicioConCoreo(string email, string password)
    {
        auth = FirebaseAuth.DefaultInstance;
        
        return auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            //Dependidon el estado corectoInicio cambia de valor
            if (task.IsCanceled)
            {  
                corectoInicio = 4;
                return;
            }
            if (task.IsFaulted)
            {
                corectoInicio = 1;
                auth.SignOut();
                return;
            }
            user = task.Result;
            //Verifica si el correo esta verificado
            if (user.IsEmailVerified)
            {
                corectoInicio =2;
            }
            else
            {
                corectoInicio = 3;
                auth.SignOut();
            }
        });
        
    }
}

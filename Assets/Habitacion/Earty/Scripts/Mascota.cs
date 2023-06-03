using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mascota : MonoBehaviour
{
    //Clase que se usa para guardar los datos actuales de Earty demas de algunos metods globales
 
    public static Mascota Instance { get;  set; }

    void Awake()
    {   
        dataController = GetComponent<DataController>();
        //Evita que la clase se destruya dcuando se cambia de escena.
        //Ademas que permite el acceso desde cualuqier clase
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
    public string Nombre;
    public float Limpieza;
    public float Aire;
    public float Agua;
    public float Bosque;
    public int tristeza;
    public bool parpadeo;
    public DateTime ultimoAcceso;
    DataController dataController;
    public bool isSave;
 
    private void Start()

    {   Nombre= "Earty";
        Limpieza = 100;
        Aire = 100;
        Agua = 100;
        Bosque = 100;
        tristeza = 0;
        isSave= false;
        ultimoAcceso=DateTime.Now;
        //Se cargan los datos si existen desde el servidor
        cargarDatos();

    }
    public void riniciar()
    {
        Nombre = "Earty";
        Limpieza = 100;
        Aire = 100;
        Agua = 100;
        Bosque = 100;
        tristeza = 0;
    }
    private void Update()
    {
        if (Agua>=100)
        {
            Agua= 100;
        }
        if (Bosque>=100)
        {
            Bosque= 100;
        }
        if (Aire >= 100)
        {
            Aire= 100;
        }
        if (Limpieza >= 100)
        {
            Limpieza= 100;
        }
        //
        if (Agua <= 0)
        {
            Agua = 0;
        }
        if (Bosque <= 0)
        {
            Bosque = 0;
        }
        if (Aire <= 0)
        {
            Aire = 0;
        }
        if (Limpieza <= 0)
        {
            Limpieza = 0;
        }

    }
    //Asigna los datos que se envia de la clase Modelo Mascota
    public void cargar(Modelo_Mascota datos)
    {
        this.Agua = datos.Agua;
       this.Aire = datos.Aire;
        this.Bosque = datos.Bosque;
        this.Limpieza= datos.Limpieza;
        this.ultimoAcceso= datos.ultimoAcceso;
        this.isSave=true;
    }
    //Recupera los datos de la clase mascota y los envian en formato de M<odelo Mascota
    public Modelo_Mascota àctualizar()
    {
        Modelo_Mascota datos= new Modelo_Mascota();
        datos.Agua= this.Agua;
        datos.Aire= this.Aire;  
        datos.Bosque= this.Bosque;
        datos.Limpieza= this.Limpieza;
        datos.ultimoAcceso= this.ultimoAcceso;
        
        return datos;

    }
    // Carga la escena principal desde cualquier escena
    public void GotoHome()
    {
       guardarDatos();
        SceneManager.LoadSceneAsync(2);
    }
    public void guardarDatos()
    {
        dataController.guardar();
    }
    public void cargarDatos()
    {
        dataController.cargar();
    }
    // Guarda los datos si se cierra la aplicacion
    private void OnApplicationQuit()
    {
        guardarDatos();
    }
    // Destruye esta clase 
    public void Matar()
    {
        Destroy(gameObject);
    }

}

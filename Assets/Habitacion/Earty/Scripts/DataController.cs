using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEditor;

public class DataController : MonoBehaviour

{
    public static DataController Instance { get; set; }
    // Start is called before the first frame update
    FirebaseFirestore db;
    FirebaseAuth firebaseAuth;
    public GameObject ventana;
    string userId;
    bool isCargado = false;
    private void Awake()
    {
        if (firebaseAuth==null)
        {
            firebaseAuth = FirebaseAuth.DefaultInstance;
        }
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // ventana = GameObject.FindGameObjectWithTag("Pop-up");
       
       
        if (isCargado==false)
        {
            
            // ventana.GetComponent<VentanaEmergente>().setText("false");
            if (firebaseAuth!=null)
            {
             
                // ventana.GetComponent<VentanaEmergente>().setText(firebaseAuth.CurrentUser.UserId);
                if (firebaseAuth.CurrentUser != null)
                {
                    userId = firebaseAuth.CurrentUser.UserId;
                   
                    cargar();
                    isCargado = true;
                }

            }

        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            guardar();
        }
        
    }
    //Metodo auxiliar para guardar datos en caso de cerrar la app
    void OnApplicationQuit()
    {
        if (userId!=null)
        {
            db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection("mascota").Document(userId);
            Modelo_Mascota datos = new Modelo_Mascota();
            datos = Mascota.Instance.àctualizar();
            datos.ultimoAcceso = DateTime.Now;
            docRef.SetAsync(datos);

        }

    }
    //Guardar datos en firebase
     public void guardar()
    {
        if (userId != null)
        {
            db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection("mascota").Document(userId);
            Modelo_Mascota datos = new Modelo_Mascota();
            datos = Mascota.Instance.àctualizar();
            datos.ultimoAcceso = DateTime.Now;
            docRef.SetAsync(datos);
        }
    }
    //Cargar los datos del servidor
    public void cargar()
    {
        if (userId != null)
        {
            db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection("mascota").Document(userId);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Modelo_Mascota mascota = snapshot.ConvertTo<Modelo_Mascota>();
                Mascota.Instance.cargar(mascota);
            }
        });
    }
    }
}

using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[FirestoreData]
public class Modelo_Mascota
{
    [FirestoreProperty]
    public string Nombre { get; set; }
    [FirestoreProperty]
    public float Limpieza { get; set; }
    [FirestoreProperty]
    public float Aire { get; set; }
    [FirestoreProperty]
    public float Agua { get; set; }
    [FirestoreProperty]
    public float Bosque { get; set; }
    [FirestoreProperty]
    public int tristeza { get; set; }
    [FirestoreProperty]
    public bool parpadeo { get; set; }
    [FirestoreProperty]
    public DateTime ultimoAcceso { get; set; }

    public Modelo_Mascota(string nombre, float limpieza, float aire, float agua, float bosque, int tristeza, bool parpadeo, DateTime ultimoAcceso)
    {
        Nombre = nombre;
        Limpieza = limpieza;
        Aire = aire;
        Agua = agua;
        Bosque = bosque;
        this.tristeza = tristeza;
        this.parpadeo = parpadeo;
        this.ultimoAcceso = ultimoAcceso;
    }

    public Modelo_Mascota()
    {
        Nombre = "";
        Limpieza = 0;
        Aire = 0;
        Agua = 0;
        Bosque = 0;
        this.tristeza = 0;
        this.parpadeo = false;
        this.ultimoAcceso = DateTime.Now;
    }
}

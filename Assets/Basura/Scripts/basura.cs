using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basura : MonoBehaviour
{

    public int valor = 1;
    public GameManager gameManager;
    // Clase que contine los botes.
    //Cuando un objeto llamado jugador chocaácon el boten se destruye
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.sumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
     
}

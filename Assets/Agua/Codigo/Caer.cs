using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Caer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objeto;
    Vector3 originalPos;
    public int tipoGota=1;
 
    public float tiempoEspera = 0.01f;
    public Vector3 origen;
    public GameObject Jugador;
    float defaulY  ;
    float defaulZ, defaulX;
    public float velocidadMaxima = 5f;
    private Rigidbody2D rb2D;
    void Start()
    {
     
        Debug.Log(Screen.safeArea.x);
        defaulX = objeto.transform.position.x;
        defaulY = objeto.transform.position.y;
        defaulZ = objeto.transform.position.z;
        rb2D = objeto.GetComponent<Rigidbody2D>();
        regenerar();
        //StartCoroutine(waiter()); 
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Jugador.transform.GetComponent<Jugador>().isPause)
        {

     
        if (Jugador.transform.GetComponent<Jugador>().vidad > 0) { 
            if (collision.gameObject.name=="Jugador")
        {
            switch (tipoGota)
            {
                case 0:
                    Jugador.transform.GetComponent<Jugador>().sumarPuntos(-2);
                    break;

                case 1:
                    Jugador.transform.GetComponent<Jugador>().sumarPuntos(2);
                    break;
                default:
                    break;

            }

            regenerar();
            }
       
        if (collision.gameObject.name=="Suelo")
        {
            Debug.Log(collision.gameObject.name);
            switch (tipoGota)
            {
                case 0:
                    Jugador.transform.GetComponent<Jugador>().sumarPuntos(1);
                    break;

                case 1:
                     Jugador.transform.GetComponent<Jugador>().restarVidas(1);
                    break;
                default:
                    break;

            }
            regenerar();
        }
        }
        }
    }
    void Update()
    {
        if (tiempoEspera>=0)
        {
            Vector3 vector = new Vector3(objeto.transform.position.x, defaulY, defaulZ);
            objeto.transform.position = vector;
            tiempoEspera-=Time.deltaTime;
        }
        else
        {

        }
        if (Jugador.transform.GetComponent<Jugador>().isPause)
        {
            rb2D.Sleep();
        }
        else
        {
            rb2D.WakeUp();
        }
        
    }
    void FixedUpdate()
    {
        if (rb2D.velocity.magnitude > velocidadMaxima)
        {
            rb2D.velocity = rb2D.velocity.normalized * velocidadMaxima;
        }
    }
    void regenerar()
    {
        if (Jugador.transform.GetComponent<Jugador>().vidad>0)
        {
            float num = Random.Range(-1.985F, 1.985F);
            Vector3 vector = new Vector3(num, defaulY, defaulZ);
            objeto.transform.position = vector;
            tiempoEspera = Random.Range(0, 5);
        }
        
     
    }
}

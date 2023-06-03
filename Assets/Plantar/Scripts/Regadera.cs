using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
//Control de regader
public class Regadera : MonoBehaviour
{
    public AudioSource audioSource;
    private Vector3 posInicial;
    private Quaternion rotacionInicial;
    private Vector3 posPadreInicial;
    private bool enMovimiento;
    public float max=50;
    public float contenido = 0;
    private float time=0;
    public float tiempoRecarga=2;
    private float largoBarra;
    public float velocidadDesgaste=3;
    public GameObject barra;
    public GameObject padre;
    private  ParticleSystem particleSystem;
    public float aguaGastada=0;
    private bool inCelda=false;

    // Start is called before the first frame update
    void Start()
    {
        reposicionar();
        particleSystem =GetComponent<ParticleSystem>();
        posInicial = transform.position;
        posPadreInicial=padre.transform.position;
        rotacionInicial = transform.rotation;
        enMovimiento = false;
        largoBarra = barra.transform.localScale.x;
        contenido = max;
      
        particleSystem.Stop();
        audioSource.Stop();

    }
    private void OnMouseDown()
    {
       
        // Inicia el movimiento cuando se hace clic en el objeto
        enMovimiento = true;

    }
    void OnMouseDrag()
    {
        if (enMovimiento)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1f;
            padre.transform.position = mousePosition;
            Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
            //Si colisona con una celda se actiiva la regadera
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Celda"))
                {
                    if (inCelda==false)
                    {
                        if (contenido>0)
                        {   //Por cada segundo que pasa se resta agua
                            aguaGastada += Time.deltaTime * velocidadDesgaste;
                            contenido = contenido = contenido - Time.deltaTime * velocidadDesgaste;
                            //Se activa la animacion
                            particleSystem.Play();
                            if (particleSystem.isPlaying)
                            {
                                if (!audioSource.isPlaying)
                                {
                                    audioSource.Play();
                                }
                            } 
                        }
                        else
                        {
                            particleSystem.Stop();
                            audioSource.Stop();
                        }
                        transform.rotation = Quaternion.Euler(0f, 0f, 15f);
                        inCelda = true;
                    }
                }
                else
                {
                    inCelda = false;

                }
            }
        }
    }
    void OnMouseUp()
    {
        //transform.position = posInicial;
        transform.rotation = rotacionInicial;
        padre.transform.position = posPadreInicial;
        particleSystem.Stop();
        audioSource.Stop();
    }

   
    void Update()
    {
      
        float porcentaje = largoBarra/max;
        if (posInicial == transform.position)
        {
            if (contenido<max)
            {
                time+= Time.deltaTime;
                if (time>= tiempoRecarga)
                {
                    contenido = contenido + 1;
                    time = 0;
                }

            }

        }


        barra.transform.localScale=new Vector3(contenido * porcentaje, barra.transform.localScale.y, barra.transform.localScale.z);
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Celda")) // Si la partícula colisiona con un objeto con el tag "Objetivo"
        {
            other.gameObject.GetComponent<Celda>().upMojado(1);
        }
    }

    void reposicionar()
    {
        // Obtenemos el tamaño de la pantalla en píxeles
        // Obtenemos la posición de la cámara en el mundo
        Vector3 cameraPosition = Camera.main.transform.position;

        // Convertimos la coordenada de la pantalla a una coordenada del mundo utilizando la cámara
        Vector3 worldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - cameraPosition;

        // Obtenemos la medida del mundo de la pantalla dividiendo el ancho de la pantalla entre el ancho en coordenadas del mundo
        float worldScreenWidth = worldWidth.magnitude;
        Renderer renderer = GetComponent<Renderer>(); // Obtenemos el componente Renderer del objeto actual
        Vector3 size = renderer.bounds.size;
        // Calculamos la posición del objeto
        float posX = worldScreenWidth / 2;
        posX = posX- size.x;
            ;

        // Posicionamos el objeto en la posición calculada
        padre.transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}

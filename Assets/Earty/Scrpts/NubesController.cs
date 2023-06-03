using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
 
//Controlador de nubes
public class NubesController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float forceMultiplier = 5f;
    public AudioSource audioSource;
    private Vector2 touchStartPos;
    private float touchStartTime;
    public float minSwipeDistance = 10f;
    public bool tocar = false;
    public float visibilityRange = 0.2f;
    public bool isTocable=true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        Renderer renderer = gameObject.GetComponent<Renderer>();

        // Comprobar si el objeto está dentro del rango de visibilidad
        bool isVisible = screenPos.x >= -visibilityRange && screenPos.x <= 1 + visibilityRange && screenPos.y >= -visibilityRange && screenPos.y <= 1 + visibilityRange && screenPos.z > 0;
        // Si el objeto no está dentro del rango de visibilidad, desactivarlo
        if (!isVisible)
        {
            renderer.enabled = false;
            gameObject.transform.position = new Vector3(0,0,transform.position.z);
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {
        if (isTocable==false)
        {
            // rb.velocity = new Vector2(0,0);
            rb.velocity = rb.velocity.normalized * speed;
            GetComponent<SpriteRenderer>().color= Color.black;
        }
        else
        {
            rb.velocity = rb.velocity.normalized * speed;
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        // Mantener la velocidad constante
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.name== "arriba")
            {
                Debug.Log("arriba");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, speed* 5), ForceMode2D.Impulse);
        }
            if (collision.gameObject.name == "abajo")
            {
            Debug.Log("abajo");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, speed* 5), ForceMode2D.Impulse);
            }
            if (collision.gameObject.name == "izquierda")
            {
            Debug.Log("izda");

            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed* 5, speed), ForceMode2D.Impulse);

            }
            if (collision.gameObject.name == "derecha")
            {
            Debug.Log("derecha");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(speed   * 5 , speed), ForceMode2D.Impulse);

            }
   
    }
    //Metodo que seésa para seguir el toque con una nube
    private void OnMouseDrag()
    {
        if (tocar && isTocable)
        {
            audioSource.Play();
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 1f;
            transform.position = mousePosition;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10,10), Random.Range(-10, 10)), ForceMode2D.Impulse);

        }
    }
    private void OnMouseDown()
    {
        tocar = true;
       
    }
    private void OnMouseUp()
    {
        tocar = false;
    }
}


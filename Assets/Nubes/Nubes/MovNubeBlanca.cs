using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class MovNubeBlanca : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 initialPosition;
    private bool touched;
    public int targetCount;
    public ControllerNube controlador;
    public AudioSource tocar;
    float posX_target, posX_nube;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        posX_target = target.position.x;
        posX_nube = initialPosition.x;
        touched = false;
        targetCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = controlador.speed;
        if (!touched)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                float newY1 = Random.Range(-3.4f, 3.75f);
                float newY2 = Random.Range(-3.4f, 3.75f);
                transform.position = new Vector3(posX_nube, newY1, initialPosition.z);
                target.position = new Vector3(posX_target, newY2, target.position.z);
                swapOrintation(); ;
            }
        }

        // Detectar toques en dispositivos móviles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                tocar.Play();
                // Obtener posición del toque en el mundo
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Verificar si el toque ocurrió sobre el objeto
                if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
                {
                    // Lógica para el inicio de un toque en el objeto
                    touched = true;
                    gameObject.SetActive(false);
                    float respawnTime = Random.Range(1f, 5f);
                    Invoke("Respawn", respawnTime);

                    // Aumentar el puntaje
                    controlador.perdida++;
                }
            }
        }
    }

    void Respawn()
    {
        float newY1 = Random.Range(-3.4f, 3.75f);
        float newY2 = Random.Range(-3.4f, 3.75f);
        transform.position = new Vector3(posX_nube, newY1, initialPosition.z);
        target.position = new Vector3(posX_target, newY2, target.position.z);
        swapOrintation();
        gameObject.SetActive(true);
        touched = false;
        controlador.aumentarVelocidad(1);
    }
    private void swapOrintation()
    {

        if (Random.Range(0, 10) >= 5)
        {
            float aux = posX_nube;
            posX_nube = posX_target;
            posX_target = aux;
        }

    }

}
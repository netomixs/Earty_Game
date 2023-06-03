
using UnityEngine;
//Controlador de nueb
public class MovNubeNegra : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 initialPosition;
    private bool touched;
    public int score; // Variable para almacenar el puntaje
    public ControllerNube controlador;
    public AudioSource audio;
    float posX_target, posX_nube;
    void Start()
    {
        initialPosition = transform.position;
        touched = false;
        score = 0; // Inicializar el puntaje en 0
        posX_target=target.position.x;
        posX_nube=initialPosition.x;
    }

    //Cada fream se mueve la nuebe hacia un objetivo definido el ectremo opuesto
    void Update()
    {
        speed=controlador.speed;
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
                swapOrintation();
                controlador.perdida++;
            }
        }

        // Detectar toques en dispositivos móviles
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                audio.Play();
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

                    // Incrementar el puntaje
                    score++;
                    Debug.Log("Puntaje: " + score);
                }
            }
        }
    }
    void tocar()
    {
        // Lógica para el inicio de un toque en el objeto
        touched = true;
        gameObject.SetActive(false);
        float respawnTime = Random.Range(1f, 5f);
        Invoke("Respawn", respawnTime);

        // Incrementar el puntaje
        score++;
        Debug.Log("Puntaje: " + score);
    }
    //Cada vez que se necesite reaparecer se cambia la posicion inical y la pocision de llegada.
    //En el eje z siempre es es el mismo 
    void Respawn()
    {
        float newY1 = Random.Range(-3.4f, 3.75f);
        float newY2 = Random.Range(-3.4f, 3.75f);
        transform.position = new Vector3(posX_nube, newY1, initialPosition.z);
        target.position = new Vector3(posX_target, newY2, target.position.z);
        swapOrintation();
        gameObject.SetActive(true);
        touched = false;
        controlador.aumentarVelocidad(.5f);
    }
    //qutar
    private void OnMouseDown()
    {
        tocar();
    }
    private void swapOrintation()
    {

        if (Random.Range(0,1)==1)
        {
            float aux = posX_nube;
            posX_nube = posX_target;
            posX_target= aux;
        }

    }
}

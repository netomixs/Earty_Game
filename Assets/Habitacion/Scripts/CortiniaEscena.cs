
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CortiniaEscena : MonoBehaviour
{
    public GameObject barra;
    GameObject indicador;
    RectTransform rec;
    float minimo, maximo;
    public GameObject pantalla;
    public TMPro.TMP_Text mensaje;
    private string fileName = "MensajesBienvenida";
    bool activada = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale= 1.0f;
        TextAsset asset = Resources.Load(fileName) as TextAsset;

        if (asset != null)
        {
            if (activada==false)
            {
                // Separar el contenido del archivo en líneas
                string[] lineas = asset.text.Split('\n');
                int lineaN = Random.Range(0, 29);
                mensaje.text = lineas[lineaN];
                activada = true;
            }
           
        }
    }
    void Start()
    {
        indicador = barra.transform.GetChild(0).gameObject;
        Debug.Log(indicador.name);
        rec = indicador.transform.GetComponent<RectTransform>();
        maximo = rec.offsetMax.x;
        minimo = rec.rect.width;
        rec.offsetMax = new Vector2((minimo + maximo), rec.offsetMax.y);
       
    }
        float time = 0;
    public int dureacion=3;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time < dureacion)
        {
            // Debug.Log("TIempo:" + time);
            PintarBarraCarga((int)time * (100/ dureacion));
        }
        else
        {
            pantalla.SetActive(false);
        }


    }

    void PintarBarraCarga(int porcentaje)
    {
        float aux = minimo / 100;
        float actual = aux * porcentaje;
        rec.offsetMax = new Vector2((-(minimo - maximo)) + actual, rec.offsetMax.y);
    }


}


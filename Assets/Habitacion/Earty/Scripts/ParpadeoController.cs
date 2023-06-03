using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoController : MonoBehaviour
{
    public FaceController faceList;
    public GameObject face; 
    [Range(0f, 10f)]
    public float intervaloParpadeo = 5f;
    [Range(0f, 10f)]
    public float duracionParpadeo=0.2f;
    public float timeCerrado = 0;
        public float timeAbierto = 0;
    public bool parpaedo=true;
    public List<GameObject> ListaCara;
    SpriteRenderer img;
    public Sprite ejemplo;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        if (parpaedo)
        {

            Mascota.Instance.parpadeo = true;
            Debug.Log("Parpadeo");
            img = face.transform.GetComponent<SpriteRenderer>();
            img.sprite = ListaCara[Mascota.Instance.tristeza].GetComponent<Face>().getParpaedeo();
         
          //  face.transform.localPosition=new Vector3(face.transform.localPosition.x,face.transform.localPosition.y,-1.5f);
            //face.transform.position = new Vector3(face.transform.position.x, face.transform.position.y, -1.5f);
            timeCerrado += Time.deltaTime;
        }
        else
        {
            Mascota.Instance.parpadeo = false;
            img = face.transform.GetComponent<SpriteRenderer>();
            img.sprite = ListaCara[Mascota.Instance.tristeza].GetComponent<Face>().getCara();
           // face.transform.localPosition = new Vector3(face.transform.localPosition.x, face.transform.localPosition.y, -.3f);

            timeAbierto += Time.deltaTime;
        }
        if (timeCerrado>=1)
        {
            parpaedo= false;
            timeCerrado = 0;
            
        }
        if (timeAbierto>=intervaloParpadeo)
        {
            parpaedo= true;
            timeAbierto = 0;
        }

    }
}

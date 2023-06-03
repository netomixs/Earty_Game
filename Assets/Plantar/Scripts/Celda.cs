using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Controla las celdas del tablero
public class Celda : MonoBehaviour
{
    public GameObject textura;
    private float tiempoSecar = 0;
    private float nivelMojado=0;
    public float tiempoRetrencionHumedads = 10;
    public float catidadAgua=20;
    public bool isHumedo=false;
    private void Update()
    {//Principalmente si la celda esta mojada o no
        if (tiempoSecar>0)
        {
            tiempoSecar-= Time.deltaTime;
        }
        if (tiempoSecar<=0)
        {
            secar();
           
            isHumedo = false;
        }
        if (nivelMojado>0)
        {
            nivelMojado -= Time.deltaTime/2;
        }
        if (nivelMojado>= catidadAgua)
        {
            humedo(tiempoRetrencionHumedads);
            nivelMojado = 0;
            isHumedo = true;
        }
    }
    //Funciones que cambian el especto de la celda dependiendo el estado
    private void humedo(float tiempo)
    {
        tiempoSecar = tiempo;
        SpriteRenderer spriteRenderer = textura.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

    }
    private void secar()
    {
        SpriteRenderer spriteRenderer = textura.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);

    }
    public void upMojado(float nivel)
    {
        nivelMojado += nivel;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Paricula:"+collision.gameObject.tag+"En "+gameObject.tag);
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Paricula2:" + other.gameObject.tag + "En " + gameObject.tag);
    }
}

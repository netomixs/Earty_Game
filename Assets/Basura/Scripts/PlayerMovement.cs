using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Control de movimiento de personaje
public class PlayerMovement : MonoBehaviour
{   //paraámetros del personaje
    public float velocidad;
    public float salto;
    public int saltosMax;
    public LayerMask capaSuelo;
    private Rigidbody2D rigiBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private int saltosRestantes;
    private Animator animator;
    private bool isIzquierda,isDerecha, isSalto;

    void Start()
    {
        //Inicializacion de parametros iniciales
        rigiBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        saltosRestantes = saltosMax;
        isIzquierda = false;
        isDerecha = false;
        isSalto = false;
    }

    // Update is called once per frame
    void Update()
    {   //Cada frame se procesa un accion
        procesarMov();
        procesarSalto();
    }
    //Retorna true si se esta en el suelo
    bool estaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    // detecta cuado se da la accion de salto
    void procesarSalto()
    {
        if (estaEnSuelo())
        {
            saltosRestantes = saltosMax;
        }

        if (isSalto && saltosRestantes>0)
        {
            saltosRestantes -= 1;
            rigiBody.AddForce(Vector2.up*salto, ForceMode2D.Impulse);
        }
    }
    //Detecta cuando se esta en miviemnto y si no se da mas impulos cuano se activa las teclas de movimiento horizontal
    void procesarMov()
    {
        float inputMov = 0;
        if (isDerecha) inputMov = 1;
        if (isIzquierda) inputMov = -1;
        if (isIzquierda == false && isDerecha == false) inputMov = 0;
        
        if(inputMov != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        rigiBody.velocity = new Vector2(inputMov * velocidad, rigiBody.velocity.y);

        gestionarMovimiento(inputMov);
    }
    // Cambia la orientacion del personaje dependiendo la direciona a la que se mueve
    void gestionarMovimiento(float inputMov)
    {

        if ((mirandoDerecha == true && inputMov<0) || (mirandoDerecha == false && inputMov>0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

    public void picoIzquierda()
    {
        isIzquierda = true;
    }
    public void picoDerecha()
    {
        isDerecha = true;
    }

    public void picoSalto()
    {
        isSalto = true;
    }

    public void sueltoIzquierda()
    {
        isIzquierda = false;
    }
    public void sueltoDerecha()
    {
        isDerecha = false;
    }

    public void sueltoSalto()
    {
        isSalto = false;
    }

}

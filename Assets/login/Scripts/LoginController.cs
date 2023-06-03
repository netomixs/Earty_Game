using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public GameObject PanelRegistroSelect;
    public GameObject PanelLoginSelect;
 
    public GameObject PanelLogin;
    public GameObject PanelRegistro;
    public GameObject PanelRecuperarpassword;
    bool isLogin=false;
   
    public TMPro.TMP_Dropdown dropdown;
    int edad;
    private static FirebaseAuth auth;
    void Start()
    {
        if (auth == null)
        {
            auth = FirebaseAuth.DefaultInstance;
        }
        if (auth.CurrentUser!=null)
        {
            isLogin = true;
        }

        if (isLogin)
        {
            cambiarAPrincipal();
        }
        else
        {
 
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
        //RectTransform rec = PanelCarga.transform.GetComponent<RectTransform>();
        
      //  Debug.Log(rec.offsetMax);
    }
    public void cambiarLoginSelect_RegistroSelect()
    {
        PanelRegistroSelect.SetActive(true);
        PanelLoginSelect.SetActive(false);
    }
    public void cambiarResgitroSelect_LoginSelect()
    {
        PanelRegistroSelect.SetActive(false);
        PanelLoginSelect.SetActive(true);
    }
    public void cambiarRegistroSelect_RegistroPorCorreo()
    {
        PanelRegistroSelect.SetActive(false);
        PanelRegistro.SetActive(true);

    }
    public void cambiarAPrincipal()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void cambiarSelectEdad_RegistroSelect()
    {   edad=dropdown.value;
   
        PanelRegistroSelect.SetActive(true) ;
    }
    public void regresarSelectRegsitro()
    {
        PanelLoginSelect.SetActive(false);
        PanelLogin.SetActive(false);
        PanelRegistro.SetActive(false);
        PanelRegistroSelect.SetActive(true);
    }
    public void regresarSelectLogin()
    {
     
        PanelLoginSelect.SetActive(true);
        PanelLogin.SetActive(false);
        PanelRegistro.SetActive(false);
        PanelRegistroSelect.SetActive(false);
    }
    public void cambiarLoginSelect_LoginPorCorreo()
    {
        PanelLoginSelect.SetActive(false);
        PanelLogin.SetActive(true);
    }
    public void cambiarRegistroSelect_RegsitroPorCorreo()
    {
        PanelRegistro.SetActive(true);
        PanelRegistroSelect.SetActive(false);
    }
    public void abrirRecuperarPassword()
    {
        PanelRecuperarpassword.SetActive(true);
        PanelLogin.SetActive(false);
    }
    public void cambiarRecuperarpassword_PanelLogin()
    {
        PanelRecuperarpassword.SetActive(false);
        PanelLogin.SetActive(true);
    }
}

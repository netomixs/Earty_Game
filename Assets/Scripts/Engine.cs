using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Engine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] TextMeshProUGUI timerText;
    public int score = 0;
    [SerializeField] int scoreToGetLife = 0; //score which is needed to get extra life
    public int LiveAdderForScore = 0; //counter for next extra life
    public int lifes = 3;
    [SerializeField] bool gameOver = false;

    float timer;
    float seconds;
    float minutes;

    public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    public VentanaEmergente mensaje;
    bool mensajeMostrdo = false;
    void Start()
    {
        timer = 0;
        mensaje.setText("Atrapa los quimicos peligrosos");
                       //
    }

    // Update is called once per frame
    void Update()
    {
        if (mensajeMostrdo == false)
        {
            Time.timeScale = 0;
            if (mensaje.isActiveAndEnabled)
            {
                Time.timeScale = 0;

            }
            else
            {
                Debug.Log("normal");
                Time.timeScale = 1;
                mensajeMostrdo = true;
            }
        }
        else
        {
            scoreText.text = score.ToString();
            if (lifes < 1)
            {
                lifesText.text = "";
            }
            else
            {
                lifesText.text = lifes.ToString();
            }

            StopWatchCalc(); //calculation for stopwatch

            //pause menu system
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f; //pause time when pause active
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }

            if (Input.GetKeyDown(KeyCode.Escape))//enables pause when esc presed
            {
                ChangePauseState();
            }

            //adds life if extra life counter is greater than var of getting extra life
            if (LiveAdderForScore >= scoreToGetLife)
            {
                lifes++;
                LiveAdderForScore = 0;
            }

            if (gameOver)
            {
                gameOverMenu.SetActive(true);
                Mascota.Instance.Agua += score;
                Mascota.Instance.guardarDatos();
            }
            else
            {
                gameOverMenu.SetActive(false);
            }

            if (gameOverMenu.activeSelf)
            {
                Time.timeScale = 0f;
            }

            if (lifes < 1)
            {
                gameOver = true;
            }
        }
        

    }

    //stopwatch system which count play time
    void StopWatchCalc()
    {
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
            minutes = (int)timer / 60;
            if (seconds < 10)
            {
                timerText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString();
            }
    }

    public void ChangePauseState()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void Restart()
    {   Mascota.Instance.guardarDatos();
        SceneManager.LoadScene(6);
    }
}

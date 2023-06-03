using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ManagervIDEO : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button[] buttons;
    public VideoClip[] videos;
    public GameObject Ventanal;
    int indexB = 0;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Importante: crear una variable local para almacenar el valor de 'i'
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
        videoPlayer.loopPointReached += OnVideoFinished;
    }
    private void OnVideoFinished(VideoPlayer vp)
    {
        indexB++;
        if (indexB == 5)
        {
            indexB = 0;
        }
        OnButtonClick(indexB);

    }
    private void Update()
    {

    }
    private void OnButtonClick(int buttonIndex)
    {
        videoPlayer.Stop();
        videoPlayer.clip = videos[buttonIndex];
        videoPlayer.Play();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i != buttonIndex);
        }
    }
    public void abirAyuda()
    {
        Ventanal.SetActive(true);
  
        OnButtonClick(0);

    }
    public void CerrarAyuda()
    {
        Ventanal.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuenteCambiar : MonoBehaviour
{
    // Start is called before the first frame update

        public TMP_FontAsset newFont;

    void Start()
    {
        ajustar();

    }
    void ajustar()
    {

        // Find all TextMeshPro components in the scene
        TMP_Text[] textMeshPros = FindObjectsOfType<TMP_Text>();
        bool[] initialActiveStates = new bool[textMeshPros.Length];
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            initialActiveStates[i] = textMeshPros[i].gameObject.activeSelf;
        }
        // Loop through each TextMeshPro component and change the font
        foreach (TMP_Text textMeshPro in textMeshPros)
        {
            textMeshPro.font = newFont;
            RectTransform rectTransform = textMeshPro.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector2 newAnchorPos = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + (rectTransform.rect.height * 0.2f));
                rectTransform.anchoredPosition = newAnchorPos;
            }
        }
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            textMeshPros[i].gameObject.SetActive(initialActiveStates[i]);
        }

    }
    // Update is called once per frame
    void Update()
    {
       


    }
}

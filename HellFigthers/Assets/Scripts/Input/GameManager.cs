using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using UnityEditor.PackageManager;

public class GameManager : MonoBehaviour
{
    public int puntos;
    public TMP_Text puntosT;
    public TMP_Text timeT;
    public float time;

    private void Update()
    {
        time = time + 0.1f;
        timeT.text = time.ToString();
        puntosT.text = puntos.ToString();

        Debug.Log(puntos);
    }
}

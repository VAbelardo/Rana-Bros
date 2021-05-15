using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamaOverManager : MonoBehaviour
{
    public GameObject button1;

    // Start is called before the first frame update
    void Start()
    {


        var dataguardada = FindObjectOfType<SaveData>().LoadData();
        Debug.Log($"puntos anteriores { dataguardada.puntaje}");
        DataGuardable infoAGuardar = new DataGuardable();
        infoAGuardar.nombre = "pedro";
        infoAGuardar.puntaje = 500;
        infoAGuardar.tiempoJuego = 15.60f;
        string json = JsonUtility.ToJson(infoAGuardar);
        Debug.Log($"Json es {json}");
        FindObjectOfType<SaveData>().saveDataNow(json);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
        GameManager.ReiniciarValores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

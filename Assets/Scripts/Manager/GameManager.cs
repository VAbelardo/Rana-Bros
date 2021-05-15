using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int points;
    public static int vida;

    [Header("Ui elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI veoVidas;

    public GameObject botonBrinco;
    public GameObject botonIzquierda;
    public GameObject botonDerecha;

    public static void ReiniciarValores()
    {
        points = 0;
        vida = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        AgregarPuntos(0);
        veoVidas.text = vida.ToString();
#if(UNITY_STANDALONE || UNITY_WEBGL)
        /*botonBrinco.SetActive(false);
        botonIzquierda.SetActive(false);
        botonDerecha.SetActive(false);*/
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgregarPuntos(int puntos)
    {
        points += puntos;
        scoreText.text = points.ToString("0000");
    }

    public void HaMuertoElPersonaje()
    {
        
        vida--;
        veoVidas.text = vida.ToString();
        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TerminoNivel()
    {
        int indexActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexActual + 1);
    }
}

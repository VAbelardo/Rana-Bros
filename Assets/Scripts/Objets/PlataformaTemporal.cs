using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTemporal : MonoBehaviour
{

    public float tiempoPlataforma;
    public bool seNecesitaRestablecer;

    public GameObject modelo;
    Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        posicionInicial = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EmpezarACaer());
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Collector"))
        {
            if (seNecesitaRestablecer)
            {
                Instantiate(modelo, posicionInicial, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        
    }

    IEnumerator EmpezarACaer()
    {
        yield return new WaitForSeconds(tiempoPlataforma);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Animator>().Play("apagado");
    }
}

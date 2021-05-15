using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Plataforma : MonoBehaviour
{
    public float distanciaMovimiento;
    public float velocidadMovimiento;

    public float direccion = 1;
    public float distanciaParaActivar;

    Transform target;

    Vector2 posicionInicial;
    Vector2 posicionFinal;

    bool estaVisible;
    bool seEstaMoviendo;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;

        /*distanciaMovimiento = Mathf.Abs(distanciaMovimiento);
        posicionInicial = new Vector2(transform.position.x - distanciaMovimiento, transform.position.y);
        posicionFinal = new Vector2(transform.position.x + distanciaMovimiento, transform.position.y);*/

        if (distanciaMovimiento < 0)
        {
            posicionInicial = new Vector2(transform.position.x + distanciaMovimiento, transform.position.y);

            posicionFinal = transform.position;
        }
        else
        {
            posicionInicial = transform.position;
            posicionFinal = new Vector2(transform.position.x + distanciaMovimiento, transform.position.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (estaVisible)
        {
            MoverPlataforma();
        }
        else
        {
            bool seDebeMover = Vector3.Distance(transform.position, target.position) < distanciaParaActivar;
            if (seDebeMover)
            {
                MoverPlataforma();
            }
        }
    }

    private void OnBecameVisible()
    {
        estaVisible = true;
    }

    private void OnBecameInvisible()
    {
        estaVisible = false;
    }

    private void MoverPlataforma()
    {
        transform.Translate(Vector2.right * direccion * velocidadMovimiento * Time.deltaTime);

        if (posicionFinal.x <= transform.position.x)
        {
            direccion = -1;
        }

        if (posicionInicial.x >= transform.position.x)
        {
            direccion = 1;
        }
    }
}

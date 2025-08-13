using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benSeguimiento : MonoBehaviour
{
    public GameObject jugador;
    public float velocidad;
    private bool toby;
    private Vector3 objetivo;
    public SpriteRenderer sprite;
    public void cambioObjetivo()
    {
        toby = !toby;
    }
    public void aumentoNivel()
    {
        velocidad += 0.15f;
    }
    void Update()
    {
        if (toby)
            objetivo = new Vector3(-2.36f, 1.074f, -0.009f);
        else
            objetivo = jugador.transform.position;

        if (transform.position.x - objetivo.x < 0 && sprite.flipX == false)
        {
            sprite.flipX = true;
        }
        else if (transform.position.x - objetivo.x > 0 && sprite.flipX == true)
        {
            sprite.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("killeable"))
        {
            Debug.Log("bum muerto");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class benSeguimiento : MonoBehaviour
{
    public GameObject jugador;
    public float velocidad;
    public RectTransform benImagen;
    private bool toby;
    private float distancia;
    private Vector3 objetivo;
    public SpriteRenderer sprite;
    public void cambioObjetivo()
    {
        toby = !toby;
    }
    public void aumentoNivel()
    {
        velocidad += 0.1f;
    }
    void muerte()
    {
        PlayerPrefs.SetInt("redo", 1);
        SceneManager.LoadScene("acto2");
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

        distancia = -Vector3.Distance(transform.position, new Vector3(-2.36f, 1.074f, -0.009f)) * 50;
        if (distancia < -349)
            benImagen.transform.localPosition = new Vector3(-349, 162.7f, 0);
        else if (distancia == 0)
            muerte();
        else
            benImagen.transform.localPosition = new Vector3(distancia, 162.7f, 0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("killeable"))
        {
            muerte();
        }
    }
}

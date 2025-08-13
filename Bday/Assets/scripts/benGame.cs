using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class benGame : MonoBehaviour
{
    private float velocidad = 120;
    private float cantidadRestante = 4;
    private Vector3 centro;
    public Animator generador;
    public GameObject gameplayUI;
    public GameObject jugadorManecilla;
    public GameObject circulo;
    public GameObject areaManecilla;
    public AudioSource error;
    public AudioSource buena;
    [NonSerialized] public bool tocando;
    void Update()
    {
        centro = circulo.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if (tocando)
            {
                buena.Play();
                cantidadRestante -= 1;
                if (cantidadRestante == 0)
                {
                    generador.SetBool("destruido", true);
                    cantidadRestante = 4;
                    velocidad += 80;
                    gameplayUI.SetActive(true);
                    enabled = false;
                }
            }
            else
            {
                error.Play();
            }
            areaManecilla.transform.RotateAround(centro, Vector3.forward, UnityEngine.Random.Range(50, 361));
        }
        areaManecilla.transform.RotateAround(centro, Vector3.forward, -velocidad / 2 * Time.deltaTime);
        jugadorManecilla.transform.RotateAround(centro, Vector3.forward, velocidad * Time.deltaTime);
    }
}

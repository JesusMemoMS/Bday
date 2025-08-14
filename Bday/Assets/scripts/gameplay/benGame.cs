using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class benGame : MonoBehaviour
{
    private float velocidad = 120;
    private int puntos = 0, cantidadRestante = 3;
    private int cantidadEstandar = 3;
    private Vector3 centro;
    public Animator oscuridad;
    public GameObject jugadorManecilla;
    public GameObject circulo;
    public GameObject areaManecilla;
    public AudioSource error;
    public AudioSource buena;
    public UnityEvent gameTerminado;
    public UnityEvent benVencido;
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
                    cantidadEstandar++;
                    puntos++;
                    oscuridad.SetInteger("puntos", puntos);
                    cantidadRestante = cantidadEstandar;
                    velocidad += 80;
                    if (puntos == 4)
                    {
                        benVencido.Invoke();
                    }
                    gameTerminado.Invoke();
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
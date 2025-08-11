using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class seguimientoScript : MonoBehaviour
{
    public GameObject jugador;
    public Vector3 posAnterior;
    public UnityEvent playerEvent;
    public bool activo;
    private Queue<Vector3> posiciones;
    private Queue<int> direccion;
    private Animator anims;
    private Vector3 objetivo;
    private bool moverse;
    void Start()
    {
        anims = GetComponent<Animator>();
        posiciones = new Queue<Vector3>();
        direccion = new Queue<int>();
    }
    public void EventoPlayer(Vector3 pos, int dir)
    {
        if (activo)
        {
            if (pos == Vector3.zero)
            {
                Debug.Log("ay");
                moverse = false;
                anims.SetBool("idle", true);
            }
            else
            {
                StartCoroutine(wasf(pos, dir));
            }
        }
    }
    IEnumerator wasf(Vector3 pos, int dir)
    {
        yield return new WaitUntil(() => posAnterior != jugador.transform.position);
        moverse = true;
        anims.SetBool("idle", false);
        direccion.Enqueue(dir);
        posiciones.Enqueue(pos);
    }
    void FixedUpdate()
    {
        if (moverse)
        {
            if (posiciones.Count == 0)
                objetivo = jugador.transform.position;
            else
            {
                if (transform.position == posiciones.Peek())
                {
                    posiciones.Dequeue();
                    direccion.Dequeue();
                }
                if (posiciones.Count == 0)
                {
                    objetivo = jugador.transform.position;
                }
                else
                {
                    anims.SetInteger("direccion", direccion.Peek());
                    objetivo = posiciones.Peek();
                }
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                objetivo,
                jugador.GetComponent<pMovimiento>()
                .movSpeed / 50 * Time.deltaTime
            );
        }
        posAnterior = jugador.transform.position;
    }
}
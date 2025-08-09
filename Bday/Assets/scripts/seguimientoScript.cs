using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class seguimientoScript : MonoBehaviour
{
    public GameObject jugador;
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
        if (pos == new Vector3(0, 0, 0))
        {
            moverse = false;
            anims.SetBool("idle", true);
        }
        else
        {
            moverse = true;
            anims.SetBool("idle", false);
            direccion.Enqueue(dir);
            posiciones.Enqueue(pos);
        }
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
    }
}
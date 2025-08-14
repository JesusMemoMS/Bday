using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System;

public class findJugador : MonoBehaviour
{
    [SerializeField] Transform jugador;
    NavMeshAgent jeff;
    public SpriteRenderer jeffSprite;
    public Animator jeffAnim;
    private Vector3 posicionAnt;
    [NonSerialized] public bool moverse = true;
    void Start()
    {
        jeff = GetComponent<NavMeshAgent>();
        jeff.updateRotation = false;
        jeff.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moverse)
        {
            if (Vector3.Distance(posicionAnt, transform.position) < 0.001)
                jeffAnim.Play("idle");
            else
                jeffAnim.Play("corriendo");
            if (transform.position.x - jugador.position.x < 0 && jeffSprite.flipX == false)
            {
                jeffSprite.flipX = true;
            }
            else if (transform.position.x - jugador.position.x > 0 && jeffSprite.flipX == true)
            {
                jeffSprite.flipX = false;
            }
            posicionAnt = transform.position;
            jeff.SetDestination(jugador.position);
        }
        else
            jeff.SetDestination(transform.position);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        jeff.speed += 5;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        jeff.speed -= 5;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("killeable"))
        {
            SceneManager.LoadScene(3);
        }
    }
}

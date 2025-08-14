using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaPlayer : MonoBehaviour
{
    public AudioClip clip;
    public GameObject jugador;
    public AudioSource manager;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        jugador.transform.position = new Vector3(-6.765f, -0.767f, 0);
    }
    public void ponerMusica()
    {
        manager.clip = clip;
        manager.Play();
    }
}

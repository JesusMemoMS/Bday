using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escenaGuardado : MonoBehaviour
{
    public Animator cartelGuardado;
    public Transform jugador;
    public int acto;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("escena", acto);
        PlayerPrefs.SetFloat("posX", jugador.position.x);
        PlayerPrefs.SetFloat("posY", jugador.position.y);
        PlayerPrefs.Save();
        cartelGuardado.Play("defadeCartel");
    }
}

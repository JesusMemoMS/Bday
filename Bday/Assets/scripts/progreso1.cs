using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class progreso1 : MonoBehaviour
{
    public GameObject player;
    public UnityEvent prog1;
    private int progreso;
    void OnTriggerEnter2D(Collider2D other)
    {
        progreso = PlayerPrefs.GetInt("progreso");
        if (progreso == 0 && player.GetComponent<pMovimiento>().ultimoCuarto == "cuarto3")
        {
            PlayerPrefs.SetInt("progreso", PlayerPrefs.GetInt("progreso") + 1);
            prog1.Invoke();
        }
    }
}
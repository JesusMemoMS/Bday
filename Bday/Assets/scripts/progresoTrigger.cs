using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class progresoTrigger : MonoBehaviour
{
    public GameObject cartelGuardado;
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("progreso", PlayerPrefs.GetInt("progreso") + 1);
        cartelGuardado.GetComponent<cartelG>().cartelGuardado();
    }
}

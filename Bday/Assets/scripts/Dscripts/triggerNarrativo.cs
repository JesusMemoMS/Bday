using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerNarrativo : MonoBehaviour
{
    public Dialogo dialogo;
    public GameObject boton;
    [SerializeField] public Sprite[] carasDialogo;
    private void OnTriggerEnter2D(Collider2D other)
    {
        boton.SetActive(true);
        boton.GetComponent<interaccionHandler>().dialogo = dialogo;
        boton.GetComponent<interaccionHandler>().caras = carasDialogo;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boton.SetActive(false);
    }
}

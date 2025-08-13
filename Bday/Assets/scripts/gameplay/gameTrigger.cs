using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTrigger : MonoBehaviour
{
    public GameObject boton;
    private interaccionHandler InHandler;

    void Start()
    {
        InHandler = boton.GetComponent<interaccionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        boton.SetActive(true);
        InHandler.minijuego = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boton.SetActive(false);
        InHandler.minijuego = false;
    }
}

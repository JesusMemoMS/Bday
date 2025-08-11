using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleTrigger : MonoBehaviour
{
    public GameObject boton;
    public string pregunta;
    public string posFinal;
    public string cuartoSalida;
    public Vector3 posicionTeleport;
    public AudioClip musica;
    private interaccionHandler InHandler;

    void Start()
    {
        InHandler = boton.GetComponent<interaccionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        boton.SetActive(true);
        InHandler.pregunta = pregunta;
        InHandler.telePos = posicionTeleport;
        InHandler.posFinal = posFinal;
        InHandler.cuartoNom = cuartoSalida;
        InHandler.musicaCuarto = musica;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        boton.SetActive(false);
        boton.GetComponent<interaccionHandler>().pregunta = null;
    }
}

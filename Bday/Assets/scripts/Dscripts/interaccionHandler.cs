using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class interaccionHandler : MonoBehaviour
{
    public GameObject cajaInteract;
    public GameObject CartelGuardado;
    public AudioSource musicaManager;
    public Text textoInteract;
    public GameObject jugador;
    [NonSerialized] public AudioClip musicaCuarto;
    [NonSerialized] public Dialogo dialogo;
    [NonSerialized] public string cuartoNom;
    [NonSerialized] public Vector3 telePos;
    [NonSerialized] public string pregunta;
    [NonSerialized] public string posFinal;
    [NonSerialized] public Sprite[] caras;
    public void IHscript()
    {
        
        if (pregunta == null)
        // dialogo
        {
            FindObjectOfType<DMscript>().empiezaCaja(dialogo, caras, false);
        }
        else
        // interaccion
        {
            cajaInteract.SetActive(true);
            textoInteract.text = pregunta;
        }
    }
    public void interaccionConfirm()
    {
        if (musicaCuarto)
        {
            musicaManager.clip = musicaCuarto;
            musicaManager.Play();
        }
        PlayerPrefs.SetFloat("posX", jugador.transform.position.x);
        PlayerPrefs.SetFloat("posY", jugador.transform.position.y);
        Debug.Log(PlayerPrefs.GetFloat("posX"));
        PlayerPrefs.Save();
        jugador.GetComponent<pMovimiento>().ultimoCuarto = cuartoNom;
        jugador.transform.position = telePos;
        jugador.GetComponent<Animator>().Play(posFinal);
        CartelGuardado.GetComponent<Animator>().Play("defadeCartel");
    }
}
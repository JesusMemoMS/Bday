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
    public GameObject minijuegoBen;
    private pMovimiento jugaFunc;
    [NonSerialized] public AudioClip musicaCuarto;
    [NonSerialized] public Dialogo dialogo;
    [NonSerialized] public string cuartoNom;
    [NonSerialized] public Vector3 telePos;
    [NonSerialized] public string pregunta;
    [NonSerialized] public string posFinal;
    [NonSerialized] public Sprite[] caras;
    [NonSerialized] public bool minijuego;
    void Start()
    {
        jugaFunc = jugador.GetComponent<pMovimiento>();
    }
    public void IHscript()
    {
        if (minijuego)
        {
            jugaFunc.stopp();
            minijuegoBen.SetActive(true);
            jugaFunc.restartMovement();
        }
        else if (pregunta == null)
        // dialogo
        {
            jugaFunc.stopp();
            FindObjectOfType<DMscript>().empiezaCaja(dialogo, caras, false);
        }
        else
        // interaccion
        {
            jugaFunc.stopp();
            cajaInteract.SetActive(true);
            textoInteract.text = pregunta;
        }
    }
    public void interaccionConfirm()
    {
        jugaFunc.restartMovement();
        if (musicaCuarto)
        {
            musicaManager.clip = musicaCuarto;
            musicaManager.Play();
        }
        PlayerPrefs.SetFloat("posX", telePos.x);
        PlayerPrefs.SetFloat("posY", telePos.y);
        PlayerPrefs.Save();
        jugaFunc.ultimoCuarto = cuartoNom;
        jugador.transform.position = telePos;
        jugador.GetComponent<Animator>().Play(posFinal);
        CartelGuardado.GetComponent<Animator>().Play("defadeCartel");
    }
}
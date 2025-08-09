using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portadaManager : MonoBehaviour
{
    public GameObject portada;
    public Image imgJugar;
    public Button botonJugar;
    public Sprite botonNa;
    public AudioSource musica;
    private AudioSource sonidoRaro;

    void Start()
    {
        if (!PlayerPrefs.HasKey("posX"))
        {
            disableJugar();
        }
    }
    void disableJugar()
    {
        imgJugar.sprite = botonNa;
        botonJugar.interactable = false;
    }
    public void bum()
    {
        PlayerPrefs.DeleteAll();
        disableJugar();
    }
    public void NuevaPartida()
    {
        PlayerPrefs.DeleteAll();
        portada.SetActive(false);
        sonidoRaro = GetComponent<AudioSource>();
        sonidoRaro.Play();
        StartCoroutine(Esperador(musica));
    }
    public void ContinuarPartida()
    {
        portada.SetActive(false);
        sonidoRaro = GetComponent<AudioSource>();
        sonidoRaro.Play();
        StartCoroutine(Esperador(musica));
    }
    public IEnumerator Esperador(AudioSource musica)
    {
        yield return new WaitForSeconds(3);
        musica.Stop();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("acto1");
    }
    public void SalirJuego()
    {
        Console.WriteLine("botoneado2");
        Application.Quit();
    }
}
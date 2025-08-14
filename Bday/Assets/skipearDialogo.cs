using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipearDialogo : MonoBehaviour
{
    public funcCinematica ultCinem;
    public GameObject dialogOtro;
    public Animator mataMasky;
    public AudioSource audioManager;
    public AudioClip clip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerPrefs.GetInt("redo") == 1)
        {
            ultCinem.bossPlay.Invoke();
            mataMasky.Play("idleDare");
            audioManager.clip = clip;
            audioManager.Play();
            Destroy(dialogOtro);
            Destroy(this);
        }
    }
}

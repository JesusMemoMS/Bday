using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class funcCinematica : MonoBehaviour
{
    public Dialogo dialogo;
    public AudioSource musicamanager;
    public AudioClip sonido;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    public GameObject esto;
    public UnityEvent bossPlay;
    public void CinematicaD()
    {
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);

        StartCoroutine(Cinematica());
    }
    void OnTriggerExit2D(Collider2D other)
    {
        bossPlay.Invoke();
        Destroy(esto);
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        if (musicamanager)
        {
            musicamanager.clip = sonido;
            musicamanager.Play();
        }
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, false);
    }
}

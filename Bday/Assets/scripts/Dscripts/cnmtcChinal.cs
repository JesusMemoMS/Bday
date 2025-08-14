using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnmtcChinal : MonoBehaviour
{
    public GameObject jugador;
    public AudioSource managerSonido;
    public AudioClip sonidoInicio;
    public AudioClip sonidoFinal;
    public Dialogo dialogo;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    public GameObject esto;


    void OnTriggerEnter2D(Collider2D other)
    {
        managerSonido.clip = sonidoInicio;
        managerSonido.Play();
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);
        jugador.GetComponent<pMovimiento>().stopp();

        StartCoroutine(Cinematica());
    }
    void OnTriggerExit2D(Collider2D other)
    {
        managerSonido.clip = sonidoFinal;
        managerSonido.Play();
        Destroy(esto);
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, false);
    }
}

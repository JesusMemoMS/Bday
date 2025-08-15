using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalFinal : MonoBehaviour
{
    public Animator finAnim;
    public Transform posJeff;
    public AudioClip musica;
    public AudioClip musica2;
    public AudioSource mscmanager;
    public GameObject jugador;
    public Dialogo dialogo;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    public findJugador jeff;
    private bool kitchenwareNcandybars;

    void OnTriggerEnter2D(Collider2D other)
    {
        kitchenwareNcandybars = true;
        mscmanager.clip = musica;
        mscmanager.Play();
        jeff.jugador = posJeff;
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);
        jugador.GetComponent<pMovimiento>().stopp();

        StartCoroutine(Cinematica());
    }
    public void exitCinemita()
    {
        Debug.Log(kitchenwareNcandybars);
        if (kitchenwareNcandybars)
        {
            kitchenwareNcandybars = false;
            PlayerPrefs.DeleteAll();
            mscmanager.clip = musica2;
            mscmanager.Play();
            finAnim.Play("final");
            StartCoroutine(FINAL());
        }
    }
    IEnumerator FINAL()
    {
        yield return new WaitForSeconds(57);
        SceneManager.LoadScene(0);
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, true);
    }
}

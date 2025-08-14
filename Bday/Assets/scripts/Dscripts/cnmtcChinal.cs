using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class cnmtcChinal : MonoBehaviour
{
    public GameObject jugador;
    public AudioSource managerSonido;
    public AudioClip sonidoInicio;
    public Dialogo dialogo;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    public Animator animacion;
    public cnmtcChinal otraOpcion;
    public funcCinematica otraCinematica;
    public bool animar;
    public bool uno;
    private bool kitchenwareNcandybars;
    private int contador = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (uno)
        {
            dialogar();
        }
    }
    public void contaduria()
    {
        contador++;
    }
    public void dialogar()
    {
        kitchenwareNcandybars = true;
        if (sonidoInicio)
        {
            managerSonido.clip = sonidoInicio;
            managerSonido.Play();
        }
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);
        jugador.GetComponent<pMovimiento>().stopp();

        StartCoroutine(Cinematica());
    }
    public void chinalDialogo()
    {
        Debug.Log(kitchenwareNcandybars);
        if (kitchenwareNcandybars)
        {
            kitchenwareNcandybars = false;
            if (animar)
                StartCoroutine(DoesItCall());
            else
                otraOpcion.dialogar();

        }
    }
    IEnumerator DoesItCall()
    {
        yield return new WaitUntil(() => contador == 2);
        animacion.Play("dareIf");
        yield return new WaitForSeconds(5.5f);
        StopAllCoroutines();
        otraCinematica.CinematicaD();
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCinematicaSlenderman : MonoBehaviour
{
    public Dialogo dialogo;
    public GameObject jugador;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    //--------------------------------
    private bool kitchenwareNcandybars;
    public Animator animSlenderman;
    public funcCinematica scriptSiguiente;

    void OnTriggerEnter2D(Collider2D other)
    {
        kitchenwareNcandybars = true;
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);
        jugador.GetComponent<pMovimiento>().stopp();

        StartCoroutine(Cinematica());
    }
    public void SlendyDialogo()
    {
        if (kitchenwareNcandybars)
        {
            kitchenwareNcandybars = false;
            StartCoroutine(DoesItCall());

        }
    }
    IEnumerator DoesItCall()
    {
        animSlenderman.Play("slenderm");
        yield return new WaitForSeconds(4);
        StopAllCoroutines();
        scriptSiguiente.CinematicaD();
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, true);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class triggerRecuerdo : MonoBehaviour
{
    public pMovimiento jugador;
    public Dialogo dialogo;
    public GameObject sally;
    [SerializeField] public Sprite[] carasDialogo;
    public SpriteRenderer cuartoCentro;
    public Camera camara;
    public GameObject uiGameplay;
    public GameObject esto;
    public Text objetivoTexto;
    public GameObject oscuro;
    public findJugador jeff;
    private bool kitchenwareNcandybars;
    void OnTriggerEnter2D(Collider2D other)
    {
        kitchenwareNcandybars = true;
        jeff.moverse = false;
        oscuro.SetActive(true);
        camara.GetComponent<camaraWork>().bloqueado = true;
        camara.transform.position = new Vector3(cuartoCentro.bounds.center.x, cuartoCentro.bounds.center.y, -10);
        uiGameplay.SetActive(false);
        jugador.stopp();
        jugador.cantRecuerdos += 1;

        StartCoroutine(Cinematica());
    }
    public void exitCinemita()
    {
        if (kitchenwareNcandybars)
        {
            kitchenwareNcandybars = false;
            objetivoTexto.text = "Busca las Memorias (" + jugador.cantRecuerdos + "/5)";
            if (jugador.cantRecuerdos == 5)
            {
                objetivoTexto.text = "Encuentra a Sally";
                sally.SetActive(true);
            }
            oscuro.SetActive(false);
            jeff.moverse = true;
            Destroy(esto);
        }
    }
    IEnumerator Cinematica()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DMscript>().empiezaCaja(dialogo, carasDialogo, false);
    }
}

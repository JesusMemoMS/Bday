using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DMscript : MonoBehaviour
{
    private Queue<string> parrafosListos;
    private Queue<string> nombresListos;
    private Queue<Sprite> spritesListos;
    private bool activo;
    public GameObject uiGameplay;
    public GameObject cajaDialogo;
    public GameObject cajaNarracion;
    public Image fotoCara;
    public Text textoDialogo;
    public Text textoNarracion;
    public Text nombreDialogo;
    public UnityEvent endDialogo;
    public Camera camarilla;
    private AudioSource eee;
    private bool dialogoBool;
    private bool slender;

    void Start()
    {
        parrafosListos = new Queue<string>();
        nombresListos = new Queue<string>();
        spritesListos = new Queue<Sprite>();
        eee = GetComponent<AudioSource>();
    }

    public void empiezaCaja(Dialogo dialogo, Sprite[] carasonas, bool slender_)
    {
        slender = slender_;
        parrafosListos.Clear();
        if (carasonas.Length != 0)
        {
            dialogoBool = true;
            for (int i = 0; i < dialogo.parrafos.Length; i++)
            {
                parrafosListos.Enqueue(dialogo.parrafos[i]);
                nombresListos.Enqueue(dialogo.nombres[i]);
                spritesListos.Enqueue(carasonas[i]);
            }
        }
        else
        {
            dialogoBool = false;
            foreach (string parrafo in dialogo.parrafos)
            { parrafosListos.Enqueue(parrafo); }
        }

        activo = true;

        if (dialogoBool)
        {
            if (dialogo.arriba)
                cajaDialogo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 146);
            else
                cajaDialogo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -127);
            cajaDialogo.SetActive(true);
            siguienteParrafo();
        }
        else
        {
            if (dialogo.arriba)
                cajaNarracion.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 146);
            else
                cajaNarracion.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -127);
            cajaNarracion.SetActive(true);
            siguienteParrafo();
        }
    }
    public void siguienteParrafo()
    {
        if (parrafosListos.Count == 0)
        {
            activo = false;
            StopAllCoroutines();
            terminaDialogo();
            return;
        }

        StopAllCoroutines();
        string parrafo = parrafosListos.Dequeue();
        if (dialogoBool)
        {
            nombreDialogo.text = nombresListos.Dequeue();
            fotoCara.sprite = spritesListos.Dequeue();
            StartCoroutine(letraPorLetra(parrafo, textoDialogo));
        }
        else
            StartCoroutine(letraPorLetra(parrafo, textoNarracion));
    }
    IEnumerator letraPorLetra(string parrafo, Text texto)
    {
        texto.text = "";

        foreach (char letra in parrafo.ToCharArray())
        {
            texto.text += letra;

            if (!eee.isPlaying)
                eee.Play();
            yield return new WaitForSeconds(0.03f);
        }
    }

    void terminaDialogo()
    {
        if (dialogoBool)
            cajaDialogo.SetActive(false);
        else
            cajaNarracion.SetActive(false);
        if (slender)
        {
            endDialogo.Invoke();
            return;
        }
        FindObjectOfType<camaraWork>().bloqueado = false;
        uiGameplay.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && activo)
        {
            siguienteParrafo();
        }
    }
}
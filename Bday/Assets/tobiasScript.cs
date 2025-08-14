using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tobiasScript : MonoBehaviour
{
    private Image imagen;
    void Start()
    {
        imagen = GetComponent<Image>();
    }
    public void cooldown()
    {
        imagen.raycastTarget = false;
        imagen.color = Color.clear;
        StartCoroutine(coldown());
    }
    public void destroyy()
    {
        Destroy(this);
    }
    IEnumerator coldown()
    {
        yield return new WaitForSeconds(5);
        imagen.color = Color.white;
        imagen.raycastTarget = true;
    }
}
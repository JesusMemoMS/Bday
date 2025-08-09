using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveCambio : MonoBehaviour
{
    public BoxCollider2D trigger;
    public bool destruir;
    public int minimo;
    private int progreso;

    void Start()
    {
        makeChange();
    }
    public void makeChange()
    {
        progreso = PlayerPrefs.GetInt("progreso");
        if (progreso >= minimo)
        {
            if (destruir)
                trigger.isTrigger = false;
            else
                trigger.isTrigger = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class desactivarPatos : MonoBehaviour
{
    [SerializeField] seguimientoScript[] patos;
    public bool activar;
    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (seguimientoScript pato in patos)
        {
            if (activar)
                pato.activo = true;
            else
                pato.activo = false;
        }
        Destroy(this);
    }
}

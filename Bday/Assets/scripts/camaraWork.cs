using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class camaraWork : MonoBehaviour
{
    public GameObject player;
    [DoNotSerialize] public bool bloqueado;
    public float offsetY;
    Transform posPlayer;
    void Start()
    {
        bloqueado = false;
    }

    void Update()
    {
        if (!bloqueado)
        {
            posPlayer = player.transform;
            transform.position = new Vector3(posPlayer.position.x, posPlayer.position.y + offsetY, -1);
        }
        
    }
}

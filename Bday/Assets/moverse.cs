using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverse : MonoBehaviour
{
    public GameObject camara;
    Transform posPlayer;

    void Update()
    {
        posPlayer = camara.transform;
        transform.position = new Vector3(posPlayer.position.x, posPlayer.position.y, 0);
    }
}

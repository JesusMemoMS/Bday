using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soloBorra : MonoBehaviour
{
    public GameObject destroy;
    public moverse scriptFondo;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (scriptFondo)
            scriptFondo.enabled = true;
        Destroy(destroy);
        Destroy(this);
    }
}

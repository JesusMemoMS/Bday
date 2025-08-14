using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class camaraAgrandar : MonoBehaviour
{
    public Camera camara;
    public float multiplicadorCamara;
    public float offset;

    void OnTriggerStay2D(Collider2D other)
    {
        camara.orthographicSize = .5f * multiplicadorCamara;
        camara.GetComponent<camaraWork>().offsetY += offset;
        Destroy(this);
    }
}

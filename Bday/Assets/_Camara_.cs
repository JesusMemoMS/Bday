using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Camara_ : MonoBehaviour
{
    public Camera camara;
    public float multCamara1;
    public float multCamara2;

    void OnTriggerStay2D(Collider2D other)
    {
        camara.orthographicSize = .5f * multCamara1;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        camara.orthographicSize = .5f * multCamara2;
        Destroy(this);
    }
}

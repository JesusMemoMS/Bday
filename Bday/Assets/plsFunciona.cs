using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plsFunciona : MonoBehaviour
{
    public benGame scrip;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetType() == typeof(PolygonCollider2D))
        {
            scrip.tocando = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetType() == typeof(PolygonCollider2D))
        {
            scrip.tocando = false;
        }
    }
}

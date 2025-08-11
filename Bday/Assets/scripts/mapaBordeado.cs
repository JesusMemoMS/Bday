using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mapaBordeado : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        PolygonCollider2D forma = this.AddComponent<PolygonCollider2D>();
        Vector2[] puntos = forma.points;

        //gracias tuankendoo
        Vector2[] closedPoints = new Vector2[puntos.Length + 1];
        for (int i = 0; i < puntos.Length; i++)
        {
            closedPoints[i] = puntos[i];
        }
        closedPoints[^1] = puntos[0];

        EdgeCollider2D caja = this.AddComponent<EdgeCollider2D>();
        caja.points = closedPoints;
        Destroy(forma);
    }
}

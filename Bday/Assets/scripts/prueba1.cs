using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba1 : MonoBehaviour
{
    public GameObject player;

    public void bismilla()
    {
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapascript : MonoBehaviour
{
    public GameObject mapa;
    public void change()
    {
        mapa.SetActive(!mapa.activeSelf);
    }
}